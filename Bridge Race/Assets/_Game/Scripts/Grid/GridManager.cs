using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : NewMonoBehaviour
{
    [Header("Brick Spawn Size")]
    [SerializeField] protected Vector2Int gridSize;
    public Vector2Int GridSize => gridSize;

    [Header("BrickSpawnPoint")]
    [SerializeField] protected int startPointX;
    [SerializeField] protected int startPointZ;

    protected int tempStartPointZ;

    protected Dictionary<Vector2Int, BrickSpawnPoint> grid = new Dictionary<Vector2Int, BrickSpawnPoint>();
    public Dictionary<Vector2Int, BrickSpawnPoint> Grid => grid;

    protected override void Awake() 
    {
        Time.timeScale = 1;
        CreateGrid();
        base.Awake();
    }

    protected virtual void CreateGrid()
    {
        tempStartPointZ = startPointZ;
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(startPointX, startPointZ);
                grid.Add(coordinates, new BrickSpawnPoint(coordinates, false));

                startPointZ += 2;
            }
            startPointZ = tempStartPointZ;
            startPointX += 2;
        }
    }

    public Vector2Int GetRandomSpawnPoint()
    {
        List<Vector2Int> coordinates = new List<Vector2Int>(grid.Keys);

        System.Random random = new System.Random();
        int randomIndex = random.Next(coordinates.Count);
        Vector2Int coordinate = coordinates[randomIndex];

        if (grid[coordinate].isSpawned) return new Vector2Int(0, 0);

        return coordinate;
    }

    public Vector2Int GetRandomPoint()
    {
        List<Vector2Int> coordinates = new List<Vector2Int>(grid.Keys);

        System.Random random = new System.Random();
        int randomIndex = random.Next(coordinates.Count);
        Vector2Int coordinate = coordinates[randomIndex];

        if (!grid[coordinate].isSpawned) return new Vector2Int(0, 0);

        return coordinate;
    }

    public virtual BrickSpawnPoint GetBrickSpawnPoint(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }

    public virtual Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x);
        coordinates.y = Mathf.RoundToInt(position.z);

        return coordinates;
    }

    public virtual Vector3 GetPostionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x;
        position.z = coordinates.y;

        return position;
    }
}
