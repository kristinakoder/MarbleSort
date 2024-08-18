using Godot;
using System;

public partial class TubScript : Node3D
{
	private Area3D area;
	/*
	1. Skal sjekke om en marble er rett farge
	2. Skal kunne farge bunnen til fargen som skal i
	3. Skal vite om alle marbles i rett farge er i 
	*/

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		area = GetNode<Area3D>("Area3D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		

	}
}
