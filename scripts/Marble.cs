using Godot;
using System;

public partial class Marble : RigidBody3D
{
	//color id?


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	//method for moving the clicked one
	public void MoveMarble()
	{
		GD.Print("Marble clicked");
		Vector2 mousePosition = GetViewport().GetMousePosition(); //men må oppdateres kontinuerlig.
		GD.Print(mousePosition);
	}
}
