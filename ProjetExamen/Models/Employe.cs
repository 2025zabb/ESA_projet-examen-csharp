namespace ProjetExamen.Models;

/// <summary>
/// Représente un employé de la station-service.
/// Hérite de la classe Personnes et ajoute des informations professionnelles.
/// </summary>
public class Employe : Personnes
{
    /// <summary>
    /// Numéro unique de l'employé.
    /// </summary>
    private int NumeroEmploye { get; set; }

    /// <summary>
    /// Poste occupé par l'employé.
    /// </summary>
    private string Poste { get; set; }

    /// <summary>
    /// Constructeur de la classe Employe.
    /// Initialise le nom, le prénom, le numéro et le poste.
    /// </summary>
    /// <param name="nom">Nom de l'employé</param>
    /// <param name="prenom">Prénom de l'employé</param>
    /// <param name="numero">Numéro de l'employé</param>
    /// <param name="poste">Poste de l'employé</param>
    public Employe(string nom, string prenom, int numero, string poste) : base(nom, prenom)
    {
        NumeroEmploye = numero;
        Poste = poste;
    }

    /// <summary>
    /// Affiche les informations personnelles et professionnelles de l'employé.
    /// </summary>
    public void AfficherInfosPersonnelles()
    {
        AfficherInfos();
        Console.WriteLine("Mon numéro d'employé est : " + NumeroEmploye);
        Console.WriteLine("Mon poste actuel est : " + Poste);
    }
}