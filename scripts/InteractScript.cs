using Godot;
using System;

public partial class InteractScript : Camera3D
{
	public override void _Input(InputEvent @event)
    {
		if (Input.IsActionJustPressed("leftClick")) //without 'Just' it is when pressed continuously?
			GetSelection();
    }

	public void GetSelection()
	{
		PhysicsDirectSpaceState3D worldSpace = GetWorld3D().DirectSpaceState;
		//GetViewport().GetMousePosition()); gives the mouse position in screen coordinates
		Vector3 start = ProjectRayOrigin(GetViewport().GetMousePosition()); //gives the position of the camera, not where you clicked.
		GD.Print("start: " + start);
		GD.Print("mousePos: " + GetViewport().GetMousePosition());
		Vector3 end = ProjectPosition(GetViewport().GetMousePosition(), 1000);
		GD.Print("end: " + end);
		var result = worldSpace.IntersectRay(PhysicsRayQueryParameters3D.Create(start, end));

		var collider = (Node) result["collider"];
		GD.Print("Result: " + result);
		if (collider is Marble marble)
		{
			GD.Print("Position: " + Position);
			marble.MoveMarble(start.X, start.Z); //only happens the moment you click, not when drag, and doesn't go to point clicked.
		}
	}
}

/*
WORKING ON: Making click-and-drag marble work.
Found out 'start' gives the position of this object, not mouseposition? Why not use Position?
Need the position of the cursor in worldspace. 

Then:
Need to find out how to hold marble when it is in motion

*/