using System.Numerics;
using Npgsql;
using ProjetExamen.Database;
using static ProjetExamen.Database.Data;

namespace ProjetExamen.Models;

/// <summary>
/// Représente une station-service contenant
/// des pompes et des cuves.
/// Permet de gérer les ventes, les achats,
/// les stocks et les connexions entre pompes et cuves.
/// </summary>
public class StationService
{
    /// <summary>
    /// Nom de la station-service.
    /// </summary>
    public string Nom;

    /// <summary>
    /// Adresse de la station-service.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Heure d’ouverture du shop.
    /// </summary>
    public TimeSpan HoraireOuvertureShop { get; set; }

    /// <summary>
    /// Heure de fermeture du shop.
    /// </summary>
    public TimeSpan HoraireFermetureShop { get; set; }

    /// <summary>
    /// Liste des pompes de la station.
    /// </summary>
    public List<Pompe> Pompes { get; set; }

    /// <summary>
    /// Liste des cuves de la station.
    /// </summary>
    public List<Cuve> Cuves { get; set; }

    /// <summary>
    /// Liste des ventes effectuées.
    /// </summary>
    public List<Vente> Ventes { get; set; }

    /// <summary>
    /// Liste des achats de carburant.
    /// </summary>
    public List<Achats> Achats { get; set; }

    /// <summary>
    /// Constructeur de la station-service.
    /// </summary>
    /// <param name="nom">Nom de la station.</param>
    /// <param name="address">Adresse de la station.</param>
    /// <param name="horaireOuvertureShop">
    /// Heure d’ouverture.
    /// </param>
    /// <param name="horaireFermetureShop">
    /// Heure de fermeture.
    /// </param>
    public StationService(
        string nom,
        string address,
        TimeSpan horaireOuvertureShop,
        TimeSpan horaireFermetureShop)
    {
        Nom = nom;
        Address = address;

        HoraireOuvertureShop = horaireOuvertureShop;
        HoraireFermetureShop = horaireFermetureShop;

        // Initialisation des listes
        Cuves = new List<Cuve>();
        Pompes = new List<Pompe>();
        Ventes = new List<Vente>();
        Achats = new List<Achats>();
    }

    /// <summary>
    /// Ajoute une cuve à la station.
    /// </summary>
    /// <param name="cuve">Cuve à ajouter.</param>
    public void AjouterCuve(Cuve cuve)
    {
        Cuves.Add(cuve);

        Console.WriteLine(
            "Cuve "
            + cuve.NumeeroCuve
            + " ajoutée à la station "
            + Nom);
    }

    /// <summary>
    /// Ajoute une pompe à la station.
    /// </summary>
    /// <param name="pompe">Pompe à ajouter.</param>
    public void AjouterPompe(Pompe pompe)
    {
        Pompes.Add(pompe);

        Console.WriteLine(
            "Pompe "
            + pompe.NumeeroPompe
            + " créée dans la station "
            + Nom);
    }

    /// <summary>
    /// Supprime une cuve de la station.
    /// </summary>
    /// <param name="cuve">Cuve à supprimer.</param>
    public void SupprimerCuve(Cuve cuve)
    {
        Cuves.Remove(cuve);

        Console.WriteLine(
            "Cuve "
            + cuve.NumeeroCuve
            + " supprimée de la station "
            + Nom);
    }

    /// <summary>
    /// Supprime une pompe de la station.
    /// </summary>
    /// <param name="pompe">Pompe à supprimer.</param>
    public void SupprimerPompe(Pompe pompe)
    {
        Pompes.Remove(pompe);

        Console.WriteLine(
            "Pompe "
            + pompe.NumeeroPompe
            + " supprimée de la station "
            + Nom);
    }

    /// <summary>
    /// Affiche le stock actuel des cuves.
    /// </summary>
    public void AffichagerDuStoke()
    {
        foreach (var cuve in Cuves)
        {
            Console.WriteLine(
                "Capacité de la cuve "
                + cuve.NumeeroCuve
                + " : "
                + cuve.GetcapaciteActuelle()
                + " litres disponibles");
        }
    }

    /// <summary>
    /// Affiche les pompes et leur état.
    /// </summary>
    public void AfficherNombrePompe()
    {
        foreach (var pompe in Pompes)
        {
            Console.WriteLine(
                "Pompe n°"
                + pompe.NumeeroPompe
                + " "
                + pompe.Status());
        }
    }

    /// <summary>
    /// Affiche tous les pistolets
    /// et leur état.
    /// </summary>
    public void AfficherPistolets()
    {
        foreach (var pompe in Pompes)
        {
            foreach (var p in pompe.Pistolets)
            {
                Console.WriteLine(
                    "Pistolet "
                    + p.NumeeroPistole
                    + " - "
                    + p.Status());
            }
        }
    }

    /// <summary>
    /// Affiche les horaires du shop.
    /// </summary>
    public void HorraireShop()
    {
        string menu = $"""
                       Horaires du shop
                       ----------------
                       Lundi    : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Mardi    : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Mercredi : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Jeudi    : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Vendredi : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Samedi   : {HoraireOuvertureShop:hh\:mm} - {HoraireFermetureShop:hh\:mm}
                       Dimanche : Fermé
                       """;

        Console.WriteLine(menu);
    }

    /// <summary>
    /// Affiche les carburants disponibles
    /// ainsi que leur prix.
    /// </summary>
    public void AfficherPrixCarburant()
    {
        HashSet<NomCarburant> prixCarburant =
            new HashSet<NomCarburant>();

        foreach (var cu in Cuves)
        {
            if (!prixCarburant.Contains(cu.Carburant.Type))
            {
                Console.WriteLine(
                    cu.Carburant.Type
                    + " : "
                    + cu.Carburant.GetPrixParLitre()
                    + " €/L");

                prixCarburant.Add(cu.Carburant.Type);
            }
        }
    }

    /// <summary>
    /// Ajoute une vente à l’historique.
    /// </summary>
    /// <param name="vente">Vente à ajouter.</param>
    public void AjouterUneVente(Vente vente)
    {
        Ventes.Add(vente);

        // Sauvegarde dans la base de données
        SauvegarderVenteBdd(vente);

        Console.WriteLine("Une vente a été ajoutée");
    }

    /// <summary>
    /// Ajoute un achat à l’historique.
    /// </summary>
    /// <param name="achat">Achat à ajouter.</param>
    public void AjouterUnAchat(Achats achat)
    {
        Achats.Add(achat);

        // Sauvegarde dans la base de données
        SauvegarderAchatsBdd(achat);

        Console.WriteLine("Un achat a été ajouté");
    }

    /// <summary>
    /// Affiche l’historique des ventes.
    /// </summary>
    public void AfficherHistoriqueDeVentes()
    {
        if (Ventes.Count <= 0)
        {
            Console.WriteLine("Pas de vente");
        }

        foreach (var vente in Ventes)
        {
            Console.WriteLine(
                "Carburant : " + vente.Essence +
                " Quantité : " + vente.Quantite + " L " +
                " Prix : " + vente.Prix + " € " +
                " Jour : " + vente.Jour);
        }
    }

    /// <summary>
    /// Affiche l’historique des achats.
    /// </summary>
    public void AfficherHistoriqueDAchats()
    {
        if (Achats.Count <= 0)
        {
            Console.WriteLine("Pas d'achat");
        }

        foreach (var achat in Achats)
        {
            Console.WriteLine(
                "Carburant : " + achat.Carburant +
                " Quantité : " + achat.Quantite + " L " +
                " Prix : " + achat.Prix + " € " +
                " Jour : " + achat.Jour +
                " Total : " + achat.Total);
        }
    }

    /// <summary>
    /// Sauvegarde un achat dans PostgreSQL.
    /// </summary>
    /// <param name="achat">Achat à enregistrer.</param>
    public void SauvegarderAchatsBdd(Achats achat)
    {
        Data db = new Data();

        using var conn = db.GetConnection();

        conn.Open();

        string query =
            "INSERT INTO achat " +
            "(carburant, quantite, prix, jour, total) " +
            "VALUES (@carburant, @quantite, @prix, @jour, @total)";

        using var cmd = new NpgsqlCommand(query, conn);

        cmd.Parameters.AddWithValue(
            "carburant",
            achat.Carburant.ToString());

        cmd.Parameters.AddWithValue(
            "quantite",
            achat.Quantite);

        cmd.Parameters.AddWithValue(
            "prix",
            achat.Prix);

        cmd.Parameters.AddWithValue(
            "jour",
            DateTime.Today);

        cmd.Parameters.AddWithValue(
            "total",
            achat.Total);

        cmd.ExecuteNonQuery();

        Console.WriteLine(
            "Achat enregistré dans la base !");
    }

    /// <summary>
    /// Sauvegarde une vente dans PostgreSQL.
    /// </summary>
    /// <param name="vente">
    /// Vente à enregistrer.
    /// </param>
    public void SauvegarderVenteBdd(Vente vente)
    {
        Data db = new Data();

        using var conn = db.GetConnection();

        conn.Open();

        string query =
            "INSERT INTO vente " +
            "(carburant, quantite, prix, jour) " +
            "VALUES (@carburant, @quantite, @prix, @jour)";

        using var cmd = new NpgsqlCommand(query, conn);

        cmd.Parameters.AddWithValue(
            "carburant",
            vente.Essence.ToString());

        cmd.Parameters.AddWithValue(
            "quantite",
            vente.Quantite);

        cmd.Parameters.AddWithValue(
            "prix",
            vente.Prix);

        cmd.Parameters.AddWithValue(
            "jour",
            DateTime.Today);

        cmd.ExecuteNonQuery();

        Console.WriteLine(
            "Vente enregistrée dans la base !");
    }

    /// <summary>
    /// Recherche une cuve selon le carburant.
    /// </summary>
    /// <param name="type">
    /// Type de carburant recherché.
    /// </param>
    /// <returns>
    /// La cuve correspondante ou null.
    /// </returns>
    public Cuve? RechercheBonneCarburant(
        NomCarburant type)
    {
        foreach (var cuve in Cuves)
        {
            if (cuve.Carburant.Type == type)
            {
                return cuve;
            }
        }

        return null;
    }

    /// <summary>
    /// Retourne le prix d’achat d’un carburant.
    /// </summary>
    /// <param name="type">
    /// Type de carburant.
    /// </param>
    /// <returns>
    /// Prix d’achat par litre.
    /// </returns>
    public double PrixAchatCarburant(
        NomCarburant type)
    {
        switch (type)
        {
            case NomCarburant.Diesel:
                return 2.20;

            case NomCarburant.Sp95:
                return 2;

            case NomCarburant.Sp98:
                return 2.15;

            case NomCarburant.Lpg:
                return 2.25;

            case NomCarburant.Melange2Temps:
                return 2.30;

            default:
                return 0;
        }
    }

    /// <summary>
    /// Vérifie le niveau des cuves
    /// et commande automatiquement
    /// du carburant si nécessaire.
    /// </summary>
    public void ControlerNiveauCuves()
    {
        foreach (var cuve in Cuves)
        {
            // Vérifie si le niveau est trop bas
            if (cuve.GetcapaciteActuelle()
                <= cuve.CapaciteMin)
            {
                // Prix d’achat du carburant
                double prixVente =
                    PrixAchatCarburant(
                        cuve.Carburant.Type);

                // Quantité nécessaire
                double quantite =
                    cuve.CapaciteMax
                    - cuve.GetcapaciteActuelle();

                // Calcul du total
                double total =
                    prixVente * quantite;

                // Livraison par camion
                CamionCarburant camion =
                    new CamionCarburant(
                        quantite,
                        prixVente);

                camion.LivraisonDuCarburant(cuve);

                // Création de l’achat
                Achats achat1 =
                    new Achats(
                        cuve.Carburant.Type,
                        quantite,
                        prixVente,
                        DateTime.Today.DayOfWeek,
                        total);

                // Ajout à l’historique
                AjouterUnAchat(achat1);
            }
        }
    }
}