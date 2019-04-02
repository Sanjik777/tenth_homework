using System;
/*
 1.	Создать массив сотрудников. Длина массива задается пользователем,
заполнение массива производится им же. Выполнить следующее:
a.	вывести полную информацию обо всех сотрудниках;
b.	найти в массиве всех менеджеров, зарплата которых больше
средней зарплаты всех клерков, вывести на экран полную информацию
о таких менеджерах отсортированной по их фамилии.
c.	распечатать информацию обо всех сотрудниках, принятых на работу
позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.
 */
namespace tenth_homework
{
	public enum Position
	{
		clerk   =1,
		manager =2,
		boss    =3
	}
	public struct Office
	{
		const int amountofDots = 3;
		const int MIN_BOUND_OF_POSITION = 1;
		const int MAX_BOUND_OF_POSITION = 2;

		public string name;
		public int salary;
		public Position position;
		public DateTime dateTimeEmployment;

		public void Init()
		{
			Console.WriteLine("Введите имя:");
			name = Console.ReadLine();
			Console.WriteLine("Введите зарплату:");
			salary = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Выберите должность 1(клерк), 2(мэнэджер), 3(директор):");

			try
			{
				int key = Convert.ToInt32(Console.ReadLine());
				if (key> MAX_BOUND_OF_POSITION && key< MIN_BOUND_OF_POSITION)
				{
					throw new Exception("Не правильно задали должность!");
				}
				else
				{
					position = (Position)key;
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine(exception.Message);
			}

			Console.WriteLine("Введите дату принятия на работу, через '-' или '.'  :");

			dateTimeEmployment = Convert.ToDateTime(Console.ReadLine());

			Console.WriteLine("\n");
		}
		public void Print()
		{
			Console.WriteLine($"name\t\t: {name}" +
						  $"\nsalary\t\t: {salary}"+
					     $"\nvacancies\t: {position}"+
						 $"\nemployment date : {dateTimeEmployment.ToString()}");

			Console.WriteLine("\n");
		}
	}
}
