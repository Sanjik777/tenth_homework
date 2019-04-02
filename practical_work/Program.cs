using System;
/*
 Структуры, перечисления.

1.	Создать перечисление должностей Vacancies {Manager, Boss, Clerk, Salesman, и т.д.}
2.	2. Создать структуру «Employee» состоящую из:
a.	поля name строкового типа;
b.	поля vacancy типа Vacancies;
c.	поля зарплата целого типа;
d.	поля дата приема на работу типа int[3].

 */
namespace practical_work
{
	enum Vacancies
	{
		Manager,
		Boss,
		Clerk,
		Salesman
	}
	struct Employee
	{
		public string name;
		public Vacancies vacancies;
		public int salary;
		public int[] dateEmployment;
		public void Print()
		{
			Console.WriteLine($"name\t\t: {name}" +
				 $"\nvacancies\t: {vacancies}" +
	             $"\nsalary\t\t: {salary}");
			Console.Write("employment date : ");
			foreach (var i in dateEmployment)
			{
				Console.Write(i+".");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			const int amountofDots = 3;
			Employee employee;
			employee.name = "Vasya";
			employee.vacancies = Vacancies.Clerk;
			employee.salary = 200000;

			employee.dateEmployment = new int[amountofDots];
			employee.dateEmployment[0] = 20;
			employee.dateEmployment[1] = 04;
			employee.dateEmployment[2] = 2019;
			employee.Print();
			Console.ReadKey();
		}
	}
}
