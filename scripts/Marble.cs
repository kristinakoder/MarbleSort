using Godot;
using System;

public partial class Marble : RigidBody3D
{
	//needs world position, not MousePosition. Get from InteractManager when it calls a method?
	
    public override void _IntegrateForces(PhysicsDirectBodyState3D state)
    {
    }

	//method for moving the clicked one
	public void MoveMarble(float x, float z)
	{
		GD.Print("Pos1: " + Position);
		Position = new Vector3(x, 10f, z); //doesn't work when in motion
		GD.Print("Pos2: " + Position);
	}	
}