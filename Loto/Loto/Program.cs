using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd1 = new Random(); // Instance du random
            int[] Tab = new int[48]; // Création du tableau

            int nbAleatoire = rnd1.Next(1, 50);

            


            int cpt = 0;

            do
            {
                cpt = 0;
                for (int i = 0; i < Tab.Length; i++)
                {
                    for (int j = Tab.Length - 1; j >= 0; j--)
                    {
                        if (i != j)
                        {
                            if (Tab[i] == Tab[j])
                            {
                                nbAleatoire = rnd1.Next(1, 50);
                                Tab[i] = nbAleatoire;
                                cpt++;
                            }
                        }
                        if (Tab[i]==0)
                        {
                            Tab[i] = nbAleatoire;
                        }
                    }
                }
            } while (cpt != 0);

            // Lecture du tableau
            for (int i = 0; i < Tab.Length; i++)
            {
                Console.WriteLine("Position : {0}", Tab[i]);
            }
            Console.ReadKey();
        }
    }
}
