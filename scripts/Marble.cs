using Godot;
using System;

public partial class Marble : RigidBody3D
{
	//color? Then group by color

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	//method for moving the clicked one
	public void MoveMarble()
	{
		GD.Print("Marble clicked");
		Vector2 mousePosition = GetViewport().GetMousePosition(); //needs to update continuously, so in process?
		GD.Print(mousePosition);
		GD.Print(Position);
		Position = new Vector3(mousePosition.X, 10f, mousePosition.Y); //need to change from mousePosition to world position
	}
}