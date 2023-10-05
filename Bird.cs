using Godot;
using System;

public partial class Bird : CharacterBody2D
{

	[Signal]
	public delegate void AddScoreEventHandler();
	[Signal]
	public delegate void BirdDiedEventHandler(int scoreToAdd);
	[Export]
	public float flapStrenght = -500;
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready(){

	}

	public override void _PhysicsProcess(double delta){
		Vector2 myVelocity = Velocity;
		myVelocity.Y += Gravity*(float)delta;
		if(Input.IsActionJustPressed("flap")){
			myVelocity.Y = flapStrenght;
		}
		Velocity = myVelocity;
		MoveAndSlide();
	}
	public void OnCollision(Rid areaRid, Node2D area, long areaShapeIndex, long localShapeIndex){
		GD.Print(areaShapeIndex);
		if(areaShapeIndex == 2){
			EmitSignal(SignalName.AddScore, 2);
		} else {
			EmitSignal(SignalName.BirdDied);
		}
	}
}
