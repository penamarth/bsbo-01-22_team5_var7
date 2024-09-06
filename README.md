# Практическая работа №1
## Модельно-ориентированный подход к проектированию

## Порядок выполнения практической работы
 
1.	При помощи программы StarUML либо любого редактора построить UML-диаграмму вариантов использования, диаграмму классов проектируемой информационной системы в соответствии с вариантом задания, а также диаграмму последовательности для наиболее часто используемых прецедентов . При построении диаграммы классов нужно добиться достаточной детализации информационной системы. Убедитесь в том, что использовали отношения dependency, aggregation/composition, generalization, описали размещение классов по пакетам проекта.

2.	Подготовить отчет с включением диаграмм.
Рекомендации по разработке диаграмм вариантов использования
-	Диаграмма вариантов использования может служить основой для согласования с заказчиком функциональных требований к системе на ранней стадии проектирования.
-	Рекомендуемая последовательность действий

    -	Определить главных или первичных и второстепенных актеров 
    -	Определить цели главных актеров по отношению к системе 
    -	Сформулировать основные варианты использования, которые специфицируют функциональные требования к системе 
    -	Упорядочить варианты использования по степени убывания риска их реализации 
    -	Рассмотреть все базовые варианты использования в порядке убывания их степени риска 
    -	Выделить участников, интересы, предусловия и постусловия выполнения выбранного варианта использования 
    -	Написать успешный сценарий реализации выбранного варианта использования 
    -	Определить исключения или неуспех в выполнении сценария варианта использования 
    -	Написать сценарии для всех исключений 
    -	Выделить общие варианты использования и изобразить их взаимосвязи с базовыми со стереотипом <<include>> 
    -	Выделить варианты использования для исключений и изобразить их взаимосвязи с базовыми со стереотипом <<extend>> 
    -	Проверить диаграмму на отсутствие дублирования вариантов использования и актеров 

## Контрольные вопросы

1.	Что такое UML? Какие вы знаете основные диаграммы UML?
2.	Какие элементы входят в состав диаграммы классов? 

## Полезные ссылки

1.	http://www.omg.org/mda/
2.	OMG UML Specification http://www.omg.org/spec/UML/ 
3.	OMG XMI Specification http://www.omg.org/spec/XMI/ 
4.	Статья об MDA - https://www.osp.ru/os/2003/09/183391/ 
5.	Статьи о UML Refactoring https://www.researchgate.net/publication/311856689_Model_and_Criteria_for_the_Automated_Refactoring_of_the_UML_Class_Diagrams 



## Вариант

7.Система учета рабочего времени 
Обзор: Система учета рабочего времени позволяет руководителям выдавать задания и отслеживать ход их выполнения, а исполнителям - вести учет рабочего времени, затраченного на выполнение каждого задания.



Пример: https://gitlab.com/penamarth/pos.git