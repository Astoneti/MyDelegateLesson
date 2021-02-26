using System;

namespace MyDelegateLesson
{//Делегат мы можем объявить как глобально так и в классе.
    //Объявление делегата:
    //модификатор доступа_ключевое слово delegate_тип возвращаемого значения_имя делегата(тип аргумента и аргумент);

    public delegate void MyDelegate();
    class Program
    {
        //Создаем пример объявления делегата c аргументамит внутри класса с последующей его риализацией 

        public delegate int RandomValuesDelegate(int i);

        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1; //так мы вызываем Метод1
            myDelegate += Method4;// здесь используя (+=) мы добавляем Метод4 для вызова и так можно добавить сколько угодно!
            myDelegate();//Первый вариант вызова делегата!!!вызываем уже метод (myDelegate();) который уже в консоль выведет значение метода1 и метода4 одновременно!!!
            Console.WriteLine(new string('*',21));

            MyDelegate myDelegate2 = new MyDelegate(Method4); // Второй вариант вызова делегата с использованием(Invoke();).
            myDelegate2 += Method4;

            /*myDelegate2 -= Method4;*/  // так мы используя (-=) можем удалить любой из методов делегата!
            myDelegate.Invoke();

            MyDelegate myDelegate3 = myDelegate + myDelegate2;//так мы можем создать новый делегат объеденив в его старые делегаты с их методами!
            myDelegate3.Invoke();
            Console.WriteLine(new string('*', 21));

            //Объявляем новый делегат для реализации делегата с аргументами из класса

            RandomValuesDelegate valueDelegate = new RandomValuesDelegate (GetRandomValues);

            valueDelegate += GetRandomValues;  // таким образом мы передаем случайное число во все методы а не получаем разово значение последнего метода делегата!!!
            valueDelegate += GetRandomValues;
            valueDelegate += GetRandomValues;
            valueDelegate += GetRandomValues;

            valueDelegate((new Random()).Next(10, 100));//Будем использовать метод рандом для заполнение делегата сгенирированными числами
            Console.ReadLine();
        }

        public static void Method1() //Метод с одинаковым аргументом
        { 
            Console.WriteLine($"\nMy delegate Method 1");
        }

        public static void Method2(int i)  //Метод с разной сигнатурой
        {
            Console.WriteLine($"\nMy delegate Method 2");
        }

        public static int Method3()   //Метод с разной сигнатурой
        {
            Console.WriteLine($"\nMy delegate Method 3");
            return 0;
        }

        public static void Method4()  //Метод с одинаковым аргументом
        {
            Console.WriteLine($"\nMy delegate Method 4");
        }

        public static int GetRandomValues(int i) // метод для делегата внутри класса
        {
            Console.WriteLine(i);
            return i;
        }
    }
}
