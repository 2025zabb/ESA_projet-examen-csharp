namespace ProjetExamen;
// creation d une interface methode pour Cuve
public interface INterfacCuve
{
    // renvoie vrai si vide sinon faux
    public bool EstVide();
    // renvoie vrai si plein sinon faux
    public bool EstPleine();
    // methode pour commander de l'essence
    public bool CommanderEssenc();
    // // methode pour distribue de l'essence
    public bool DonnerEssenc();
    
}