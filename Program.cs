using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApplication1
{
   
    class Program 
    {
       
        class State { public string Name { get; set; } }
        public static void Dosomething(int param) {  }
        private static Func<State, bool> ChekName()
        {
            return p => p.Name == "F";
        }
        static void ChangeNumber(ref int number)
        {
            number = 100;
        }
      
        static void Main(string[] args)
        {

            Delete.B obj = new Delete.B();
            obj.test();
            Delete.B objdelA = new Delete.B();
            objdelA.test1();
            Delete.B B = new Delete.B();
            //B.X=10;//error
          

            Delegates.Base bggt = new Delegates.Deri();

            Delegates.PrivateProperty exm = new Delegates.PrivateProperty();

            Debug.WriteLine(exm.IsFound);
            Tester Olli = new Tester("Olli", 4, TesterFavoriteTasks.SystemTesting);
            

            Developer Tom = new Developer("Tom", 3, DeveloperFavoriteTasks.UnitTesting, false);

            Developer Sam = ChangeYearsOfExperience(Tom);

            Debug.WriteLine(Tom == Sam);
            Sam.DoWork();
            //test
             
            List<State> statesList = new List<State>();
            statesList.Add(new State { Name = "A" });
            statesList.Add(new State { Name = "B" });
            statesList.Add(new State { Name = "C" });
            statesList.Add(new State { Name = "D" });
            statesList.Add(new State { Name = "E" });
            statesList.Add(new State { Name = "F" });
            var t = statesList.Where(s => s.Name == "A" || s.Name == "D").Take(1).ToList();
            var t1 = statesList.Where(s => s.Name == "A" || s.Name == "D");
            var car = new Practices1.Car { MaxSpeed = 20 };
            car.Drive();
            Practices1.Vehicle vh = new Practices1.Car { MaxSpeed = 29 };
            vh.Drive();

            for (int i = 0; i < statesList.Count; i++)
            {
                Console.WriteLine(statesList[i] + " ");
                statesList.RemoveAt(i);
            }

            var list = new[] { "A", "B", "C", "D", "E" };
            var half = list.Where((x, i) => i < 3).ToList();
            var lst = Enumerable.Range(1, 10).ToList();
            lst.ForEach(Dosomething);

            var car2 = new Practices2.Car(200, "Manual");
            Debug.WriteLine(string.Format("max speed is {0} , country is {1}", car2.MaxSpeed, Practices2.Vehicle.Country));
            //IQueryable<State> staes = from p in obj.Where(ChekName()) select p; //dont work
            var staes1 = from p in statesList.Where(ChekName()) select p;
            Practices2.Shape circle = new Practices2.Circle
            {
                Radius=10, Color="Red"                    
            };
            circle.Draw();
            int number = 50;
            ChangeNumber(ref number);
            Debug.WriteLine(number);
            //dynamic objdyn = new dynamic();
            //objdyn.City = "Test";
            //dynamic objdyn1 = new { City = "Manish" }; // this statement alone won't give error but with below statement would
            //objdyn1.City = "NewYork";

            dynamic obj1 = new System.Dynamic.ExpandoObject();
            obj1.City = 1;
            obj1.City = "NY";

            //Console.WriteLine(obj.City);
            var tttt = new  { City = "New York" };
            Console.WriteLine(tttt.City);
            Console.WriteLine(obj1.City);
           
            string weather="rainy";
            Practices2.Forecast.ChangetheString(weather);
            Debug.WriteLine("The weather is " + weather);
            string[] RainyDys= new []{"monday", "friday"};
            Practices2.Forecast.ChangeArray(RainyDys);
            Debug.WriteLine("The rainy days are " + RainyDys[0] + " and " + RainyDys[1]);
            Practices2.SForecast fore= new Practices2.SForecast{ Pressue=700, Temprature=20};
            Practices2.Forecast.ChangetheStructure(fore);
             Debug.WriteLine("The temprature is " + fore.Temprature);



             var S = new List<int>();
             for (int i = 0; i < 10; i++)
                 S.Add(i);
                    for(int i=0;i<S.Count;i++)
                    {
                        Debug.WriteLine(S[i] +" ");
                        S.RemoveAt(i);
                    }

                    Delegates.Utility.Do(1);
            //test





            DateTime dat = Convert.ToDateTime("13-Mar-2014 12:49");

            List<CustomTime> objLocal;

            objLocal = (TimeZoneConverter.TimeZones.FindAll(x => (x.Id.Equals("Eastern Standard Time") || x.Id.Equals("Central Standard Time") || x.Id.Equals("US Mountain Standard Time")
                || x.Id.Equals("Mountain Standard Time") || x.Id.Equals("Pacific Standard Time") || x.Id.Equals("Alaskan Standard Time") || x.Id.Equals("UTC-11"))));

            TimeZoneConverter.ConvertTime(dat, objLocal[1].Id);
            //TimeZoneInfo.ConvertTimeFromUtc(dat.ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById(""));

            ///big daddt
            ///

            TimeZoneConverter.TimeZones.ForEach((time) => { Console.WriteLine(time.DisplayName + "  " + time.UTC); });

            ExcelWriter.ExcelWriter.CreateExcelTemplate("testmanish.xls");
           for(int j=0;j<7000;j++)
            for(int col=0;col<63;col++)
                ExcelWriter.ExcelWriter.WriteContent(j+4, col, "Manish");// remember the starting row is 4

            ExcelWriter.ExcelWriter.WriteToFile(@"D:\testmanish.xls");
           


        }

        
        private static Developer ChangeYearsOfExperience(Developer developer)
        {
            developer.YearsOfExperience = 12;
            return developer;

        }



       
}


public enum JobProfile{developer,tester}
public enum TesterFavoriteTasks{ManualTesting,AutomationTesting,SystemTesting}
public enum DeveloperFavoriteTasks{BusinessLogic,Database,UnitTesting}

public interface IEngineer{void DoWork();}

public abstract class Engineer : IEngineer 
{
   protected string Name;
   protected bool Female;
   public int YearsOfExperience;

   public abstract void DoWork();

   public Engineer(string name, int yearsOfExperience, bool female)
   {
          Name = name;
          YearsOfExperience = yearsOfExperience;
          Female = female;
       
   }

   protected void SayHello(JobProfile jobProfile, Enum FavoritWorkArea)
   {
     Debug.WriteLine(string.Format("Hi! My name is {0}, I am a {1} {2} with {3} years of experiense.I love to work with {4}!", Name, Female ? "female" : 
      "male",jobProfile, YearsOfExperience, FavoritWorkArea));
   }
}

public class Tester : Engineer
{
    internal TesterFavoriteTasks favoriteTask;

     public Tester(string name, int yearsOfExperience, TesterFavoriteTasks favoriteTask, bool female = true)
             : base(name,yearsOfExperience,female){
           this.favoriteTask = favoriteTask;
         
        }
        public override void DoWork()
        {
            SayHello(JobProfile.tester, favoriteTask); 
            
        }
}

public class Developer : Engineer
{
   
    internal DeveloperFavoriteTasks favoriteTask;

    public Developer(string name, int yearsOfExperience, DeveloperFavoriteTasks favoriteTask, bool female = true)
            : base(name, yearsOfExperience, female){
            this.favoriteTask = favoriteTask;
        }
        public override void DoWork()
        {
            SayHello(JobProfile.developer, favoriteTask);

            CreateDatabase();
            CreateBusinessLogic();
            CreateUnitTests();
            WorkCompleted();
        }

        private void CreateDatabase() { }
        internal void CreateBusinessLogic() { }
        public void CreateUnitTests() { }
        protected void WorkCompleted() { Debug.WriteLine("All work done");}
    }
}

namespace Practices
{
    public struct Vehicle
    {
        public int MaxSize;
        public int Age;
    }


    public struct Car //: Vehicle
    {
        public string Transmission { get; set; }
        public int NumberOfDoors { get; set; }
    }

    public abstract class A { }
    public abstract class B : A { }

    public struct test2// cant do :A
    {

    }

    public class Group<T> where T : struct //not Vehicle

    {

    }
    public struct Group1<T>
    {
        List<T> Members { get; set; }

    }
    public interface IPerson
    {
         string Name  { get; set; }
    }
    public interface IGroup<T> where T : class, IPerson, new()
    {

    }
    public class Person
    {
         string Name { get; set; }
    }
    public class H<T> where T:Person
    {
        List<T> Members { get; set; }
    }

}

namespace Practices1
{
    public abstract class Vehicle
    {
        public int MaxSpeed { get; set; }
        public virtual void Drive()
        {
            Console.Write("I am driving ");
        }
    }
    public class Car:Vehicle
    { 
        public override void Drive()
        {
            Console.Write("I am driving Car ");
        }
        
    }
}

namespace Practices2
{
    public class Vehicle
    {
      
        public static string Country;
        public int MaxSpeed;
        public Vehicle(int MaxSpeed)
        {
            this.MaxSpeed = MaxSpeed;
        }
    }
    public class Car : Vehicle
    {
        public string Transmission;
        public Car(int maxspeed, string tran)
            : base(maxspeed)
        {
            this.MaxSpeed = 100;
            this.Transmission = tran;
        }
        static Car()
        {
            Country = "USA";
        }
    }
    public struct Company
    {
        public string CompanyName { get; set; }
    }
    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company c { get; set; }
        public Company1 Employer { get; set; }
    }

    public class Company1
    {
        public string CompanyName { get; set; }
    }

    public class Shape
    {
        public string Color { get; set; }
        public void Draw()
        {
            Debug.WriteLine(string.Format("Drawing the {0} shape", Color));
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

    }
    public struct SForecast
    {
        public int Temprature { get; set; }
        public int Pressue { get; set; }
    }
    public class Forecast
    {
        public static void ChangetheString(string weather) { weather = "sunny"; }
        public static void ChangeArray(string[] rainyDays) { rainyDays[1]="Sunday"; }
        public static void ChangetheStructure(SForecast fore){fore.Temprature=35;}

    }
}

namespace Delegates
{
    abstract class Base
    {
        public abstract void Create();
        public Base()
        {
            Debug.WriteLine("Base called");
            this.Create();
        }
    }
    class Deri : Base
    {
        public Deri()
        {
            Debug.WriteLine("Deri called");
        }
        public override void Create()
        {

        }
    }
   
    public static class Utility
    {

         delegate void DoSomething(Object i);
         //delegate void DoSomething(string i);

         public static void Do(Object i)
         {

         }
         public static void Do(int i)
         {
         }


    }
    class PrivateProperty
    {
        public PrivateProperty()
        {
            // Set the private property.
            this.IsFound = true;
        }
        bool _found;
        public bool IsFound
        {
            get
            {
                return this._found;
            }
            private set
            {
                // Can only be called in this class.
                this._found = value;
            }
        }
    }
    class B
    {
        int x;
    }
    class D : B { }

   

   
   
}

namespace Delete
{
    public class A
    {
        public virtual void test() { }
        public virtual void test1() { }
        protected int X = 0;
    }
    public class B : A
    {
        public new void test() { }
        public override void test1() { this.X = 1; B obj = new B(); obj.X = 0; }
    }


    
    
   
}
