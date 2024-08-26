using Godot;
using System;

public partial class Marble : RigidBody3D
{	
	public int ColorId { get; set; }
	private StandardMaterial3D red, green, blue, yellow, purple, orange;


    public override void _Ready()
    {

    }

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
	//destroy if it moves off the table. But as a trigger, so all marbles don't check the need to be destroyed all the time?

	private Color RandomColor() => new(GetRandom(), GetRandom(), GetRandom());
	private float GetRandom() => (float) new Random().NextDouble();
}