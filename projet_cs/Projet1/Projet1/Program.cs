using System;
using System.Diagnostics;

namespace Projet1
{ 
    internal class Program
    {
        static string DemandePrenom( int numeroPersonne)
        {
            // DEMANDE PRENOM

            string prenom = "";
            while (prenom == "")
            {
                Console.WriteLine("Comment tu tappelle personne numero " + numeroPersonne + ": ");
                prenom = Console.ReadLine();
                prenom = prenom.Trim();

                if (prenom == "")
                {
                    Console.WriteLine("Erreur : le prenom ne doit pas etres vide");
                }
            }
            return prenom;
        }
        static int DemanderAge( string prenomPersonne)
        {
            // DEMANDE AGE
            int age_int = 0;
            while (age_int <= 0)
            {
                Console.WriteLine("Quelle age a tu " + prenomPersonne + ":");
                string age_str = Console.ReadLine();

                try
                {
                    age_int = int.Parse(age_str);
                    if (age_int < 0)
                    {
                        Console.WriteLine("L'âge ne doit pas etres négatif");
                    }
                    else if (age_int == 0)
                    {
                        Console.WriteLine("L'âge ne doit pas êtres égale à zéro");
                    }
                }
                catch
                {
                    Console.WriteLine("Erreur la valeur n'est pas valide");
                }
            }
            return age_int;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //DEMANDE PRENOM
            string prenom1 = DemandePrenom(1); 
            string prenom2 = DemandePrenom(2);
            
            for (int i = 0; i < 6; i++)
            {
                Console.Write(prenom1[i]);
            }
            

            //DEMANDE AGE
            Console.WriteLine();
            int age1 = DemanderAge(prenom1);
            int age2 = DemanderAge(prenom2);

            // ON AFFICHE LE RESULTAT
            Console.WriteLine("Vous vous apellez " + prenom1+ " et vous avez " + age1 + " ans");
            Console.WriteLine("Bientot vous avez " + (age1 + 1) + " ans");

            Console.WriteLine("Vous vous apellez " + prenom2+ " et vous avez " + age2 + " ans");
            Console.WriteLine("Bientot vous avez " + (age2 + 1) + " ans");

        }
    }
}
