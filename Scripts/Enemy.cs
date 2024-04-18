using Godot;
using System;

public partial class Enemy : Area2D
{
	[Export]
	private float Speed;

	[Export] private Vector2 Direction;

	private Vector2 StartPos;

	private Vector2 DestinationPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartPos = GlobalPosition;
		DestinationPos = StartPos + Direction;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = GlobalPosition.MoveToward(DestinationPos, Speed * (float)delta);

		if (GlobalPosition == DestinationPos)
		{
			if (GlobalPosition == StartPos)
			{
				DestinationPos = StartPos + Direction;
			}
			else
			{
				DestinationPos = StartPos;
			}
		}
	}

	private void _on_body_entered(Player body)
	{
		if (body.IsInGroup("Player"))
		{
			body.GameOver();
		}
	}
}
