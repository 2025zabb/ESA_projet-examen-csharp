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

 public void AjouteCuve(Cuve cuve)
 {
  cuves.Add(cuve);
  Console.WriteLine("Cuve " + cuve.numeeroCuve + "ajoutée " + nom);
 }
 
 public void AjoutePompe(Pompe pompe){
  pomes.Add(pompe);
  Console.WriteLine("Cuve " + pompe.NumeeroPompe + "ajoutée ");
  
 }

 public void ConnectCuvePmpe(int numPompe, int numCuve){
  foreach (var pomp in pomes)
  {
   if (pomp.NumeeroPompe == numPompe)
   {
    foreach (var cuv in cuves)
    {
     if (cuv.numeeroCuve == numCuve)
     {
      pomp.typeCuve = cuv.carburant.type;
      Console.Write("pompe" + numPompe + "attache à  cuve " + numCuve + " " );
     }
    }
   }
   {
    
   }
  }
  
  
 }
 

}