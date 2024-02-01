using Godot;
using System;


public partial class buttonLevelUp : Control
{
    [Export] public hero _hero;
    [Export] public Money _money;

    const float levelUp = 1.5f;
    float valeurLevelUp = 2f;
    private void _on_level_up_pressed()
    {
        float res = _money.argent - valeurLevelUp * 3;
        if (res <= 0)
        {
            return;
        }
        else
        {
            _hero.nb_level += 1; // incrémente de 1 le niveau 
            _hero.level.Text = _hero.nb_level.ToString() ; // converti le niveau en string pour l'afficher dans l'étiquette
            _hero.attack = AttackUp(_hero.attack); 
            _hero.attack = MathF.Round(_hero.attack, 2); //arrondi lattaque a 2 chiffre apres la virgule
            _hero.nb_attack.Text = _hero.attack.ToString(); //converti lattaque en string pour l'afficher dans l'étiquette
            GD.Print(_hero.Name," -> nouvelle valeur d'attaque : " + _hero.attack);
            _money.argent -= valeurLevelUp * 3;
            valeurLevelUp += 3;
            GD.Print("somme d'argent", _money.argent);
        }     
    }

    public float AttackUp(float attack) //permet d'augmenter l'attaque
    {
        return attack * levelUp;
    }
}
