namespace ProjetExamen.Interfaces;

/// <summary>
/// Interface permettant de définir une méthode commune pour connaître l'état d'un objet.
/// Utilisée par les classes comme Pompe et Pistolet.
/// </summary>
public interface IStatut
{
    /// <summary>
    /// Retourne l'état de l'objet (disponible, occupé ou en panne).
    /// </summary>
    /// <returns>Une chaîne décrivant l'état</returns>
    public string Status();
}