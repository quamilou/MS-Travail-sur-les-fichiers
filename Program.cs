using System;
using System.Collections.Generic;
using System.IO;

public struct Client
{
    public int ClientID;
    public string Nom;
    public string Prenom;
    public string NumeroTelephone;

    public Client(int clientId, string nom, string prenom, string numeroTelephone)
    {
        ClientID = clientId;
        Nom = nom.ToUpper();
        Prenom = char.ToUpper(prenom[0]) + prenom.Substring(1).ToLower();
        NumeroTelephone = numeroTelephone;
    }
}

public class GestionClients
{
    public static void Main()
    {
        bool continuer = true;
        while (continuer)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 : Saisir un nouveau client");
            Console.WriteLine("2 : Afficher un client");
            Console.WriteLine("3 : Afficher tous les clients");
            Console.WriteLine("4 : Afficher le nombre de clients");
            Console.WriteLine("5 : Modifier un client");
            Console.WriteLine("10 : Quitter");

            Console.Write("\nSélectionnez une option : ");
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
            Console.ReadKey();
        }
    }

    public static void SaisirNouveauClient()
    {
        Console.Write("Entrez le numéro du client : ");
        int clientId = int.Parse(Console.ReadLine());

        Console.Write("Entrez le nom : ");
        string nom = Majuscule(Console.ReadLine());

        Console.Write("Entrez le prénom : ");
        string prenom = FirstMajuscule(Console.ReadLine());

        Console.Write("Entrez le numéro de téléphone : ");
        string numeroTelephone = Console.ReadLine();

        Client nouveauClient = new Client(clientId, nom, prenom, numeroTelephone);

        SauvegarderClient(nouveauClient);
        Console.WriteLine("Client ajouté avec succès.");
    }

    public static void AfficherClient()
    {
        Console.Write("Entrez le nom du client : ");
        string nomRecherche = Majuscule(Console.ReadLine());

        using (BinaryReader reader = new BinaryReader(File.Open("clients.bin", FileMode.OpenOrCreate)))
        {
            int index = 1;
            bool found = false;

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                int clientId = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string numeroTelephone = reader.ReadString();

                if (nom == nomRecherche)
                {
                    Console.WriteLine($"\nFiche {index} : ID={clientId}, Nom={nom}, Prénom={prenom}, Téléphone={numeroTelephone}");
                    found = true;
                }
                index++;
            }

            if (!found)
            {
                Console.WriteLine("Aucun client trouvé avec ce nom.");
            }
        }
    }

    public static void AfficherTousLesClients()
    {
        using (BinaryReader reader = new BinaryReader(File.Open("clients.bin", FileMode.OpenOrCreate)))
        {
            int index = 1;

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                int clientId = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string numeroTelephone = reader.ReadString();

                if (!nom.StartsWith("*"))
                {
                    Console.WriteLine($"Fiche {index} : ID={clientId}, Nom={nom}, Prénom={prenom}, Téléphone={numeroTelephone}");
                }
                index++;
            }
        }
    }

    public static void AfficherNombreClients()
    {
        int count = 0;

        using (BinaryReader reader = new BinaryReader(File.Open("clients.bin", FileMode.OpenOrCreate)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                int clientId = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string numeroTelephone = reader.ReadString();

                if (!nom.StartsWith("*"))
                {
                    count++;
                }
            }
        }

        Console.WriteLine($"Nombre de clients existants : {count}");
    }

    public static void ModifierClient()
    {
        Console.Write("Entrez le numéro de la fiche du client à modifier : ");
        int ficheNum = int.Parse(Console.ReadLine());

        List<Client> clients = new List<Client>();

        using (BinaryReader reader = new BinaryReader(File.Open("clients.bin", FileMode.OpenOrCreate)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                int clientId = reader.ReadInt32();
                string nom = reader.ReadString();
                string prenom = reader.ReadString();
                string numeroTelephone = reader.ReadString();

                clients.Add(new Client(clientId, nom, prenom, numeroTelephone));
            }
        }

        if (ficheNum <= 0 || ficheNum > clients.Count)
        {
            Console.WriteLine("Fiche non trouvée.");
            return;
        }

        Client client = clients[ficheNum - 1];
        Console.WriteLine($"Client actuel: ID={client.ClientID}, Nom={client.Nom}, Prénom={client.Prenom}, Téléphone={client.NumeroTelephone}");

        Console.Write("Nouveau nom (laisser vide pour conserver) : ");
        string nouveauNom = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nouveauNom))
        {
            client.Nom = Majuscule(nouveauNom);
        }

        Console.Write("Nouveau prénom (laisser vide pour conserver) : ");
        string nouveauPrenom = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nouveauPrenom))
        {
            client.Prenom = FirstMajuscule(nouveauPrenom);
        }

        Console.Write("Nouveau numéro de téléphone (laisser vide pour conserver) : ");
        string nouveauTelephone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nouveauTelephone))
        {
            client.NumeroTelephone = nouveauTelephone;
        }

        clients[ficheNum - 1] = client;

        using (BinaryWriter writer = new BinaryWriter(File.Open("clients.bin", FileMode.Create)))
        {
            foreach (var c in clients)
            {
                writer.Write(c.ClientID);
                writer.Write(c.Nom);
                writer.Write(c.Prenom);
                writer.Write(c.NumeroTelephone);
            }
        }

        Console.WriteLine("Client modifié avec succès.");
    }

    public static string Majuscule(string input) => input.ToUpper();
    public static string FirstMajuscule(string input) => char.ToUpper(input[0]) + input.Substring(1).ToLower();

    public static void SauvegarderClient(Client client)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open("clients.bin", FileMode.Append)))
        {
            writer.Write(client.ClientID);
            writer.Write(client.Nom);
            writer.Write(client.Prenom);
            writer.Write(client.NumeroTelephone);
        }
    }
}