using System;
namespace PersonExercise
{
	public class Person
	{
        public Person(String name, int age)
		{
			this.Name = name;
			this.Age = age;
		}

        private string name;

        private int age;

        public String Name
        {
			get {
				return this.name;
			}
			set {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Cant be null or empty");
				this.name = value;
					}
		}

		public int Age
        {
			get
			{
				return this.age;
			}
			set
			{
                if (value <0) throw new ArgumentException("Cant be negative");
                this.age = value;
			}
		}
	}
}

