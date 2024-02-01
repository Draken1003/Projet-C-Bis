using Godot;
using System;

public partial class HUD : Control
{
	
	[Export] private Life _life = null;
	[Export] private ProgressBar _bar = null;

    public override void _Ready()
    {
        _life.OnLifeChanged += OnLifeChanged;
    }
    private void OnLifeChanged(float newLife)
	{
		_bar.Value = _life.LifePrecent;
	}


}
