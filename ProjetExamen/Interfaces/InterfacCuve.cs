namespace ProjetExamen.Interfaces;

/// <summary>
/// Interface définissant les méthodes de gestion d'une cuve de carburant.
/// Permet de vérifier son état et de gérer son utilisation.
/// </summary>
public interface ICuve
{
    /// <summary>
    /// Vérifie si la cuve est vide.
    /// </summary>
    /// <returns>True si la cuve est vide, sinon false</returns>
    public bool EstVide();

    /// <summary>
    /// Vérifie si la cuve est pleine.
    /// </summary>
    /// <returns>True si la cuve est pleine, sinon false</returns>
    public bool EstPleine();

    /// <summary>
    /// Permet de commander du carburant pour remplir la cuve.
    /// </summary>
    /// <returns>True si la commande est réussie, sinon false</returns>
    public bool CommanderEssence();

    /// <summary>
    /// Permet de distribuer du carburant depuis la cuve.
    /// </summary>
    /// <returns>True si la distribution est possible, sinon false</returns>
    public bool DonnerEssence();
}