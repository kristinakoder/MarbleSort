using Godot;
using System;

public partial class player : CharacterBody3D
{
	private Camera3D camera;
	private RayCast3D raycast;
	public const float Speed = 8.0f;
	public const float JumpVelocity = 8f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	public float sensitivity = 0.002f;



	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		camera = GetNode<Camera3D>("Camera3D");
		raycast = GetNode<RayCast3D>("Camera3D/RayCast3D");
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			RotateY(-mouseMotion.Relative.X * sensitivity);
			camera.Rotation = new Vector3(
				Mathf.Clamp(camera.Rotation.X - mouseMotion.Relative.Y * sensitivity, -1.5f, 1.5f), 0, 0);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		//Handle mouseclick
		if (Input.IsActionJustPressed("leftClick"))
		{
			if (raycast.IsColliding())
			{
				var collider = raycast.GetCollider();
				if (collider is GridMap gridmap)
				{
					Vector3 blockPosition = raycast.GetCollisionPoint() - raycast.GetCollisionNormal();
                	gridmap.DestroyBlock(blockPosition);
				}
			}
		}
		
		if (Input.IsActionJustPressed("rightClick"))
		{
			if (raycast.IsColliding())
			{
				var collider = raycast.GetCollider();
				if (collider is GridMap gridmap)
				{
					Vector3 blockPosition = raycast.GetCollisionPoint() + raycast.GetCollisionNormal();
					gridmap.PlaceBlock(blockPosition, 1);
				}
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
