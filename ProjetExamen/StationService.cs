namespace ProjetExamen;

/// <summary>
/// Représente une station-service contenant des pompes et des cuves.
/// Permet de gérer l'ajout, la suppression et la connexion entre les pompes et les cuves.
/// </summary>
public class StationService
{
 /// <summary>
 /// nom de la station service
 /// </summary>
 public  string nom;
 /// <summary>
 /// Adresse de la station-service.
 /// </summary>
 public string address { get; set; }
 /// <summary>
 /// Heure d'ouverture de la station.
 /// </summary>
 public TimeSpan horaireOuverture { get; set; }
 /// <summary>
 /// Heure de fermeture de la station.
 /// </summary>
 public TimeSpan horaireFermeture { get; set; }
 /// <summary>
 /// Liste des pompes disponibles dans la station.
 /// </summary>
 public List<Pompe> pompes {get; set;}
 /// <summary>
 /// Liste des cuves disponibles dans la station.
 /// </summary>
 public List<Cuve> cuves {get; set;}
 /// <summary>
 /// Constructeur de la station-service.
 /// Initialise le nom, l'adresse et les listes de pompes et de cuves.
 /// </summary>
 /// <param name="nom">Nom de la station</param>
 /// <param name="address">Adresse de la station</param>
 public StationService(string nom, string address)
 {
  this.nom = nom;
  this.address = address;

  cuves = new List<Cuve>();
  pompes = new List<Pompe>();
 }
 /// <summary>
 /// Ajoute une cuve à la station.
 /// </summary>
 /// <param name="cuve">Cuve à ajouter</param>
 public void AjouterCuve(Cuve cuve)
 {
  cuves.Add(cuve);
  Console.WriteLine("Cuve " + cuve.numeeroCuve + "ajoutée " + nom);
 }
 /// <summary>
 /// Ajoute une pompe à la station.
 /// </summary>
 /// <param name="pompe">Pompe à ajouter</param>
 public void AjouterPompe(Pompe pompe){
  pompes.Add(pompe);
  Console.WriteLine("Pompe " + pompe.NumeeroPompe + "ajoutée ");
  
 }
 /// <summary>
 /// Supprime une cuve de la station.
 /// </summary>
 /// <param name="cuve">Cuve à supprimer</param>
 public void SupprimerCuve(Cuve cuve)
 {
  cuves.Remove(cuve);
  Console.WriteLine("Cuve" + cuve.numeeroCuve + " supprimer " + nom);
 }
 /// <summary>
 /// Supprime une pompe de la station.
 /// </summary>
 /// <param name="pompe">Pompe à supprimer</param>
 public void SupprimerPompe(Pompe pompe)
 {
  pompes.Remove(pompe);
  Console.WriteLine("Pompe " + pompe.NumeeroPompe + " ");
 }
 /// <summary>
 /// Connecte une pompe à une cuve en fonction de leurs numéros.
 /// La pompe prendra le type de carburant de la cuve.
 /// </summary>
 /// <param name="numPompe">Numéro de la pompe</param>
 /// <param name="numCuve">Numéro de la cuve</param>
 
 /// méthod aide par ChatGPT


 

}