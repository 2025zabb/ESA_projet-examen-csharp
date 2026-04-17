namespace ProjetExamen.Interfaces;
// creation d une interface methode commune pour pompe et pistolet
public interface IStatut
{
    // donne l'ètat disponible,occupè,en panne
    public string Status();

}