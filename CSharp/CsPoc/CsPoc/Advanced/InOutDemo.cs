using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class InOutDemo
    {
        public static void RUN()
        {
            Dog aDog = new Dog();
            Animal aAnimal = aDog;

            List<Dog> lstDogs = new List<Dog>();
            //List<Animal> lstAnimals = lstDogs;

            List<Animal> lstAnimals2 = lstDogs.Select(d => (Animal)d).ToList();

            IEnumerable<Dog> someDogs = new List<Dog>();
            IEnumerable<Animal> someAnimals = someDogs;
            //List<Animal> lstAnimals3 = (List<Animal>)someAnimals;

            Action<Animal> actionAnimal = new Action<Animal>(a => { a.bark(); });
            Action<Dog> actionDog = actionAnimal;
            actionDog(aDog);

            IMyList<Dog> mylstDogs = new MyList<Dog>();
            IMyList<Animal> mylstAnimals = mylstDogs;


            IInList<Animal> myListAnimals = new MyInList<Animal>();
            IInList<Dog> myListDogs = myListAnimals;

        }
    }

    public class Animal
    {
        virtual public void bark()
        {
            Console.WriteLine("Animal");
        }
    }

    public class Dog : Animal
    {
        public override void bark()
        {
            Console.WriteLine("Dog");
        }
    }

    public interface IMyList<out T>
    {
        T GetElement();

    }

    public class MyList<T> : IMyList<T> 
    {
        public T GetElement()
        {
            return default(T);
        }

    }

    public interface IInList<in T>
    {
        void Change(T t);
    }

    public class MyInList<T>:IInList<T>
    {
        public void Change(T t)
        { 
        }
    }
}
