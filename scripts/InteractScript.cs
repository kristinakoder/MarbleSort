using Godot;
using System;

public partial class InteractScript : Camera3D
{
	private bool isHoldingMarble = false;
	private Marble selectedMarble;
	PhysicsDirectSpaceState3D worldSpace;

    public override void _Ready()
    {
        base._Ready();
		worldSpace = GetWorld3D().DirectSpaceState;
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
		Vector3 end = ProjectPosition(GetViewport().GetMousePosition(), 100);
		var result = worldSpace.IntersectRay(PhysicsRayQueryParameters3D.Create(Position, end));

		var collider = (Node) result["collider"];
		if (collider is Marble marble)
		{
			selectedMarble = marble;
			isHoldingMarble = true;
		}
	}

	public void MoveMarble()
	{
		Vector3 worldMousePos = ProjectPosition(GetViewport().GetMousePosition(), 24);
		selectedMarble.MoveMarble(worldMousePos);
	}
}