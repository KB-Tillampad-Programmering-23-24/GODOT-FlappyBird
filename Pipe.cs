using Godot;
using System;

public partial class Pipe : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = new Vector2(-200,0);
		Position += velocity*(float)delta;
	}

	public void PipeExitedScreen(){
		QueueFree();
	}
}
