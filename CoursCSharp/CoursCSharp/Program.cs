using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursCSharp
{
    enum TypeOperateur
    {
        Addition,
        Soustraction,
        Multiplication,
        Division,
        Puissance,
        OperateurNonReconnu,
    }
    class Operation
    {
        public TypeOperateur _operateur;
        public int _nombreA;
        public int _nombreB;
        public Double GetResult()
        {
            while (this._operateur != TypeOperateur.OperateurNonReconnu)
            {
                switch (this._operateur)
                {
                    case TypeOperateur.Addition:
                        return (this._nombreA + this._nombreB);
                    case TypeOperateur.Soustraction:
                        return (this._nombreA - this._nombreB);
                    case TypeOperateur.Multiplication:
                        return (this._nombreA * this._nombreB);
                    case TypeOperateur.Division:
                        if (this._nombreB == 0)
                        {
                            return 0;
                        }
                        return (this._nombreA / this._nombreB);
                    case TypeOperateur.Puissance:
                        if (this._nombreB < 0)
                        {
                            return 0;
                        }

                        return Math.Pow(this._nombreA, this._nombreB);
                    case TypeOperateur.OperateurNonReconnu:
                        return 0;
                    default:
                        return 0;
                }

            }
            return 0;
        }
    }
    class Program
    {
        static int DemanderSaisieNombreEnAffichantUnMessage(string messageAAfficherALutilisateur)
        {
            Console.WriteLine(messageAAfficherALutilisateur);
            return Int32.Parse(Console.ReadLine());
        }
        static TypeOperateur DemanderSaisieOperateurEnAffichantUnMessage(string message)
        {
            Console.WriteLine(message);
            string saisieOperateur = Console.ReadLine();

            switch (saisieOperateur)
            {
                case "+":
                    return TypeOperateur.Addition;
                case "-":
                    return TypeOperateur.Soustraction;
                case "*":
                    return TypeOperateur.Multiplication;
                case "/":
                    return TypeOperateur.Division;
                case "^":
                    return TypeOperateur.Puissance;
                default:
                    return TypeOperateur.OperateurNonReconnu;
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
        static void AfficheHistorique(List<Operation> listeDesOperationsAAfficher)
        {
            foreach (Operation i in listeDesOperationsAAfficher)
            {
                Console.WriteLine(i._nombreA + " " + i._operateur + " " + i._nombreB);
            }
        }
        static void Main(string[] args)
        {
            Operation monOperation;
            List<Operation> historique = new List<Operation>();
            do
            {
                //Appel de la méthode DemanderSaisieOperateurEnAffichantUnMessage
                TypeOperateur saisieOperateur = DemanderSaisieOperateurEnAffichantUnMessage("Veuillez choisir votre opérateur : +, -, *, /, ^");

                //Appel de la méthode DemanderSaisieNombreEnAffichantUnMessage
                int nombreA = DemanderSaisieNombreEnAffichantUnMessage("Veuillez saisir le premier nombre entier");
                int nombreB = DemanderSaisieNombreEnAffichantUnMessage("Veuillez saisir le second nombre entier");

                monOperation = new Operation();
                monOperation._operateur = saisieOperateur;
                monOperation._nombreA = nombreA;
                monOperation._nombreB = nombreB;

                if (monOperation._nombreB != 0 || monOperation._operateur != TypeOperateur.Division)
                {
                    double afficheResultat = monOperation.GetResult();
                    historique.Add(monOperation);
                    Console.WriteLine("Le resultat est {0}", afficheResultat);
                }
                else
                {
                    Console.WriteLine("Divison impossible");
                }
            } while (monOperation._operateur != TypeOperateur.OperateurNonReconnu);
            AfficheHistorique(historique);
            Console.ReadKey();
        }
    }
}