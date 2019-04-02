using System;
using System.Collections.Generic;
using System.Linq;
/*
Структуры, перечисления.

1.	Создать массив сотрудников. Длина массива задается пользователем,
заполнение массива производится им же. Выполнить следующее:
a.	вывести полную информацию обо всех сотрудниках;
b.	найти в массиве всех менеджеров, зарплата которых больше
средней зарплаты всех клерков, вывести на экран полную информацию
о таких менеджерах отсортированной по их фамилии.
c.	распечатать информацию обо всех сотрудниках, принятых на работу
позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.
2.	Для получения места в общежитии формируется список студентов,
который включает Ф.И.О. студента, группу, средний балл,
доход на члена семьи, пол (перечисление), форма обучения(перечисление).
Общежитие в первую очередь предоставляется тем,
у кого доход на члена семьи меньше двух минимальных зарплат,
затем остальным в порядке уменьшения среднего балла.
Вывести список очередности предоставления мест в общежитии.

*/
namespace tenth_homework
{

	class Program
	{
		static void Main(string[] args)
		{
			//---------------------1------------------------		
			Console.WriteLine("Введите кол-во работников в офисе:");
			int amountOfWorkers = Convert.ToInt32(Console.ReadLine());

			Office[] office = new Office[amountOfWorkers];

			for (int i = 0; i < office.Length; i++)
			{
				office[i].Init();
			}
			Console.WriteLine("\n-----------Вывод-------------\n");
			for (int i = 0; i < office.Length; i++)
			{
				office[i].Print();
			}
			/*
			b. найти в массиве всех менеджеров, зарплата которых больше
            средней зарплаты всех клерков, вывести на экран полную информацию
            о таких менеджерах отсортированной по их фамилии.
			*/

			if (Array.Exists(office, x => x.position == Position.manager)
				&& Array.Exists(office, x => x.position == Position.clerk))
			{
				Console.WriteLine("\n-------все менеджеры---------\n");
				Office[] ourManagers = Array.FindAll(office,
				x => x.position == Position.manager);

				for (int i = 0; i < ourManagers.Length; i++)
				{
					ourManagers[i].Print();
				}

				Console.WriteLine("\n--------все клерки-----------\n");

				Office[] ourClerks = Array.FindAll(office,
				x => x.position == Position.clerk);

				for (int i = 0; i < ourClerks.Length; i++)
				{
					ourClerks[i].Print();
				}

				// Первый способ:
				Office[] ourBiggerManagers = Array.FindAll(ourManagers,
						x => x.salary > ourClerks.Max(y => y.salary));

				// Второй способ:
				//Office[] ourBiggerManagers = Array.FindAll(Array.FindAll(office,
				//	x => x.position == Position.manager),x => x.salary > ourClerks.Max(y => y.salary));

				Array.Sort(ourBiggerManagers, delegate (Office x, Office y)
				{
					return x.name.CompareTo(y.name);
				});

				Console.WriteLine("\n-------Все менеджеры," +
					" у которых зарплата больше чем у клерков, отсортировано по имени----------\n");
				for (int i = 0; i < ourBiggerManagers.Length; i++)
				{
					ourBiggerManagers[i].Print();
				}
			}
			else { Console.WriteLine("Нет либо клерка, либо менеджера"); }

			/*
			c.	распечатать информацию обо всех сотрудниках, принятых на работу
            позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.
			*/
			if (Array.Exists(office, x => x.position == Position.boss))
			{
				Console.WriteLine("\n--------все кто позже босса-----------\n");
				Office boss = Array.Find(office, x => x.position == Position.boss);

				Office[] laterDate = Array.FindAll(
				office, x => x.dateTimeEmployment > boss.dateTimeEmployment);

				for (int i = 0; i < laterDate.Length; i++)
				{
					laterDate[i].Print();
				}
			}
			else { Console.WriteLine("Нет босса"); }



			//----------------------2------------------------
			/*
			2.	Для получения места в общежитии формируется список студентов,
            который включает Ф.И.О. студента, группу, средний балл,
            доход на члена семьи, пол (перечисление), форма обучения(перечисление).
            Общежитие в первую очередь предоставляется тем,
            у кого доход на члена семьи меньше двух минимальных зарплат,
            затем остальным в порядке уменьшения среднего балла.
            Вывести список очередности предоставления мест в общежитии.
			*/
			const int numberStudents = 4;
			Student []students = new Student[numberStudents];

			students[0] = new Student("Ivanov",   "213", 10, 312000, Sex.male, Education.fullTime);
			students[1] = new Student("Petrov",   "213", 12, 286000, Sex.male, Education.fullTime);
			students[2] = new Student("Smirnov",  "213", 9, 435000, Sex.male, Education.fullTime);
			students[3] = new Student("Kuznecov", "213", 12, 80000, Sex.male, Education.fullTime);

			const int minSalary = 42500;

			Student[] minIncomeFamily = Array.FindAll(students,x=>x.income < minSalary+minSalary);
			Console.WriteLine("\n\n---------Студент с меньшим семейным доходом:--------\n");
			foreach (var i in minIncomeFamily)
			{
				i.Print();
			}
			Console.WriteLine("\n------------Остальные студенты с сортировкой:-----------\n");
			Student[] otherStudents = Array.FindAll(students, x => x.income > minSalary + minSalary);
			Array.Sort(otherStudents,delegate(Student x, Student y)
			{
				return y.mark.CompareTo(x.mark);
			});
			foreach (var i in otherStudents)
			{
				i.Print();
			}
			Console.ReadKey();
		}
	}
}
