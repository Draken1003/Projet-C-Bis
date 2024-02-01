using System;

namespace ProjetTest
{
    internal class Class1
    {
       
        private Class2 _class = new Class2(); // Initialisation de _class avec une instance de Class2

        public static void Main(string[] args)
        {
            Class2 myClass = new Class2(); //cream obiect din clasa primului fisier
            Console.Write(myClass.Class1); //apel functie myFunction() din fis1.cs
        }
    }
}
