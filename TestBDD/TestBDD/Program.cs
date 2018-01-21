using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestBDD
{

    class Program
    {

        public class GestionBDD
        {
            public static string SqlConnectString = @"Server=FIXE;Database=Exo1;Trusted_Connection=Yes";

            public static SqlConnection BddConnect = new SqlConnection(SqlConnectString);

            public static void Connection()
            {
                BddConnect.Open();
            }

            public static void Deconnection()
            {
                BddConnect.Close();
            }

            public static void AjoutUtilisateur(string nom, string prenom, string dateNaissance)
            {
                GestionBDD.Connection();
                SqlCommand Inserer = new SqlCommand("INSERT INTO Utilisateur (nom, prenom, dateNaissance) Values (@nom, @prenom, @dateNaissance)", GestionBDD.BddConnect);
                var nomParameter = new SqlParameter("@nom", nom);
                var prenomParamater = new SqlParameter("@prenom", prenom);
                var dateNaissanceParameter = new SqlParameter("@dateNaissance", dateNaissance);
                Inserer.Parameters.Add(nomParameter);
                Inserer.Parameters.Add(prenomParamater);
                Inserer.Parameters.Add(dateNaissanceParameter);
                Inserer.ExecuteNonQuery();
                GestionBDD.Deconnection();
            }
            public static List<string> AfficherListeEnBdd()
            {

                List<string> ListeEnBdd = new List<string>();

                GestionBDD.Connection();
                SqlCommand AffichierListeEnBdd = new SqlCommand("SELECT * FROM Utilisateur)", GestionBDD.BddConnect);
                SqlDataReader RecupereListeEnBdd = AffichierListeEnBdd.ExecuteReader();
                while (RecupereListeEnBdd.Read())
                {
                    ListeEnBdd.Add((string)RecupereListeEnBdd["idUtilisateur"]);
                    ListeEnBdd.Add((string)RecupereListeEnBdd["nom"]);
                    ListeEnBdd.Add((string)RecupereListeEnBdd["prenom"]);
                    ListeEnBdd.Add((string)RecupereListeEnBdd["dateNaissance"]);
                }

                GestionBDD.Deconnection();

                return (ListeEnBdd);
            }
        }

        static void Main(string[] args)
        {


            Int32 refaire = 1;

            do
            {
                Console.WriteLine("*** Bienvenue dans la gestion d'utilisateur ***");
                Console.WriteLine("[I]nserer \n [A]fficher \n [S]upprimer \n [M]odifier\n ");
                string choix = Console.ReadLine();
                if (choix == "i")
                {
                    Console.WriteLine("Entrer votre nom");
                    string nom = Console.ReadLine();

                    Console.WriteLine("Entrer votre prenom");
                    string prenom = Console.ReadLine();

                    Console.WriteLine("Entrer votre date de Naissance ex : 04051985");
                    string dateNaissance = Console.ReadLine();

                    GestionBDD.AjoutUtilisateur(nom, prenom, dateNaissance);

                    
                }
                else if (choix == "a")
                {
                    
                    GestionBDD.AfficherListeEnBdd();
                    
                }

                Console.WriteLine("Avez-vous encore des actions à effectuer Oui=1 Non=0?");
                refaire = Convert.ToInt32(Console.ReadLine());

            } while (refaire == 1);


            Console.ReadKey();
        }
    }
}
