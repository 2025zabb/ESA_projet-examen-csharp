namespace ProjetExamen.Models;


public enum CategoryVéhicules
{
    Voiture,
    Moto,
    Camion
}
public class Vehicule

{
    
    public string Couleur { get; set; }
    public Client Client { get; set; }
    
    public CategoryVéhicules Category { get; set; }
    public String Marque { get; set; }
    
    
    
    public Vehicule(string couleur, string marque, Client client,CategoryVéhicules category)
    {
        Couleur = couleur;
        Marque = marque;
        Client = client;
        Category = category;
    }
    
    
    
}