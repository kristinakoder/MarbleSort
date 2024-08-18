using Godot;
using System;

public partial class TubScript : Node3D
{
	//needs to check if all marbles of the right color is in the tub, and none of the wrong colors.
	private Area3D area;

	public override void _Ready()
	{
		area = GetNode<Area3D>("Area3D");
	}

	public override void _Process(double delta)
	{
		

	}
}
