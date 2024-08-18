using Godot;
using System;

public partial class GridMap : Godot.GridMap
{
	public void DestroyBlock(Vector3 worldCoordinate)
	{
		Vector3I mapCoordinate = LocalToMap(worldCoordinate);
		SetCellItem(mapCoordinate, -1);
	}

	public void PlaceBlock(Vector3 worldCoordinate, int blockIndex)
	{
		Vector3I mapCoordinate = LocalToMap(worldCoordinate);
		SetCellItem(mapCoordinate, blockIndex);
	}
}