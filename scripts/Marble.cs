using Godot;
using System;

public partial class Marble : RigidBody3D
{
	//needs world position, not MousePosition. Get from InteractManager when it calls a method?
	
    public override void _IntegrateForces(PhysicsDirectBodyState3D state)
    {
    }

	//method for moving the clicked one
	public void MoveMarble(Vector3 worldMousePos)
	{
		Position = worldMousePos; //doesn't work when in motion
	}	
}