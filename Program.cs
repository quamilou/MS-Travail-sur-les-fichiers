using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public struct Clients
{
    public int ClientID;
    public string Nom;
    public string Prenom;
    public string NumeroTelephone;

    public void Client(int clientId, string nom, string prenom, string numeroTelephone)
    {
        ClientID = clientId;
        Nom = nom.ToUpper();
        // char PremiereLettre = char.ToUpper(prenom[0]);
        // Prenom = PremiereLettre + prenom.ToLower();
        Prenom = char.ToUpper(prenom[0]) + prenom.Substring(1).ToLower();
        NumeroTelephone = numeroTelephone;
    }

    //Conversion
    public static string Majuscule(string input)
    {
        return input.ToUpper();
    }
    public static string FirstMajuscule(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    //Main menu
    public static void Main()
    {
        bool continuer = true;
        while (continuer)
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choix 1: Saisir un nouveau client");
            Console.WriteLine("Choix 2: Afficher un client");
            Console.WriteLine("Choix 3: Afficher tous les clients");
            Console.WriteLine("Choix 4: Afficher le nombre de clients");
            Console.WriteLine("Choix 5: Modifier un client");
            Console.WriteLine("Choix 6: Supprimer une fiche");
            Console.WriteLine("Choix 7: Récupérer une fiche supprimée");
            Console.WriteLine("Choix 8: Afficher les fiches supprimées");
            Console.WriteLine("Choix 9: Compresser le fichier");
            Console.WriteLine("Choix 10: Quitter");
            Console.WriteLine("\nSelectionnez une option : ");

            if (int.TryParse(Console.ReadLine(), out int choix))
            {
                switch (choix)
                {
                    case 1:
                        SaisirNouveauClient();
                        break;
                    case 2:
                        AfficherClient();
                        break;
                    case 3:
                        AfficherTousLesClients();
                        break;
                    case 4:
                        AfficherNombreClients();
                        break;
                    case 5:
                        ModifierClient();
                        break;
                    case 6:
                        SupprimerFiche();
                        break;
                    case 7:
                        RecupererFiche();
                        break;
                    case 8:
                        AfficherFichesSupprimees();
                        break;
                    case 9:
                        CompresserFichier();
                        break;
                    case 10:
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide.");
            }
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            //Console.ReadKey();
        }
    }
    public static void SaisirNouveauClient(){
        Console.WriteLine("1");
    }
     public static void AfficherClient(){
        Console.Write("2");
    }
     public static void AfficherTousLesClients(){
        Console.Write("3");
    }
     public static void AfficherNombreClients(){
        Console.Write("4");
    }
     public static void ModifierClient(){
        Console.Write("5");
    }
     public static void SupprimerFiche(){
        Console.Write("6");
    }
     public static void RecupererFiche(){
        Console.Write("7");
    }
     public static void AfficherFichesSupprimees(){
        Console.Write("8");
    }
     public static void CompresserFichier(){
        Console.Write("9");
    }
    //  public static void SaisirNouveauClient(){
    //     Console.Write("1");
    // }
}