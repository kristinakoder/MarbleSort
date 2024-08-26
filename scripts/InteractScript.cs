using Godot;
using System;

public partial class InteractScript : Camera3D
{
	private bool isHoldingMarble = false;
	private Marble selectedMarble;
	PhysicsDirectSpaceState3D worldSpace;

	private Vector2 windowSize;

    public override void _Ready()
    {
		windowSize = DisplayServer.WindowGetSize();
		worldSpace = GetWorld3D().DirectSpaceState;
		var vp = GetViewport().GetVisibleRect();
    }

    public override void _Input(InputEvent @event)
    {
		if (Input.IsActionJustPressed("leftClick"))
			GetSelection();

		if (isHoldingMarble && Input.IsActionPressed("leftClick"))
		{
			selectedMarble.Freeze = true;
			MoveMarble();
		}

		if (Input.IsActionJustReleased("leftClick"))
		{
			isHoldingMarble = false;
			selectedMarble.Freeze = false;
		}
    }

	public void GetSelection()
	{
		Vector3 start = ProjectRayOrigin(GetViewport().GetMousePosition());
		Vector3 end = ProjectPosition(GetViewport().GetMousePosition(), 100);
		var result = worldSpace.IntersectRay(PhysicsRayQueryParameters3D.Create(start, end));

		var collider = (Node) result["collider"];
		if (collider is Marble marble)
		{
			selectedMarble = marble;
			isHoldingMarble = true;
		}
	}

	public void MoveMarble()
	{
		Vector3 worldMousePos = ProjectPosition(GetViewport().GetMousePosition(), 26);
		selectedMarble.MoveMarble(worldMousePos);
	}
}