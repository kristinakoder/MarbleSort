using Godot;
using System;

public partial class Spawner : Node3D
{
	private int NumberOfMarbles = 480;
	private int NumberOfColors = 6;

	private StandardMaterial3D mat0, mat1, mat2, mat3, mat4, mat5;
	public override void _Ready()
	{
		mat0 = GD.Load<StandardMaterial3D>("res://materials/mat0.tres");
		mat1 = GD.Load<StandardMaterial3D>("res://materials/mat1.tres");
		mat2 = GD.Load<StandardMaterial3D>("res://materials/mat2.tres");
		mat3 = GD.Load<StandardMaterial3D>("res://materials/mat3.tres");
		mat4 = GD.Load<StandardMaterial3D>("res://materials/mat4.tres");
		mat5 = GD.Load<StandardMaterial3D>("res://materials/mat5.tres");
		AddMarbles(NumberOfMarbles);
	}

	private void AddMarbles(int NumberOfMarbles)
	{
		int n = 0;
		for (int i = 0; i < NumberOfMarbles; i++)
		{
			int numberOfEachColor = NumberOfMarbles / NumberOfColors;
			if (i % numberOfEachColor == 0) n++;
			var scene = GD.Load<PackedScene>("res://scenes/marble.tscn");
			Marble marble = (Marble) scene.Instantiate();
			marble.Position = RandomPosition();
			marble.ColorId = n;
			SetMaterial(marble, n);
			AddChild(marble);
		}
	}

	public override void _Input(InputEvent @event)
    {
		if (Input.IsActionJustPressed("rightClick"))
			mat0.AlbedoColor = RandomColor();
    }

	private void SetMaterial(Marble marble, int n)
	{
		StandardMaterial3D mat;
		switch(n)
		{
			case 1: mat = mat0;
			break;
			case 2: mat = mat1;
			break;
			case 3: mat = mat2;
			break;
			case 4: mat = mat3;
			break;
			case 5: mat = mat4;
			break;
			default: mat = mat5;
			break;
		}
		MeshInstance3D mesh = marble.GetNode<MeshInstance3D>("MeshInstance3D");
		mesh.Mesh.SurfaceSetMaterial(0, mat);
	}

    private Color RandomColor() => new(GetRandom(), GetRandom(), GetRandom());

	private float GetRandom() => (float) new Random().NextDouble();

	private float GetRandom(int min, int max)
	{
		return GetRandom();
	}

	private float RandomCoordinate() => (GetRandom() - 0.5f) * 20;

	private Vector3 RandomPosition() => new Vector3(RandomCoordinate(), 7, RandomCoordinate() * 2);
}