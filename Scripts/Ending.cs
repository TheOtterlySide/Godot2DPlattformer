using Godot;
using System;

public partial class Ending : Area2D
{
	[Export(PropertyHint.File, "*.tscn")]
	public string LevelScene { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player") && body is Player player)
		{
			GetTree().ChangeSceneToFile(LevelScene);
		}
	}
}
