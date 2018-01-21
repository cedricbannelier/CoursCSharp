using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo2
{
    class Program
    {
        class Personnage
        {
            public string _pseudo;
            public int _pointDeVie;
            public int _pointDeDegat;
            public int _valeurDattaque;

            public void InitPersonnage()
            {
                this._pointDeVie = 20;
                this._pointDeDegat = 4;
                this._valeurDattaque = 60;
            }
            public void PrendreDesDegats(int degat)
            {
                this._pointDeVie = this._pointDeVie - degat;
            }

        }
        static void Main(string[] args)
        {
            Random rnd1 = new Random();

            Console.WriteLine("*** Bienvenue dans le jeu le plus original du monde !!!!! ***\n\n");

            //Demande le pseudo
            Console.WriteLine("Choisir votre pseudo de votre personnage");
            string pseudo = Console.ReadLine();

            //Instance de la class Personnage (Objet)
            Personnage personnagePrincipal = new Personnage();

            //Affecte la valer de pseudo au personnageprincipal dans _pseudo
            personnagePrincipal._pseudo = pseudo;

            //Appel de la méthode pour init les caractérisque
            personnagePrincipal.InitPersonnage();

            //Affiche les caractéristiques du personnage
            Console.WriteLine("Nom du personnage : {0}\nPoint de vie : {1}", personnagePrincipal._pseudo, personnagePrincipal._pointDeVie);
            Console.WriteLine("Point de dégat : {0}\nValeur d'attaque : {1}", personnagePrincipal._pointDeDegat, personnagePrincipal._valeurDattaque);

            Personnage personnageEnnemie = new Personnage();
            personnageEnnemie._pseudo = "Adrien";
            personnageEnnemie.InitPersonnage();

            int jetDe = rnd1.Next(0, 101);

            

            do
            {
                jetDe = rnd1.Next(0, 101);
                if (jetDe <= personnagePrincipal._valeurDattaque && jetDe > 50)
                {
                    Console.WriteLine("Esquive {0}",jetDe);
                }
                else if (jetDe <= personnagePrincipal._valeurDattaque)
                {
                    personnageEnnemie.PrendreDesDegats(personnagePrincipal._pointDeDegat);
                    Console.WriteLine("{0} a touché {1}, le jet de dés a fait {2} ", personnagePrincipal._pseudo, personnageEnnemie._pseudo, jetDe);
                    Console.WriteLine("{0} il te reste {1}", personnageEnnemie._pseudo, personnageEnnemie._pointDeVie);
                }
                                
                else
                {
                    Console.WriteLine("{0} a loupé {1}", personnagePrincipal._pseudo, personnageEnnemie._pseudo);
                }
                Console.ReadKey();
                if (personnageEnnemie._pointDeVie<=0)
                {
                    break;
                }

                jetDe = rnd1.Next(0, 101);
                if (jetDe <= personnageEnnemie._valeurDattaque)
                {
                    personnagePrincipal.PrendreDesDegats(personnageEnnemie._pointDeDegat);
                    Console.WriteLine("{0} a touché {1}, le jet de dés a fait {2} ", personnageEnnemie._pseudo, personnagePrincipal._pseudo, jetDe);
                    Console.WriteLine("{0} il te reste {1}", personnagePrincipal._pseudo, personnagePrincipal._pointDeVie);
                }
                else
                {
                    Console.WriteLine("{1} a loupé {0}", personnagePrincipal._pseudo, personnageEnnemie._pseudo);
                }
                Console.ReadKey();
            } while (!(personnageEnnemie._pointDeVie <= 0 || personnagePrincipal._pointDeVie <=0));






            Console.ReadKey();
        }
    }
}
