namespace ProjetExamen.Models;

/// <summary>
/// Représente les différentes catégories de véhicules.
/// </summary>
public enum CategoryVéhicules
{
    /// <summary>
    /// Véhicule de type voiture.
    /// </summary>
    Voiture,

    /// <summary>
    /// Véhicule de type moto.
    /// </summary>
    Moto,

    /// <summary>
    /// Véhicule de type camion.
    /// </summary>
    Camion
}

/// <summary>
/// Représente un véhicule appartenant à un client.
/// </summary>
public class Vehicule
{
    /// <summary>
    /// Couleur du véhicule.
    /// </summary>
    public string Couleur { get; set; }

    /// <summary>
    /// Client propriétaire du véhicule.
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Catégorie du véhicule.
    /// </summary>
    public CategoryVéhicules Category { get; set; }

    /// <summary>
    /// Marque du véhicule.
    /// </summary>
    public string Marque { get; set; }

    /// <summary>
    /// Constructeur de la classe Vehicule.
    /// </summary>
    /// <param name="couleur">
    /// Couleur du véhicule.
    /// </param>
    /// <param name="marque">
    /// Marque du véhicule.
    /// </param>
    /// <param name="client">
    /// Client propriétaire.
    /// </param>
    /// <param name="category">
    /// Catégorie du véhicule.
    /// </param>
    public Vehicule(
        string couleur,
        string marque,
        Client client,
        CategoryVéhicules category)
    {
        Couleur = couleur;
        Marque = marque;
        Client = client;
        Category = category;
    }
}