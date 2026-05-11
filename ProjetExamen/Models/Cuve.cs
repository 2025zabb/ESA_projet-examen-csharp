using ProjetExamen.Interfaces;

namespace ProjetExamen.Models;

/// <summary>
/// Représente une cuve de stockage de carburant.
/// Elle permet de remplir la cuve, vérifier son état
/// et distribuer du carburant.
/// </summary>
public class Cuve : ICuve
{
    /// <summary>
    /// Indique si la cuve possède un problème de distribution.
    /// </summary>
    public bool ProblemeDistribution { get; private set; }

    /// <summary>
    /// Quantité actuelle de carburant dans la cuve en litres.
    /// </summary>
    private double CapaciteActuelle { get; set; }

    /// <summary>
    /// Capacité maximale de la cuve en litres.
    /// </summary>
    public double CapaciteMax { get; set; }

    /// <summary>
    /// Niveau minimum de carburant autorisé dans la cuve.
    /// </summary>
    public double CapaciteMin { get; set; }

    /// <summary>
    /// Numéro unique de la cuve.
    /// </summary>
    public int NumeeroCuve { get; set; }

    /// <summary>
    /// Type de carburant contenu dans la cuve.
    /// </summary>
    public TypeEssence Carburant { get; set; }

    /// <summary>
    /// Niveau seuil de sécurité à ne pas dépasser vers le bas.
    /// </summary>
    public double Seuilcapacite { get; set; }

    /// <summary>
    /// Indique si la cuve est en cours de remplissage.
    /// </summary>
    public bool RemplissageEssenc { get; private set; }

    /// <summary>
    /// Constructeur permettant de créer une cuve
    /// déjà partiellement ou totalement remplie.
    /// </summary>
    /// <param name="numeeroCuve">Numéro de la cuve.</param>
    /// <param name="carburant">Type de carburant.</param>
    /// <param name="capaciteActuelle">Capacité actuelle.</param>
    /// <param name="capaciteMax">Capacité maximale.</param>
    /// <param name="capaciteMin">Capacité minimale.</param>
    /// <param name="seuilcapacite">Seuil minimum de sécurité.</param>
    public Cuve(
        int numeeroCuve,
        TypeEssence carburant,
        double capaciteActuelle,
        double capaciteMax,
        double capaciteMin,
        double seuilcapacite)
    {
        NumeeroCuve = numeeroCuve;
        Carburant = carburant;
        CapaciteActuelle = capaciteActuelle;
        CapaciteMax = capaciteMax;
        CapaciteMin = capaciteMin;
        Seuilcapacite = seuilcapacite;
    }

    /// <summary>
    /// Constructeur permettant de créer une cuve vide.
    /// </summary>
    /// <param name="numeeroCuve">Numéro de la cuve.</param>
    /// <param name="carburant">Type de carburant.</param>
    /// <param name="capaciteMax">Capacité maximale.</param>
    /// <param name="capaciteMin">Capacité minimale.</param>
    /// <param name="seuilcapacite">Seuil minimum de sécurité.</param>
    public Cuve(
        int numeeroCuve,
        TypeEssence carburant,
        double capaciteMax,
        double capaciteMin,
        double seuilcapacite)
        : this(
            numeeroCuve,
            carburant,
            0,
            capaciteMax,
            capaciteMin,
            seuilcapacite)
    {
    }

    /// <summary>
    /// Vérifie si la cuve est vide.
    /// </summary>
    /// <returns>True si la cuve est vide.</returns>
    public bool EstVide()
    {
        return CapaciteActuelle == 0;
    }

    /// <summary>
    /// Vérifie si la cuve est pleine.
    /// </summary>
    /// <returns>True si la cuve est pleine.</returns>
    public bool EstPleine()
    {
        return CapaciteActuelle == CapaciteMax;
    }

    /// <summary>
    /// Vérifie si une commande de carburant est nécessaire.
    /// </summary>
    /// <returns>True si le niveau est inférieur au minimum.</returns>
    public bool CommanderEssence()
    {
        return CapaciteActuelle <= CapaciteMin;
    }

    /// <summary>
    /// Vérifie si la cuve peut distribuer du carburant.
    /// </summary>
    /// <returns>True si la distribution est possible.</returns>
    public bool DonnerEssence()
    {
        return !RemplissageEssenc
               && CapaciteActuelle > Seuilcapacite
               && !ProblemeDistribution;
    }

    /// <summary>
    /// Remplit la cuve avec une quantité donnée.
    /// </summary>
    /// <param name="quantite">Quantité à ajouter.</param>
    public void Remplir(double quantite)
    {
        CapaciteActuelle += quantite;

        // Empêche de dépasser la capacité maximale
        if (CapaciteActuelle > CapaciteMax)
        {
            CapaciteActuelle = CapaciteMax;
        }
    }

    /// <summary>
    /// Commande du carburant et remplit la cuve si nécessaire.
    /// </summary>
    /// <param name="quantite">Quantité à ajouter.</param>
    public void CommanderEtRemplirCuve(double quantite)
    {
        if (CommanderEssence())
        {
            Console.WriteLine("Cuve " + NumeeroCuve + " en remplissage");

            // Début du remplissage
            DemarrerRemplissage();

            // Ajout du carburant
            Remplir(quantite);

            Console.WriteLine(
                "La cuve "
                + NumeeroCuve
                + " a été remplie de "
                + quantite
                + " L");

            // Fin du remplissage
            ArreterRemplissage();

            Console.WriteLine(
                "Cuve "
                + NumeeroCuve
                + " peut être utilisée maintenant");
        }
    }

    /// <summary>
    /// Distribue une quantité de carburant.
    /// </summary>
    /// <param name="quantite">Quantité demandée.</param>
    /// <returns>Prix total ou null si impossible.</returns>
    public double? DistriEssence(double quantite)
    {
        // Vérifie si un problème de distribution existe
        if (ProblemeDistribution)
        {
            Console.WriteLine(
                "La cuve ne peut pas distribuer "
                + "de carburant : problème de distribution");

            return null;
        }

        // Vérifie si la cuve est en remplissage
        if (RemplissageEssenc)
        {
            Console.WriteLine(
                "La cuve ne peut pas distribuer "
                + "de carburant car elle est en remplissage");

            return null;
        }

        // Vérifie si le niveau est trop bas
        if (CapaciteActuelle < Seuilcapacite)
        {
            Console.WriteLine(
                "Arrêt de distribution : "
                + "niveau de carburant trop bas");

            return null;
        }

        // Vérifie si la quantité demandée est disponible
        if (CapaciteActuelle < quantite)
        {
            Console.WriteLine(
                "Pas assez de carburant dans la cuve");

            return null;
        }

        // Retire le carburant distribué
        CapaciteActuelle -= quantite;

        // Calcul du prix total
        double lePrix =
            Math.Round(Carburant.CalculerPrixTotal(quantite), 2);

        Console.WriteLine(
            "Distribution OK : "
            + quantite
            + " litres distribués");

        Console.WriteLine(
            "Prix à payer : "
            + lePrix
            + " €");

        return lePrix;
    }

    /// <summary>
    /// Affiche l’état actuel de la cuve.
    /// </summary>
    public void EtatDeLaCuve()
    {
        if (EstVide())
        {
            Console.WriteLine(
                "La cuve "
                + NumeeroCuve
                + " est vide");
        }
        else if (EstPleine())
        {
            Console.WriteLine(
                "La cuve "
                + NumeeroCuve
                + " est pleine");
        }
        else
        {
            Console.WriteLine(
                "La cuve "
                + NumeeroCuve
                + " est en service");
        }
    }

    /// <summary>
    /// Remplit automatiquement la cuve si elle est vide.
    /// </summary>
    /// <param name="quantite">Quantité à ajouter.</param>
    public void RemplirCuveSiVide(double quantite)
    {
        if (EstVide())
        {
            CommanderEtRemplirCuve(quantite);

            Console.WriteLine(
                "La cuve a été remplie de "
                + quantite
                + " litres");
        }
    }

    /// <summary>
    /// Retourne la capacité actuelle de la cuve.
    /// </summary>
    /// <returns>Capacité actuelle.</returns>
    public double GetcapaciteActuelle()
    {
        return CapaciteActuelle;
    }

    /// <summary>
    /// Signale un problème de distribution.
    /// </summary>
    public void SignalerProlemeDeDistribution()
    {
        ProblemeDistribution = true;
    }

    /// <summary>
    /// Résout le problème de distribution.
    /// </summary>
    public void ResoudreProblemeDistribution()
    {
        ProblemeDistribution = false;
    }

    /// <summary>
    /// Démarre le remplissage de la cuve.
    /// </summary>
    public void DemarrerRemplissage()
    {
        RemplissageEssenc = true;
    }

    /// <summary>
    /// Arrête le remplissage de la cuve.
    /// </summary>
    public void ArreterRemplissage()
    {
        RemplissageEssenc = false;
    }
}