using System.Numerics;
using System.Runtime.CompilerServices;

namespace Study0708
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Animals animals = new Animals("고양이");
            animals.Voice();
            Console.WriteLine("=============================");
            Dog dog = new Dog();
            dog.Voice();
            */
            /*
            Taxi taxi = new Taxi("택시", 5);
            taxi.Show();
            Truck truck = new Truck("트럭", 10);
            truck.Show();
            truck.SayName();
            */

            Dog dog = new Dog("강아지");
            dog.Voice();
            dog.Voice("고양이");
        }
    }

    abstract class Car
    {
        protected string name;
        protected float speed;
        public void Test(string name)
        {
            Console.WriteLine($"in Car - {this.name}");
        }
        public abstract void Show();
        public virtual void SayName()
        {
            Console.WriteLine("in Car - Nothing");
            Console.WriteLine($"in Car - {this.name}");
        }
    }

    class Taxi : Car
    {
        public Taxi(string name, float speed)
        {
            this.name = name;
            this.speed = speed;
        }
        public override void Show()
        {
            Console.WriteLine($"Taxi: {name}");
            Console.WriteLine($"Taxi: {speed}");
        }
    }
    class Truck : Car
    {
        public Truck(string name, float speed)
        {
            this.name = name;
            this.speed = speed;
        }
        public override void Show()
        {
            Console.WriteLine($"Truck: {name}");
            Console.WriteLine($"Truck: {speed}");
        }
        public override void SayName()
        {
            Console.WriteLine($"in Truck - SayName : {this.name}");
        }
    }

    interface Animals
    {
        public void Voice(string name);
        public void Voice();
    }

    class Dog : Animals
    {
        public string name;

        public void Voice(string name)
        {
            Console.WriteLine($"{name} 이름 넣기");
        }
        public void Voice()
        {
            Console.WriteLine($"{this.name} 이름 넣기");
        }


        public Dog(string name)
        {
            this.name = name;
            Console.WriteLine($"Dog {name} 생성자");
        }
    }
}
