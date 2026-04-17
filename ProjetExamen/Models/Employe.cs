namespace ProjetExamen.Models;

public class Employe:Personnes
{
    int numeroEmploye;
    string poste;

    public Employe(string nom, string prenom, int numero, string poste) : base(nom, prenom)
    {
        this.numeroEmploye = numero;
        this.poste = poste;
    }

    public void AfficherIfosPersonnell()
    {
        AfficherInfos();
        Console.WriteLine("mon numero employee est : " + numeroEmploye);
        Console.WriteLine("Actuellement mon poste c'est : " + poste );
    }
}