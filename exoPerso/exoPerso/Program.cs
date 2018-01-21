using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exoPerso
{
    class Program
    {

        class Personnage
        {
            public string _pseudo;
            public int _pointDeVie;
            public int _pointAttaque;
            public int _valeurAttaque;

            public void InitPersonnage()
            {
                _pointDeVie = 20;
                _pointAttaque = 4;
                _valeurAttaque = 60;
            }
            public void PrendreDesDegats(int degat)
            {
                this._pointDeVie = this._pointDeVie - degat;
            }
        }
        static void Main(string[] args)
        {
            Personnage personnageHumain = new Personnage();
            Personnage personnageOrdi = new Personnage();

            Random rnd1 = new Random();
            Random rnd2 = new Random();

            int jetDe = rnd1.Next(0, 101); //La valeur va de 0 à 100
            int rejouer = 1;

            Console.WriteLine("Entre ton pseudo");
            string pseudoHumain = Console.ReadLine();

            personnageHumain._pseudo = pseudoHumain;


            Console.WriteLine("Entre le pseudo de ton adversaire");
            string pseudoOrdi = Console.ReadLine();

            personnageOrdi._pseudo = pseudoOrdi;
            do
            {
                personnageHumain.InitPersonnage();
                personnageOrdi.InitPersonnage();

                Console.WriteLine("Fiche personnage de : {0}\n", personnageHumain._pseudo);
                Console.WriteLine("Pseudo : {0}\nPoint de vie : {1}\nPoint d'attaque : {2}\nValeur d'attaque : {3}\n", personnageHumain._pseudo, personnageHumain._pointDeVie, personnageHumain._pointAttaque, personnageHumain._valeurAttaque);

                Console.WriteLine("Fiche personnage de : {0}\n", personnageOrdi._pseudo);
                Console.WriteLine("Pseudo : {0}\nPoint de vie : {1}\nPoint d'attaque : {2}\nValeur d'attaque : {3}\n", personnageOrdi._pseudo, personnageOrdi._pointDeVie, personnageOrdi._pointAttaque, personnageOrdi._valeurAttaque);


                while (!(personnageHumain._pointDeVie <= 0 || personnageOrdi._pointDeVie <= 0))
                {
                    jetDe = rnd1.Next(0, 101); //La valeur va de 0 à 100
                    if (jetDe > personnageHumain._valeurAttaque)
                    {
                        //on va oter 4 points de vie à l'adversaire
                        Console.WriteLine("Valeur du jet de dés : {0}", jetDe);
                        Console.WriteLine("{0} attaque {1}", personnageHumain._pseudo, personnageOrdi._pseudo);

                        personnageOrdi.PrendreDesDegats(personnageHumain._pointAttaque);

                        Console.WriteLine("{0} il te reste {1}\n", personnageOrdi._pseudo, personnageOrdi._pointDeVie);
                    }
                    else
                    {
                        Console.WriteLine("Loupé\n");
                    }

                    if (personnageHumain._pointDeVie == 0 || personnageOrdi._pointDeVie == 0)
                    {
                        break;
                    }

                    jetDe = rnd2.Next(0, 101); //La valeur va de 0 à 100
                    if (jetDe > personnageOrdi._valeurAttaque)
                    {
                        //on va oter 4 points de vie à l'adversaire
                        Console.WriteLine("Valeur du jet de dés : {0}", jetDe);
                        Console.WriteLine("{0} attaque {1}", personnageOrdi._pseudo, personnageHumain._pseudo);

                        personnageHumain.PrendreDesDegats(personnageOrdi._pointAttaque);

                        Console.WriteLine("{0} il te reste {1}\n", personnageHumain._pseudo, personnageHumain._pointDeVie);
                    }
                    else
                    {
                        Console.WriteLine("Loupé\n");
                    }

                }
                if (personnageHumain._pointDeVie == 0)
                {
                    Console.WriteLine("{0} a gagné", personnageOrdi._pseudo);
                }
                else
                {
                    Console.WriteLine("{0} a gagné", personnageHumain._pseudo);
                }

                Console.WriteLine("Voulez vous rejouer ? 0 : NON -- 1 : OUI");
                rejouer = Int32.Parse(Console.ReadLine());

            } while (rejouer == 1);




            //           Console.ReadKey();
        }
    }
}
