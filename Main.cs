using Godot;
using System;
using System.Threading;

public partial class Main : Node
{
    [Export]
    public PackedScene pipeScene {get;set;}
    int score;
    public override void _Ready(){
        NewGame();
    }

    public void NewGame(){
        score = 0;
        var player = GetNode<Bird>("Bird");
        var startPosition = GetNode<Marker2D>("BirdSpawnPosition");

        player.Position = startPosition.Position;

        GetNode<Godot.Timer>("Timer").Start();
    }

    private void OnPipeSpawn(){
        Pipe pipe = pipeScene.Instantiate<Pipe>();
        var pipeSpawn = GetNode<Marker2D>("PipeSpawnPosition");
        var position = pipeSpawn.Position;
        position.Y += Mathf.Round(GD.RandRange(-12,12))*9;
        pipe.Position = position;
        AddChild(pipe);
    }

    public void OnBirdDied(){
        GD.Print("bird died");
        var tree = GetTree();
        tree.Paused = true;
        Thread.Sleep(1000);
        tree.ReloadCurrentScene();
        tree.Paused = false;
    }

    public void OnAddScore(int scoreToAdd){
        score += scoreToAdd;
        GD.Print("score: " + score);
    }
}
