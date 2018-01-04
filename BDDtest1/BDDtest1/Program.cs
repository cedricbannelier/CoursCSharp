﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication2
{
    //Connection à la base de donnée
    private static string SqlConnectionString = @"Server=.\SQLExpress;Database=Exo2;Trusted_Connection=Yes";

    /// <summary>
    /// Enumeration représentant les types d'opération gérées dans le système
    /// </summary>
    enum TypeOperateur
    {
        Multiplication,
        Addition,
        Soustraction,
        Division,
        Puissance,
        Inconnu
    }
    /// <summary>
    /// Classe permettant de manipuler une opération
    /// </summary>
    class Operation
    {
        /// <summary>
        /// Opérateur de l'opération
        /// </summary>
        public TypeOperateur Operateur { get; private set; }

        /// <summary>
        /// Opérande de droite de l'opération
        /// </summary>
        public double OperandeDroite { get; private set; }

        /// <summary>
        /// Opérande de gauche de l'opération
        /// </summary>
        public double OperandeGauche { get; private set; }

        /// <summary>
        /// Constructeur paramétré
        /// 
        /// Permet de construire une opération à partir de son opérateur, son opérande de droite et de gauche
        /// </summary>
        /// <param name="operateur">opérateur de l'opération</param>
        /// <param name="operandeDroite">opérande de droite de l'opération</param>
        /// <param name="operandeGauche">opérande de gauche de l'opération</param>
        public Operation(TypeOperateur operateur, double operandeDroite, double operandeGauche)
        {
            this.Operateur = operateur;
            this.OperandeDroite = operandeDroite;
            this.OperandeGauche = operandeGauche;
        }

        /// <summary>
        /// Méthode permettant de déterminer si l'opération courante est valide ou non.
        /// Si elle ne l'est pas, la détermination du résultat pourrait crasher.
        /// </summary>
        /// <returns>vrai si l'opération est valide, false sinon</returns>
        public bool IsValide()
        {
            if (this.Operateur == TypeOperateur.Division && this.OperandeDroite == 0.0)
            {
                return false;
            }
            if (this.Operateur == TypeOperateur.Puissance && this.OperandeGauche < 0 && this.OperandeDroite < 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Récupération d'une représentation textuelle lisible par l'utilisateur de l'opération
        /// </summary>
        /// <returns>Représentation textuelle</returns>
        public string GetRepresentationTextuelle()
        {
            return string.Format("Résultat de {0} de {1} et {2} = {3}", this.Operateur, this.OperandeGauche, this.OperandeDroite, this.GetResult());
        }

        /// <summary>
        /// Récupération du résultat de l'opération
        /// </summary>
        /// <returns>récupération du résultat</returns>
        public double GetResult()
        {
            switch (this.Operateur)
            {
                case TypeOperateur.Multiplication:
                    return this.OperandeGauche * this.OperandeDroite;
                case TypeOperateur.Addition:
                    return this.OperandeGauche + this.OperandeDroite;
                case TypeOperateur.Soustraction:
                    return this.OperandeGauche - this.OperandeDroite;
                case TypeOperateur.Division:
                    return this.OperandeGauche / this.OperandeDroite;
                case TypeOperateur.Puissance:
                    return Math.Pow(this.OperandeGauche, this.OperandeDroite);
                default:
                    return 0;
            }
        }
    }

    class Program
    {
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
                else
                {
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