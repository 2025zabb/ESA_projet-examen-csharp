namespace ProjetExamen.Models;

/// <summary>
/// Représente une personne avec un nom et un prénom.
/// Classe de base utilisée pour les clients.
/// </summary>
public class Personnes
{
    /// <summary>
    /// Nom de la personne.
    /// </summary>
    public string Nom { get; set; }

    /// <summary>
    /// Prénom de la personne.
    /// </summary>
    public string Prenom { get; set; }
    
    /// <summary>
    /// Constructeur de la classe Personnes.
    /// Initialise le nom et le prénom.
    /// </summary>
    /// <param name="nom">Nom de la personne</param>
    /// <param name="prenom">Prénom de la personne</param>
    public Personnes(string nom, string prenom)
    {
        Nom = nom;
        Prenom = prenom;
    }

    /// <summary>
    /// Affiche les informations de la personne.
    /// </summary>
    public void AfficherInfos()
    {
        Console.WriteLine("Je m'appelle " + Nom + " " + Prenom);
    }
}