using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication2
{
    /// <summary>
    /// Enumeration représentant les types d'opération gérées dans le système
    /// </summary>
    
    /// <summary>
    /// Classe permettant de manipuler une opération
    /// </summary>
    

    class Program
    {
        //Connection à la base de donnée
        #region Constantes
        private static string SqlConnectionString = @"Server=.\SQLExpress;Database=Exo2;Trusted_Connection=Yes";
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenu sur la calculatrice");

            List<Operation> operationsSaisies = new List<Operation>();

            bool shouldContinue = true;
            while (shouldContinue)
            {

                string saisieOperateur = DemandeQuelquechose("Operateur : ");
                TypeOperateur operateur = TraduireSaisieUtilisateurOperateur(saisieOperateur);

                if (operateur == TypeOperateur.Inconnu)
                {
                    shouldContinue = false;
                }
                else {
                    string saisieGauche = DemandeQuelquechose("Gauche : ");
                    string saisieDroite = DemandeQuelquechose("Droite : ");

                    double valeurGauche = TraduireSaisieUtilisateurNombre(saisieGauche);
                    double valeurDroite = TraduireSaisieUtilisateurNombre(saisieDroite);

                    Operation operationSaisie = new Operation(operateur, valeurDroite, valeurGauche);

                    if (operationSaisie.IsValide())
                    {
                        operationsSaisies.Add(operationSaisie);
                        Console.WriteLine(operationSaisie.GetRepresentationTextuelle());
                    }
                    else
                    {
                        Console.WriteLine("Nope !");
                    }
                }
            }

            AfficherHistorique(operationsSaisies);

            Console.ReadLine();
        }

      
        static string DemandeQuelquechose(string texteAAfficher)
        {
            Console.Write(texteAAfficher);
            string saisieGauche = Console.ReadLine();
            return saisieGauche;
        }
        private static void AfficherHistorique(List<Operation> historiqueSaisies)
        {
            foreach (Operation operationCourante in historiqueSaisies)
            {
                Console.WriteLine(operationCourante.GetRepresentationTextuelle());
            }
        }

        static double TraduireSaisieUtilisateurNombre(string saisieUtilisateur)
        {
            return double.Parse(saisieUtilisateur, CultureInfo.InvariantCulture);
        }


        static TypeOperateur TraduireSaisieUtilisateurOperateur(string saisieUtilisateur)
        {
            switch (saisieUtilisateur)
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
                    return TypeOperateur.Inconnu;
            }
        }
    }
}
