using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Exercice1_Web.Models;

namespace Exercice1_Web.Controllers
{
    public class OperationController : Controller
    {
        private const string SqlConnectionString = @"Server=.\SQLExpress;Initial Catalog=Exo2; Trusted_Connection=Yes";

        public ActionResult TypeOperationURL(string Operateur, double OperandeDroite, double OperandeGauche)
        {
            Operation operationSaisie = new Operation(ChaineUrl(Operateur), OperandeDroite, OperandeGauche);
            SauvegarderBdd(operationSaisie);
            return View(operationSaisie);
        }
        public ActionResult Toutes()
        {
            List<Operation> HistoriqueEnBDD = RecupererOperationsEnBDD();

            return View(HistoriqueEnBDD);
        }

        public ActionResult Historique(int PrimaryKey)
        {
            Operation HistoriqueEnBDD = HistoriqueOperationEnBDD(PrimaryKey);

            return View(HistoriqueEnBDD);
        }
        static void SauvegarderBdd(Operation operationASauvegarder)
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand command = new SqlCommand(@"INSERT INTO Operations(Operateur, OperandeDroite, OperandeGauche) VALUES (@operateur, @droite, @gauche)", connexion);
            command.Parameters.AddWithValue("@operateur", TraduireTypeOperateurEnOperateurBDD(operationASauvegarder.Operateur));
            command.Parameters.AddWithValue("@droite", operationASauvegarder.OperandeDroite);
            command.Parameters.AddWithValue("@gauche", operationASauvegarder.OperandeGauche);
            command.ExecuteNonQuery();
            connexion.Close();
        }

        static List<Operation> RecupererOperationsEnBDD()
        {
            List<Operation> resultats = new List<Operation>();
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();
            SqlCommand command = new SqlCommand("SELECT Operateur, OperandeDroite, OperandeGauche FROM Operations", connexion);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string operateurBdd = reader.GetString(0);
                double droiteBdd = reader.GetFloat(1);
                double gaucheBdd = reader.GetFloat(2);
                TypeOperateur operateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurBdd);
                Operation operationLue = new Operation(operateur, droiteBdd, gaucheBdd);
                resultats.Add(operationLue);
            }
            connexion.Close();
            return resultats;
        }
        static Operation HistoriqueOperationEnBDD(int PrimaryKey)
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();
            SqlCommand command = new SqlCommand("SELECT Operateur, OperandeDroite, OperandeGauche FROM Operations WHERE numOperation=@id", connexion);
            var numOperationParameter = new SqlParameter("@id", PrimaryKey);
            command.Parameters.Add(numOperationParameter);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string operateurBdd = reader.GetString(0);
            double droiteBdd = reader.GetFloat(1);
            double gaucheBdd = reader.GetFloat(2);
            TypeOperateur operateur = TraduireChaineDeCaractèreEnTypeOperateur(operateurBdd);
            Operation operationLue = new Operation(operateur, droiteBdd, gaucheBdd);
            connexion.Close();
            return operationLue;
        }
        static TypeOperateur TraduireChaineDeCaractèreEnTypeOperateur(string saisieUtilisateur)
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
        static char TraduireTypeOperateurEnOperateurBDD(TypeOperateur typeOperateur)
        {
            switch (typeOperateur)
            {
                case TypeOperateur.Multiplication:
                    return '*';
                case TypeOperateur.Addition:
                    return '+';
                case TypeOperateur.Soustraction:
                    return '-';
                case TypeOperateur.Division:
                    return '/';
                case TypeOperateur.Puissance:
                    return '^';
                default:
                    return ' ';
            }
        }
        static TypeOperateur ChaineUrl(string saisieUtilisateur)
        {
            switch (saisieUtilisateur)
            {
                case "Addition":
                    return TypeOperateur.Addition;
                case "Soustraction":
                    return TypeOperateur.Soustraction;
                case "Multiplication":
                    return TypeOperateur.Multiplication;
                case "Division":
                    return TypeOperateur.Division;
                case "Puissance":
                    return TypeOperateur.Puissance;
                default:
                    return TypeOperateur.Inconnu;
            }
        }
        //private Operation RecupererPageIndexDepuisBDD()
        //{
        //    SqlConnection connexion = new SqlConnection(SqlConnectionString);
        //    connexion.Open();

        //    SqlCommand recuperationNombreOperations = new SqlCommand("SELECT Operateur, OperandeDroite, OperandeGauche FROM Operations", connexion);
        //    int nombreOperations = (int)recuperationNombreOperations.ExecuteScalar();

        //    connexion.Close();

        //    Operation model = new Operation(Operateur, operandeDroite, OperandeGauche);
        //    model.NombreAdditions = nombreAdditions;
        //    model.NombreOperations = nombreOperations;
        //    return model;
        //}

        //public ActionResult Index()
        //{
        //    Models.PageIndexModels model = new Models.PageIndexModels();
        //    int compteurTotalOperations = GetCompteurTotalOperationsEnBDD();
        //    model.CompteurTotalOperations = compteurTotalOperations;

        //    List<Models.PageIndexSousModelCompteur> sousCompteurs = GetSousCompteurFromBDD();
        //    model.SousCompteurs = sousCompteurs;
        //    return View(model);
        //}

        private int GetCompteurTotalOperationsEnBDD()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand recuperationCompteurTotal = new SqlCommand("SELECT COUNT(*) FROM Operations", connexion);
            int compteurTotal = (int)recuperationCompteurTotal.ExecuteScalar();

            connexion.Close();

            return compteurTotal;
        }

        //private List<Operation> RecupererOperationsBDD()
        //{
        //    SqlConnection connexion = new SqlConnection(SqlConnectionString);
        //    connexion.Open();

        //    SqlCommand recuperationOperateur = new SqlCommand("SELECT Operateur FROM Operations", connexion);


        //    connexion.Close();

        //}

        //private List<Models.PageIndexSousModelCompteur> GetSousCompteurFromBDD()
        //{
        //    SqlConnection connexion = new SqlConnection(SqlConnectionString);
        //    connexion.Open();

        //    SqlCommand recupererSousCompteurs = new SqlCommand("SELECT Operateur, COUNT(numOperation) FROM Operations GROUP BY Operateur", connexion);
        //    SqlDataReader reader = recupererSousCompteurs.ExecuteReader();

        //    List<Models.PageIndexSousModelCompteur> resultats = new List<Models.PageIndexSousModelCompteur>();

        //    while (reader.Read())
        //    {
        //        string typeOperateurBDD = reader.GetString(0);
        //        int nombreOperationsBDD = reader.GetInt32(1);

        //        PageIndexSousModelCompteur sousCompteurCourant = new Models.PageIndexSousModelCompteur();
        //        sousCompteurCourant.NombreOperattions = nombreOperationsBDD;
        //        sousCompteurCourant.TypeOperateur = typeOperateurBDD;


        //    }

        //    connexion.Close();

        //    return compteurTotal;
        public ActionResult TypeOperationURL()
        {
            return View();
        }
    }
}
