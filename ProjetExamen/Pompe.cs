namespace ProjetExamen;

public class Pompe
{
    public int NumeeroPompe {get; set;}
    public bool disponible {get; set;}
    public bool enpane {get; set;}
    public List<Cuve> cuveConnect {get; set;}
    public Pistolet pistolet {get; set;}
    public string typeCuve {get; set;}
    
}