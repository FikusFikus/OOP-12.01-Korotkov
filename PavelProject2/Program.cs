using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavelProject2
{
    class Car
    {
        public string Model { get; set; }
        double engineSize;
        string typeOfBody;
        double hp;

        public double EngineSize
        {
            set
            {
                if (value > 0.80 && value < 7.00) engineSize = value;
            }
            get { return engineSize; }
        }

        public string TypeOfBody
        {
            set
            {
                string[] typesOfBodyArray = { "Coupe", "Crossover", "Hatchback", "Luxury", "MUV", "Notchback", "Sedan", "Sport Car", "SUV", "Wagon", "Super Car", "Minivan", "пушка гонка" };

                for (int i = 0; i < typesOfBodyArray.Length; i++)
                {
                    if (value.Contains(typesOfBodyArray[i])) typeOfBody = value;
                }
            }        
            get { return typeOfBody; }
        }

        public double HP
        {
            set
            {
                if (value < (engineSize * 130) && value > (engineSize * 60)) hp = value;
            }
            get { return hp; }
        }

        public void AccelerationRate()
        {
            double index = 2;

            if (engineSize <= 4) index = 3;
            else if (engineSize >= 4 && EngineSize >= 5.5) index = 2.5;

            double acceleration = 17 - (engineSize * index);

            Console.WriteLine($"Скорость разгона от 0 до 100 км/ч: {acceleration} сек.");

        }

        public virtual void GetRoar()
        {
            Console.WriteLine($"{Model} делает звук: Тр Тр Тр Тр");
        }

    }

    class BMW : Car
    {
        public override void GetRoar()
        {
            Console.WriteLine($"{Model} делает звук: Wroom Wroom");
        }
    }

    class Honda : Car
    {
        public override void GetRoar()
        {
            Console.WriteLine($"{Model} делает звук: Ssssamurai");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.TypeOfBody = "Sedan";
            car.Model = "De`Lorian";
            car.EngineSize = 4.00;
            car.HP = 365;
            Console.WriteLine("Создали экземпляр родительского класса" );
            car.GetRoar();
            car.AccelerationRate();

            Honda honda = new Honda();
            honda.Model = "Accord";
            honda.TypeOfBody = "Sedan";
            honda.EngineSize = 2.4;
            honda.HP = 211;
            Console.WriteLine("\nСоздали экземпляр класса наследника");
            honda.GetRoar();
            honda.AccelerationRate();

            Car car2 = honda;
            Console.WriteLine("\nСоздали новый экземпляр родительского класса и привели его к типу класса наследника");
            car2.GetRoar();
            car2.AccelerationRate();

            var car3 = new BMW();
            car3.Model = "test";
            car3.TypeOfBody = "Hatchback";
            car3.EngineSize = 3.00;
            car3.HP = 249;

            Car bmw = car3;
            Console.WriteLine("\nСнова создали новый экземпляр родительского класса и привели его к типу класса наследника");
            bmw.GetRoar();
            bmw.AccelerationRate();



            Console.ReadLine();
        }
    }
}
