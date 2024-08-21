using Godot;
using System;

public partial class Marble : RigidBody3D
{	
	private int ColorId { get; set; }
    public override void _Ready()
    {
    }

	public void MoveMarble(Vector3 worldMousePos)
	{
		Position = worldMousePos; 
	}

	//destroy if it moves off the table. But trigger, not all marbles check if the need to be destroyed all the time

	private Color RandomColor() => new(GetRandom(), GetRandom(), GetRandom());
	private float GetRandom() => (float) new Random().NextDouble();
}