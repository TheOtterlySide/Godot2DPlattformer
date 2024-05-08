using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float Speed = 100f;
    private float JumpForce = 200f;
    private float Gravity = 500f;

    private int Score;

    private Vector2 StartPos;
    public override void _Ready()
    {
        StartPos = GlobalPosition;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        velocity.Y += Gravity * (float)delta;

        // Handle jump.
        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            velocity.Y = -JumpForce;
        }

        // Get the input direction.
        float direction = Input.GetAxis("MoveLeft", "MoveRight");
        velocity.X = direction * Speed;

        Velocity = velocity;
        MoveAndSlide();

        if (GetGlobalMousePosition().Y > 100f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GlobalPosition = StartPos;
        GetTree().CallDeferred("reload_current_scene");
    }

    public void AddScore(int amount)
    {
        Score += amount;
        GD.Print(Score);
    }
}

