namespace ProjetExamen;

public class Personnes
{
    public string Nom { set;get;}
    public string Prenom  { set;get;}
    
    public Personnes(string nom, string prenom)
    {
       Nom = nom;
       Prenom = prenom;
    }

   

    public void AfficherInfos()
    {
        Console.WriteLine("je m'appelle " + Nom + " " + Prenom);
    }
    
    
}