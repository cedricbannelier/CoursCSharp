using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> entreesUtilisateur = new List<string>();
            string Saisie;
            do
            {
                Console.WriteLine("Saisir une chaine de caractère");
                Saisie = Console.ReadLine();
                entreesUtilisateur.Add(Saisie);
            } while (Saisie != "");


            foreach (string i in entreesUtilisateur)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
