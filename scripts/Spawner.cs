using Godot;
using System;

public partial class Spawner : Node3D
{
	private int NumberOfMarbles = 500;
	private int NumberOfColors = 6;
	public override void _Ready()
	{
		AddMarbles(NumberOfMarbles);
	}

	private void AddMarbles(int NumberOfMarbles)
	{
		for (int i = 0; i < NumberOfMarbles; i++)
		{
			var scene = GD.Load<PackedScene>("res://scenes/marble.tscn");
			Marble marble = (Marble) scene.Instantiate();
			marble.Position = RandomPosition();
			MakeUnique(marble);
			AddChild(marble);
		}
	}

    private void MakeUnique(Marble marble) 
    {
        MeshInstance3D mesh = marble.GetNode<MeshInstance3D>("MeshInstance3D");
        StandardMaterial3D material = new() { AlbedoColor = RandomColor(), Roughness = 0.3f };
        mesh.Mesh.SurfaceSetMaterial(0, material);
    }

    private Color RandomColor() => new(GetRandom(), GetRandom(), GetRandom());

	private float GetRandom() => (float) new Random().NextDouble();

	private float RandomCoordinate() => (GetRandom() - 0.5f) * 20;

	private Vector3 RandomPosition() => new Vector3(RandomCoordinate(), 10 + RandomCoordinate(), RandomCoordinate() * 2);
}