using Godot;

public partial class Life : Node
{
	[Signal] public delegate void OnLifeChangedEventHandler(float newLife);

	[Export] private float _maxLife = 100f;

	private float _currentLife = 0;

	public float LifePrecent => _currentLife / _maxLife;

	public void Damage(float amount)
	{
		ModifyLife(-amount); // - pour retirer de la vie
	}

	public void Heal(float amount)
	{
		ModifyLife(amount); // pour ajouter de la vie
	}

    public override void _Ready()
    {
       _currentLife = _maxLife; // debut du jeu full vie
    }

    private void ModifyLife(float amount)
	{
		_currentLife+= amount; //rajoute ou retire de la vie
		_currentLife = Mathf.Clamp(_currentLife, 0f , _maxLife);
		/* Mathf.Clamp garantit que _currentLife ne sera 
		jamais inférieur à 0 et ne dépassera pas _maxLife. Si _currentLife 
		est en dehors de cette plage, elle sera automatiquement ajustée pour 
		être soit 0 si elle est inférieure, soit _maxLife si elle est supérieure.*/
		EmitSignal(SignalName.OnLifeChanged, _currentLife); // appeler le signal
	}
}
