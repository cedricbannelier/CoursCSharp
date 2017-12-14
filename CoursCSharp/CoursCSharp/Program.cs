using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursCSharp
{
    class Program
    {
        enum Operations
        {
            Addition,
            Soustraction,
            Multiplication,
            Division,
            Puissance,
            OperateurNonReconnu,
        }
        static int DemanderSaisieNombreEnAffichantUnMessage(string messageAAfficherALutilisateur)
        {
            Console.WriteLine(messageAAfficherALutilisateur);
            return Int32.Parse(Console.ReadLine());
        }
        static Operations DemanderSaisieOperateurEnAffichantUnMessage(string message)
        {
            Console.WriteLine(message);
            string saisieOperateur = Console.ReadLine();
            switch (saisieOperateur)
            {
                case "+":
                    return Operations.Addition;
                    break;
                case "-":
                    return Operations.Soustraction;
                    break;
                case "*":
                    return Operations.Multiplication;
                    break;
                case "/":
                    return Operations.Division;
                    break;
                case "^":
                    return Operations.Puissance;
                    break;
                default:
                    return Operations.OperateurNonReconnu;
            }

        }
        static int Addition(int nombreA, int nombreB)
        {
            return nombreA + nombreB;
        }
        static int Soustraction(int nombreA, int nombreB)
        {
            return nombreA - nombreB;
        }
        static int Multiplication(int nombreA, int nombreB)
        {
            return nombreA * nombreB;
        }
        static int Division(int nombreA, int nombreB)
        {
            return nombreA / nombreB;
        }
        static double Puissance(int nombreA, int nombreB)
        {
            return Math.Pow(nombreA, nombreB);
        }
        static void Main(string[] args)
        {
            int refaire = 1;

            do
            {
                //Appel de la méthode DemanderSaisieOperateurEnAffichantUnMessage
                Operations saisieOperateur = DemanderSaisieOperateurEnAffichantUnMessage("Veuillez choisir votre opérateur : +, -, *, /, ^");

                //Appel de la méthode DemanderSaisieNombreEnAffichantUnMessage
                int nombreA = DemanderSaisieNombreEnAffichantUnMessage("Veuillez saisir le premier nombre entier");
                int nombreB = DemanderSaisieNombreEnAffichantUnMessage("Veuillez saisir le second nombre entier");

                if (nombreA == 0 && nombreB == 0)
                {
                    Console.WriteLine("Aucun calcul possible");
                }
                else
                {
                    switch (saisieOperateur)
                    {
                        case Operations.Addition:
                            Console.WriteLine("Addition " + nombreA + " + " + nombreB + " = " + (Addition(nombreA, nombreB)));
                            break;
                        case Operations.Soustraction:
                            Console.WriteLine("Soustraction " + nombreA + " - " + nombreB + " = " + (Soustraction(nombreA, nombreB)));
                            break;
                        case Operations.Multiplication:
                            Console.WriteLine("Multiplication " + nombreA + " * " + nombreB + " = " + (Multiplication(nombreA, nombreB)));
                            break;
                        case Operations.Division:
                            if (nombreB == 0)
                            {
                                Console.WriteLine("Division impossible par 0");
                            }
                            else
                            {
                                Console.WriteLine("Division " + nombreA + " / " + nombreB + " = " + (Division(nombreA, nombreB)));
                            }
                            break;
                        case Operations.Puissance:
                            if (nombreB < 0)
                            {
                                Console.WriteLine("Puissance impossible");
                            }
                            else
                            {
                                Console.WriteLine("Puissance " + nombreA + " ^ " + nombreB + " = " + (Puissance(nombreA, nombreB)));
                            }
                            break;
                    }
                }
                Console.WriteLine("Voullez-vous refaire un calcul : 1 -> refaire | 0 -> Quitter?");
                refaire = Int32.Parse(Console.ReadLine());
                while (refaire < 0 || refaire > 1)
                {
                    Console.WriteLine("Voullez-vous refaire un calcul : 1 -> refaire | 0 -> Quitter?");
                    refaire = Int32.Parse(Console.ReadLine());
                }
                //                Console.ReadKey();

            } while (refaire == 1);
        }
    }
}