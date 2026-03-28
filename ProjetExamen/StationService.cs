namespace ProjetExamen;

public class StationService
{
 public  string nom;
 public string address { get; set; }
 public TimeSpan horaireOuverture { get; set; }
 public TimeSpan horaireFermeture { get; set; }
 public List<Pompe> pomes {get; set;}
 public List<Cuve> cuves {get; set;}

 public StationService(string nom, string address)
 {
  this.nom = nom;
  this.address = address;

  cuves = new List<Cuve>();
  pomes = new List<Pompe>();
 }
 
}