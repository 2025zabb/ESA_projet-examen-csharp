namespace ProjetExamen.Models;

/// <summary>
/// Représente un camion qui livre du carburant aux cuves.
/// </summary>
public class CamionCarburant
{
    /// <summary>
    /// Quantité de carburant transportée par le camion.
    /// </summary>
    public double Quantite { get; set; }

    /// <summary>
    /// Prix du carburant par litre.
    /// </summary>
    public double PrixParLitre { get; set; }

    /// <summary>
    /// Constructeur de la classe CamionCarburant.
    /// </summary>
    /// <param name="quantite">Quantité de carburant transportée.</param>
    /// <param name="prixParLitre">Prix du carburant par litre.</param>
    public CamionCarburant(double quantite, double prixParLitre)
    {
        Quantite = quantite;
        PrixParLitre = prixParLitre;
    }

    /// <summary>
    /// Effectue la livraison de carburant dans une cuve.
    /// </summary>
    /// <param name="cuve">Cuve à remplir.</param>
    public void LivraisonDuCarburant(Cuve cuve)
    {
        // Calcul du coût total de la livraison
        double cout = Quantite * PrixParLitre;

        Console.WriteLine("Camion arrivé.");
        Console.WriteLine($"Quantité livrée : {Quantite} L");
        Console.WriteLine($"Coût total : {cout} €");

        // Signalement temporaire d’un problème de distribution
        cuve.SignalerProlemeDeDistribution();

        // Remplissage de la cuve
        cuve.CommanderEtRemplirCuve(Quantite);

        // Résolution du problème de distribution
        cuve.ResoudreProblemeDistribution();
    }
}