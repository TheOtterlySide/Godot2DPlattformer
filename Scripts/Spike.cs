using Godot;
using System;

public partial class Spike : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		if (body.IsInGroup("Player") && body is Player player)
		{
			player.GameOver();
		}
	}
}
