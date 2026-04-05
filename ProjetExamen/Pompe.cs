namespace ProjetExamen;

public class Pompe : IStatut
{
    // Attributs de la class
    public int NumeeroPompe { get; set; }
    public bool Disponible { get; set; }
    public bool Enpane { get; set; }
    public List<Pistolet> Pistolets { get; set; }
    public string TypeCuve { get; set; }

    // constructeur de la class
    public Pompe(int numeeroPompe, string typeCuve)
    {
        NumeeroPompe = numeeroPompe;
        TypeCuve = typeCuve;
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

    public void FaireLePlein(Client client, double quantite)
    {
        foreach (var pi in Pistolets)
        {
            if (pi.Disponible && !Enpane){
                pi.Disponible = true;}
        }

        if (Disponible)
        {
            
        }
    }
}