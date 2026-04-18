using Npgsql;
using ProjetExamen.Database;
using static ProjetExamen.Database.Data;

namespace ProjetExamen.Models;

/// <summary>
/// Représente une station-service contenant des pompes et des cuves.
/// Permet de gérer l'ajout, la suppression et la connexion entre les pompes et les cuves.
/// </summary>
public class StationService
{
 /// <summary>
 /// nom de la station service
 /// </summary>
 public  string Nom;
 /// <summary>
 /// Adresse de la station-service.
 /// </summary>
 public string Address { get; set; }
 /// <summary>
 /// Heure d'ouverture de la station.
 /// </summary>
 public TimeSpan HoraireOuvertureShop { get; set; }
 /// <summary>
 /// Heure de fermeture de la station.
 /// </summary>
 public TimeSpan HoraireFermetureShop { get; set; }
 /// <summary>
 /// Liste des pompes disponibles dans la station.
 /// </summary>
 public List<Pompe> Pompes {get; set;}
 /// <summary>
 /// Liste des cuves disponibles dans la station.
 /// </summary>
 public List<Cuve> Cuves {get; set;}
 
 public List<Vente> Ventes {get; set;}

 /// <summary>
 /// Constructeur de la station-service.
 /// Initialise le nom, l'adresse et les listes de pompes et de cuves.
 /// </summary>
 /// <param name="nom">Nom de la station</param>
 /// <param name="address">Adresse de la station</param>
 /// <param name="horaireOuvertureShop"></param>
 /// <param name="horaireFermetureShop"></param>
 
 public StationService(string nom, string address,TimeSpan horaireOuvertureShop,TimeSpan horaireFermetureShop)
 {
  this.Nom = nom;
  this.Address = address;
  this.HoraireOuvertureShop = horaireOuvertureShop;
  this.HoraireFermetureShop = horaireFermetureShop;
  

  Cuves = new List<Cuve>();
  Pompes = new List<Pompe>();
  Ventes = new List<Vente>();
 }
 /// <summary>
 /// Ajoute une cuve à la station.
 /// </summary>
 /// <param name="cuve">Cuve à ajouter</param>
 public void AjouterCuve(Cuve cuve)
 {
  Cuves.Add(cuve);
  Console.WriteLine("Cuve " + cuve.NumeeroCuve + " a été ajoutée à la station service  " + Nom);
 }
 /// <summary>
 /// Ajoute une pompe à la station.
 /// </summary>
 /// <param name="pompe">Pompe à ajouter</param>
 public void AjouterPompe(Pompe pompe){
  Pompes.Add(pompe);
  Console.WriteLine("Pompe " + pompe.NumeeroPompe + " a été creer dans la station service " + Nom);
  
 }
 /// <summary>
 /// Supprime une cuve de la station.
 /// </summary>
 /// <param name="cuve">Cuve à supprimer</param>
 public void SupprimerCuve(Cuve cuve)
 {
  Cuves.Remove(cuve);
  Console.WriteLine("Cuve" + cuve.NumeeroCuve + " supprimer a été de la station service " + Nom);
 }
 /// <summary>
 /// Supprime une pompe de la station.
 /// </summary>
 /// <param name="pompe">Pompe à supprimer</param>
 public void SupprimerPompe(Pompe pompe)
 {
  Pompes.Remove(pompe);
  Console.WriteLine("Pompe " + pompe.NumeeroPompe + "  supprimer de la station-service " + Nom);
 }

/// <summary>
/// Permet de voir l'état de la cuve dans la station
/// </summary>
 public void AffichagerDuStoke()
 {
  foreach (var cuve in Cuves)
  {
   Console.WriteLine("La capacite de la cuve " + cuve.NumeeroCuve + " vaut : " + cuve.GetcapaciteActuelle() + " Littre disponible ");
  }
 }
/// <summary>
/// Permet de voir le nombreux de pompe dans la station service ainsi que son status
/// </summary>
 public void AfficherNombrePompe()
 {
  foreach (var pompe in Pompes)
  {
   Console.WriteLine("Pompe n°"  + pompe.NumeeroPompe + " " + pompe.Status());
  }
 }
 /// <summary>
 /// Permet de voir tous les pistolets de toutes les pompes dans la station service ainsi que son status
 /// method propose par ChatGpt
 /// </summary>
 public void AfficherPistolets()
 {
  foreach (var pompe in Pompes)
  {
   foreach (var p in pompe.Pistolets)
   {
    Console.WriteLine("Pistolet " + p.NumeeroPistole + " - " + p.Status());
   }
  }
 }
/// <summary>
/// Permet d'afficher l'horraire du shop
/// IA a aider pour améliore le visuel
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
/// Permet d'afficher un menu pour le carburant et le prix
/// </summary>
 public void AfficherPrixCarburant()
 {
  HashSet<NomCarburant> prixCarburant = new HashSet<NomCarburant>();
  
  foreach (var cu in Cuves)
  {
   if (!prixCarburant.Contains(cu.Carburant.Type))
   {
    Console.WriteLine(cu.Carburant.Type + ":" + cu.Carburant.GetPrixParLitre()+ " €/L");
    prixCarburant.Add(cu.Carburant.Type);
   }
   
  }
 }
 /// <summary>
 /// Permet d'ajouter une vente 
 /// </summary>
 /// <param name="vente"></param>
 public void AjouterUneVente(Vente vente)
 {
  Ventes.Add(vente);
  SauvegarderVenteBdd(vente);
  Console.WriteLine("une vente a été ajouter ");
  
 }
/// <summary>
/// Permet d'afficher l'historis des ventes
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
    " Prix : " + vente.Prix + " €" +
    " Jour : " + vente.Jour
    
    
    );
  }
 }
 
 
 
 /// <summary>
 /// Sauvegarde une vente dans la base de données PostgreSQL.
 /// </summary>
 /// Propose par IA CHatGPT
 /// <param name="vente">Objet Vente contenant les informations à enregistrer</param>
 public void SauvegarderVenteBdd(Vente vente)
 {
  Data db = new Data();

  using var conn = db.GetConnection();
  conn.Open();

  string query = "INSERT INTO vente (carburant, quantite, prix, jour) VALUES (@carburant, @quantite, @prix, @jour)";

  using var cmd = new NpgsqlCommand(query, conn);

  cmd.Parameters.AddWithValue("carburant", vente.Essence.ToString());
  cmd.Parameters.AddWithValue("quantite", vente.Quantite);
  cmd.Parameters.AddWithValue("prix", vente.Prix);
  cmd.Parameters.AddWithValue("jour", DateTime.Today);

  cmd.ExecuteNonQuery();

  Console.WriteLine(" Vente enregistrée en base !");
 }
 
 
 /// <summary>
 /// Connecte une pompe à une cuve en fonction de leurs numéros.
 /// La pompe prendra le type de carburant de la cuve.
 /// </summary>
 /// <param name="numPompe">Numéro de la pompe</param>
 /// <param name="numCuve">Numéro de la cuve</param>
 
 /// méthod aide par ChatGPT


 
 

}