using Godot;
using System;


public partial class Coin : Area2D
{
	// Called when the node enters the scene tree for the first time.

	private float Bob_height = 0.5f;
	private float Bob_speed = 2f;

	private float Start_Y;
	private float Start_X;
	public override void _Ready()
	{
		Start_Y = GlobalPosition.Y;
		Start_X = GlobalPosition.X;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float d = (float)(Mathf.Sin(delta * Bob_speed) + 1) / 2;
		Position = new Vector2(Start_X,Start_Y + (d * Bob_height));
	}
}
