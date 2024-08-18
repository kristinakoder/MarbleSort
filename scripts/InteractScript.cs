using Godot;
using System;

public partial class InteractScript : Camera3D
{
	public override void _Input(InputEvent @event)
    {
		if (Input.IsActionJustPressed("leftClick"))
			GetSelection();
    }

	public void GetSelection()
	{
		PhysicsDirectSpaceState3D worldSpace = GetWorld3D().DirectSpaceState;
		Vector3 start = ProjectRayOrigin(GetViewport().GetMousePosition());
		Vector3 end = ProjectPosition(GetViewport().GetMousePosition(), 1000);
		var result = worldSpace.IntersectRay(PhysicsRayQueryParameters3D.Create(start, end));

		var collider = (Node) result["collider"];
		if (collider is Marble marble)
			marble.MoveMarble();
	}
}