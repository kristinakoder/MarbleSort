using Godot;
using System;

public partial class Marble : RigidBody3D
{	
	public int ColorId { get; set; }

    public override void _Process(double delta)
    {
		if (Position.Y < 0)
		{
			Position = new(0,5,0);
		}
    }

    public void MoveMarble(Vector3 worldMousePos)
	{
		Position = worldMousePos; 
	}
}