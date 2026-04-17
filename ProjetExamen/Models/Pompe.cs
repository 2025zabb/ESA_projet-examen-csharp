using ProjetExamen.Interfaces;
namespace ProjetExamen.Models;

public class Pompe : IStatut
{
    // Attributs de la class
    public int NumeeroPompe { get; set; }
    public bool Disponible { get; set; }
    public bool Enpane { get; set; }
    public List<Pistolet> Pistolets { get; set; }
    public string TypeCuve { get; set; }

    // constructeur de la class
    public Pompe(int numeeroPompe)
    {
        NumeeroPompe = numeeroPompe;
        //TypeCuve = typeCuve;
        Disponible = true;
        Enpane = false;
        Pistolets = new List<Pistolet>();
    }

    // Interface
    public string Status()
    {
        if (Enpane)
        {
            return "Pompe en panne";
        }
        if(!Disponible){
            return "Pompe pas disponible";
        }
        return "Pompe disponible";


    }

    public void FaireLePlein(Client client,StationService station ,double quantite)
    {
        if (Enpane)
        {
            Console.WriteLine("Pompe hors service");
            return;
        }

        double? prix = null;
        foreach (var pi in Pistolets)
        {
            if (pi.Disponible && !Enpane)
            {
                pi.Disponible = true;
                prix = pi.Distribue(quantite);
                

                if (prix != null)
                {
                    client.EffectuerLePaiement(prix.Value);
                    Vente vente1 = new Vente(prix.Value, pi.Cuve.Carburant.Type, quantite,DateTime.Today.DayOfWeek);
                    station.AjouterUneVente(vente1);
                }
                
                return;
            }
        }

    }
}