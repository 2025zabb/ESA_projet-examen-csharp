namespace ProjetExamen;

public class Pompe
{
    public int NumeeroPompe {get; set;}
    public bool disponible {get; set;}
    public bool enpane {get; set;}
    public List<Pistolet> pistolets {get; set;}
    public string typeCuve {get; set;}

    public Pompe(int numeeroPompe)
    {
        NumeeroPompe = numeeroPompe;
        disponible = true;
        enpane = false;
        pistolets = new List<Pistolet>();
    }
    
   
}