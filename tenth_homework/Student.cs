using System;
/*
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
	public enum Sex
	{
		male,
		female
	}
	public enum Education
	{
		fullTime,
		partTime
	}
	public struct Student
	{


		public string fullname;
		public string group;
		public int mark;
		public int income;
		public Sex sex;
		public Education education;

		public Student(string fullname, string group, int mark, int income, Sex sex, Education education)
		{
			this.fullname = fullname;
			this.group = group;
			this.mark = mark;
			this.income = income;
			this.sex = sex;
			this.education = education;
		}
		public void Print()
		{
			Console.WriteLine($"fullname  : {fullname}" +
            $"\ngroup\t  : {group}" +
            $"\nmark\t  : {mark}" +
            $"\nincome\t  : {income}" +
            $"\nsex\t  : {sex}" +
            $"\neducation : {education}");

			Console.WriteLine("\n");
		}
		//public void ProvidingPlaces()
		//{
		//	if (income < (minSalary+minSalary))
		//	{
		//		Print();
		//	}
		//}
	}
}
