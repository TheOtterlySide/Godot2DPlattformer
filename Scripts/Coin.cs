using Godot;
using System;


public partial class Coin : Area2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	private float Bob_height;
	[Export]
	private float Bob_speed;


	private Vector2 DestinationPos;
	private Vector2 StartPos;
	public override void _Ready()
	{
		StartPos = GlobalPosition;
		DestinationPos = new Vector2(StartPos.X, StartPos.Y + Bob_height);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = GlobalPosition.MoveToward(DestinationPos, Bob_speed * (float)delta);

		if (GlobalPosition == DestinationPos)
		{
			if (GlobalPosition == StartPos)
			{
				DestinationPos = new Vector2(StartPos.X, StartPos.Y + Bob_height);
			}
			else
			{
				DestinationPos = StartPos;
			}
		}
	}

	private void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player") && body is Player player)
		{
			player.AddScore(1);
			QueueFree();
		}
	}
}
