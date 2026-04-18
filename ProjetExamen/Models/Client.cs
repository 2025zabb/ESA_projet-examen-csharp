namespace ProjetExamen.Models;

/// <summary>
/// Représente un client de la station-service.
/// Hérite de la classe Personnes.
/// </summary>
public class Client : Personnes
{
    /// <summary>
    /// Constructeur de la classe Client.
    /// Initialise le nom et le prénom du client.
    /// </summary>
    /// <param name="nom">Nom du client</param>
    /// <param name="prenom">Prénom du client</param>
    public Client(string nom, string prenom) : base(nom, prenom)
    {
    }

    /// <summary>
    /// Permet au client d'effectuer le paiement d'un plein de carburant.
    /// </summary>
    /// <param name="montant">Montant à payer</param>
    public void EffectuerLePaiement(double montant)
    {
        Console.WriteLine("Mr/Mme " + Nom + " " + Prenom + " a payé " + montant + " €");
    }
}