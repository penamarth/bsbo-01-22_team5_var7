using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskManagementSystem
{
    // Перечисление для статуса задачи
    public enum TaskStatus
    {
        Created, // Создана
        InProgress, // В процессе
        Paused, // Приостановлена
        Completed, // Завершена
        Accepted, // Принята
        Rejected // Отклонена
    }

    // Интерфейс для действий
    public interface IAction
    {
        void Execute();
    }

    // Действие: Создать задачу
    public class CreateTaskAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача создана.");
        }
    }

    // Действие: Собрать статистику
    public class CollectStatisticsAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Статистика собрана.");
        }
    }

    public class Logs
    {
        public string GetDetailedLogs()
        {
            // Симуляция возврата детализированных логов
            return "Данные детализированных логов";
        }

        public string AnalyzeLogs()
        {
            // Симуляция анализа логов
            return "Анализ логов завершен";
        }
    }

    public class DiagnosticTool
    {
        public string RunDiagnostics()
        {
            // Симуляция выполнения диагностики
            return "Диагностика завершена";
        }

        public string ApplyFix()
        {
            // Симуляция применения исправления
            return "Исправление успешно применено";
        }
    }

    // Действие: Техническая поддержка
    public class TechSupportAction : IAction
    {
        private Logs logs = new Logs();
        private DiagnosticTool diagnosticTool = new DiagnosticTool();
        private Notification notification = new Notification();

        public void Execute()
        {
            Console.WriteLine("Предоставлена техническая поддержка.");

            // Симуляция обнаружения проблемы
            bool issueDetected = true;  // Предположим, что проблема обнаружена

            if (issueDetected)
            {
                // Если проблема обнаружена, выполняем дополнительные действия
                Console.WriteLine("Проблема обнаружена. Уведомление системного администратора...");

                // Получаем детализированные логи
                string detailedLogs = logs.GetDetailedLogs();
                Console.WriteLine($"Логи: {detailedLogs}");

                // Запуск диагностики
                string diagnosticsResult = diagnosticTool.RunDiagnostics();
                Console.WriteLine($"Результат диагностики: {diagnosticsResult}");

                // Применение исправления
                string fixResult = diagnosticTool.ApplyFix();
                Console.WriteLine($"Исправление применено: {fixResult}");

                // Уведомление после исправления
                notification.Send("Проблема решена");
            }
            else
            {
                // Если проблемы нет, выводим сообщение
                Console.WriteLine("Проблем не обнаружено.");
            }
        }
    }

    // Действие: Мониторинг прогресса задачи
    public class MonitorTaskProgressAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Прогресс задачи отслеживается.");
        }
    }

    // Действие: Проверка задачи
    public class CheckTaskAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача проверена.");
        }
    }

    // Действие: Завершение задачи
    public class CompleteTaskAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача завершена.");
        }
    }

    // Интерфейс для ролей
    public interface IRole
    {
        List<IAction> GetActions();
    }

    // Роль менеджера
    public class ManagerRole : IRole
    {
        public List<IAction> GetActions()
        {
            return new List<IAction> { new CreateTaskAction(), new CollectStatisticsAction(), new MonitorTaskProgressAction() };
        }
    }

    // Роль сотрудника
    public class EmployeeRole : IRole
    {
        public List<IAction> GetActions()
        {
            return new List<IAction> { new CheckTaskAction(), new CompleteTaskAction() };
        }
    }

    // Роль системного администратора
    public class SystemsAdministratorRole : IRole
    {
        public List<IAction> GetActions()
        {
            return new List<IAction> { new TechSupportAction() };
        }
    }

    // Класс, представляющий задачу
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public double Progress { get; set; }

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = TaskStatus.Created;
            Progress = 0;
        }

        public void Start()
        {
            Status = TaskStatus.InProgress;
            Console.WriteLine($"Задача {Id}: {Title} начата.");
        }

        public void Pause()
        {
            Status = TaskStatus.Paused;
            Console.WriteLine($"Задача {Id}: {Title} приостановлена.");
        }

        public void Resume()
        {
            Status = TaskStatus.InProgress;
            Console.WriteLine($"Задача {Id}: {Title} возобновлена.");
        }

        public void Complete()
        {
            Status = TaskStatus.Completed;
            Console.WriteLine($"Задача {Id}: {Title} завершена.");
        }

        public void Accept()
        {
            Status = TaskStatus.Accepted;
            Console.WriteLine($"Задача {Id}: {Title} принята.");
        }

        public void Reject()
        {
            Status = TaskStatus.Rejected;
            Console.WriteLine($"Задача {Id}: {Title} отклонена.");
        }

        public void UpdateProgress(double progress)
        {
            Progress = progress;
            Console.WriteLine($"Задача {Id}: Прогресс обновлен до {Progress}%.");
        }

        public string GetTaskDetails()
        {
            return $"Задача {Id}: {Title} - {Description} - {Status} - {Progress}%";
        }
    }

    // Таблица связи назначенной задачи
    public class AssignedTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }

    // Класс пользователя
    public class User
    {
        public string Name { get; set; }
        public IRole Role { get; set; }

        public User(string name, IRole role)
        {
            Name = name;
            Role = role;
        }

        public void PerformAction(IAction action)
        {
            action.Execute();
        }

        public void AssignTask(Task task)
        {
            Console.WriteLine($"{Name} назначен на задачу {task.Id}: {task.Title}");
        }
    }

    // Класс бухгалтерии
    public class Accounting
    {
        public void SendWorkData(int taskId, double duration)
        {
            Console.WriteLine($"Данные работы для задачи {taskId}: Продолжительность - {duration} часов отправлены в бухгалтерию.");
        }
    }

    // Класс уведомлений
    public class Notification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Уведомление отправлено: {message}");
        }
    }

    // Система управления проектами - имитирует внешнюю систему для данных проекта
    public class ProjectManagementSystem
    {
        public string GetProjectData(string filters)
        {
            // Здесь мы симулируем процесс получения данных на основе фильтров
            Console.WriteLine($"Получение данных проекта с фильтрами: {filters}");
            return "Данные проекта";
        }
    }

    // Система HR - имитирует внешнюю систему для данных сотрудников
    public class HRSystem
    {
        public string GetEmployeeData(string filters)
        {
            // Здесь мы симулируем процесс получения данных на основе фильтров
            Console.WriteLine($"Получение данных сотрудников с фильтрами: {filters}");
            return "Данные сотрудников";
        }
    }

    // Система бухгалтерии - имитирует внешнюю систему для данных по зарплате
    public class AccountingSystem
    {
        public string GetPayrollData(string filters)
        {
            // Здесь мы симулируем процесс получения данных на основе фильтров
            Console.WriteLine($"Получение данных по зарплате с фильтрами: {filters}");
            return "Данные по зарплате";
        }
    }

    // Система для составления статистики на основе данных из нескольких источников
    public class StatisticsCompiler
    {
        public string CompileStatistics(string projectData, string employeeData, string payrollData)
        {
            Console.WriteLine("Составление статистики...");
            return $"Составленный отчет: {projectData}, {employeeData}, {payrollData}";
        }
    }


    // Main simulation class
    class Program
    {
        static void Main(string[] args)
        {
            // Первая симуляция: Менеджер, Сотрудник и Системный администратор
            Console.WriteLine("Первая симуляция:");

            // Создаем роли
            IRole managerRole = new ManagerRole();
            IRole employeeRole = new EmployeeRole();
            IRole sysAdminRole = new SystemsAdministratorRole();

            // Создаем пользователей
            User manager = new User("Alice", managerRole);
            User employee = new User("Bob", employeeRole);
            User sysAdmin = new User("Charlie", sysAdminRole);

            // Создаем задачи
            Task task1 = new Task(1, "Design Logo", "Design a new logo for the company");
            Task task2 = new Task(2, "Write Report", "Write a detailed report on last quarter");

            // Симуляция назначения задач
            manager.AssignTask(task1);
            employee.AssignTask(task2);

            // Менеджер выполняет действия
            Console.WriteLine("\nМенеджер выполняет действия:");
            foreach (var action in manager.Role.GetActions())
            {
                manager.PerformAction(action);
                Thread.Sleep(1000);  // Задержка в 1 секунду
            }

            // Симуляция начала и мониторинга задач
            task1.Start();  // Начинаем задачу 1
            task2.Start();  // Начинаем задачу 2
            Console.WriteLine("\nЗадачи начаты...");
            Thread.Sleep(1000);  

            task1.UpdateProgress(50);  // Обновляем прогресс задачи 1
            task2.UpdateProgress(30);  // Обновляем прогресс задачи 2
            Console.WriteLine("\nПрогресс задач обновлен...");
            Thread.Sleep(1000);  

            task1.Pause();  // Приостанавливаем задачу 1
            task2.Resume();  // Возобновляем задачу 2
            Console.WriteLine("\nЗадачи приостановлены и возобновлены...");
            Thread.Sleep(1000);

            task1.UpdateProgress(100);  // Обновляем прогресс задачи 1
            task2.UpdateProgress(100);  // Обновляем прогресс задачи 2
            task1.Complete();  // Завершаем задачу 1
            task2.Complete();  // Завершаем задачу 2
            Console.WriteLine("\nЗадачи завершены...");
            Thread.Sleep(1000); 

            // Выводим данные о задаче после завершения
            Console.WriteLine("\nДанные задач после завершения:");
            Console.WriteLine(task1.GetTaskDetails());
            Console.WriteLine(task2.GetTaskDetails());

            // Сотрудник выполняет действия
            Console.WriteLine("\nСотрудник выполняет действия:");
            foreach (var action in employee.Role.GetActions())
            {
                employee.PerformAction(action);
                Thread.Sleep(1000); 
            }

            // Симуляция проверки задач сотрудником
            Console.WriteLine("\nСотрудник проверяет прогресс задач:");
            Console.WriteLine(task1.GetTaskDetails());
            Console.WriteLine(task2.GetTaskDetails());

            // Системный администратор выполняет техническую поддержку
            Console.WriteLine("\nСистемный администратор выполняет техническую поддержку:");
            foreach (var action in sysAdmin.Role.GetActions())
            {
                sysAdmin.PerformAction(action);
                Thread.Sleep(1000); 
            }

            // Создаем внешние системы
            ProjectManagementSystem projectSystem = new ProjectManagementSystem();
            HRSystem hrSystem = new HRSystem();
            AccountingSystem accountingSystem = new AccountingSystem();
            StatisticsCompiler statsCompiler = new StatisticsCompiler();

            // Создаем действие для сбора статистики
            CollectStatisticsAction collectStatisticsAction = new CollectStatisticsAction();

            // Симуляция сбора статистики
            string filters = "Некоторые фильтры";  // Пример фильтров
            string projectData = projectSystem.GetProjectData(filters);
            string employeeData = hrSystem.GetEmployeeData(filters);
            string payrollData = accountingSystem.GetPayrollData(filters);

            string report = statsCompiler.CompileStatistics(projectData, employeeData, payrollData);

            // Уведомляем менеджера с собранным отчетом
            Notification notification = new Notification();
            notification.Send($"Менеджер: {report}");

            // Конец первой симуляции
            Console.WriteLine("\nСбор статистики завершен.");
            Console.WriteLine("\nПервая симуляция завершена.\n");

            // Вторая симуляция: отклонение задачи и ее доработка
            Console.WriteLine("Вторая симуляция:");

            // Создаем пользователей
            User manager2 = new User("Alice", managerRole);
            User employee2 = new User("Bob", employeeRole);

            // Создаем задачу
            Task task3 = new Task(1, "Design Logo", "Design a new logo for the company");

            // Симуляция назначения задачи
            manager2.AssignTask(task3);

            // Менеджер выполняет действия
            Console.WriteLine("\nМенеджер выполняет действия:");
            foreach (var action in manager2.Role.GetActions())
            {
                manager2.PerformAction(action);
                Thread.Sleep(1000);  
            }
            task3.UpdateProgress(30);  // Обновляем прогресс задачи
            // Симуляция отклонения задачи менеджером
            Console.WriteLine("\nМенеджер отклоняет задачу:");
            task3.Reject();  // Отклоняем задачу
            Console.WriteLine(task3.GetTaskDetails());  // Выводим подробности задачи
            Thread.Sleep(1000);  

            // Симуляция доработки задачи сотрудником
            Console.WriteLine("\nЗадача была доработана сотрудником:");

            // Менеджер снова принимает задачу
            Console.WriteLine("\nМенеджер принимает задачу:");
            task3.Accept();  // Принимаем задачу
            Console.WriteLine(task3.GetTaskDetails());  // Выводим подробности задачи
            Thread.Sleep(1000);  

            // Симуляция начала работы над задачей
            task3.Start();  // Начинаем работу над задачей
            task3.UpdateProgress(100);  // Обновляем прогресс задачи
            task3.Complete();  // Завершаем задачу

            // Выводим итоговые данные о задаче
            Console.WriteLine("\nИтоговые данные о задаче:");
            Console.WriteLine(task3.GetTaskDetails());

            // Конец второй симуляции
            Console.WriteLine("\nВторая симуляция завершена.");
        }
    }

}
