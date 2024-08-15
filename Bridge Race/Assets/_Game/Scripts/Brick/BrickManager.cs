using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickManager : NewMonoBehaviour
{
    [SerializeField] protected GroundCtrl groundCtrl;
    [SerializeField] protected Queue<Vector2Int> unspawnedGrid = new Queue<Vector2Int>();
    public Queue<Vector2Int> UnspawnedGrid => unspawnedGrid;
    [SerializeField] protected List<Color> pickedUpBrickColor = new List<Color>();
    public List<Color> PickedUpBrickColor => pickedUpBrickColor;
    [SerializeField] protected List<Transform> spawnedBricks = new List<Transform>();
    public List<Transform> SpawnedBricks => spawnedBricks;
    [SerializeField] protected float groundHeight;

    [SerializeField] protected bool isStartOfTheStage;
    [SerializeField] protected int brickPerCharacter;
    [SerializeField] protected int characterCount;
    [SerializeField] protected float brickSpawnTime;
    protected override void Reset()
    {
        base.Reset();
        LoadGroundCtrl();
    }
    protected virtual void LoadGroundCtrl()
    {
        if (this.groundCtrl != null) return;
        this.groundCtrl = GetComponentInParent<GroundCtrl>();
        Debug.LogWarning(transform.name + ": LoadGroundCtrl", gameObject);
    }
    protected override void Awake()
    {
        base.Awake();
        if (isStartOfTheStage)
        {
            StartCoroutine(nameof(SpawnBrickGrid));
        }
    }

    protected virtual void LateUpdate() 
    {
        if (isStartOfTheStage)
        {
            StartCoroutine(nameof(SpawnBrickGrid));
        }
        if (isStartOfTheStage || unspawnedGrid.Count == 0 || pickedUpBrickColor.Count == 0 || groundCtrl.ColorManager.ColorSpawnList.Count == 0) return;
        StartCoroutine(nameof(RespawnBrick));
    }

    public virtual IEnumerator SpawnBrickGrid()
    {
        yield return null;
        for(int i = 0; i < groundCtrl.ColorManager.ColorSpawnList.Count; i++)
        {
            for(int j = 0; j < brickPerCharacter; j++)
            {
                Vector2Int position = groundCtrl.GridManager.GetRandomSpawnPoint();
                if (!position.Equals(Vector2Int.zero))
                {
                    Vector3 spawnPos = new Vector3(position.x, 
                                                    groundHeight + 0.06934825f, 
                                                    position.y);
                    BrickSpawnPoint brickSpawnPoint = groundCtrl.GridManager.Grid[position];
                    brickSpawnPoint.isSpawned = true;
                    brickSpawnPoint.color = groundCtrl.ColorManager.ColorSpawnList[i];

                    Transform newBrick = BrickSpawner.Instance.Spawn(brickSpawnPoint.color.ToString(), spawnPos, Quaternion.Euler(0, 90, 0));
                    newBrick.gameObject.SetActive(true);
                    spawnedBricks.Add(newBrick);
                }
                else
                {
                    j--;
                }
            }
        }
        isStartOfTheStage = false;
    }

    protected IEnumerator RespawnBrick()
    {
        yield return new WaitForSecondsRealtime(brickSpawnTime);

        int index = GetRandomColorIndexFromPickedUpColor();
        //Debug.Log(index + " of " + pickedUpBrickColor.Count);
        if (index != -1 && unspawnedGrid.Count != 0) 
        {
            Vector2Int nextSpawnPos = unspawnedGrid.Dequeue();
            Vector3 spawnPos = new Vector3(nextSpawnPos.x, 
                                        groundHeight + 0.06934825f, 
                                        nextSpawnPos.y);

            BrickSpawnPoint brickSpawnPoint = groundCtrl.GridManager.Grid[nextSpawnPos];
            brickSpawnPoint.color = pickedUpBrickColor[index];
            brickSpawnPoint.isSpawned = true;
            pickedUpBrickColor.RemoveAt(index);
            Transform newBrick = BrickSpawner.Instance.Spawn(brickSpawnPoint.color.ToString(), spawnPos, Quaternion.Euler(0, 90, 0));
            newBrick.gameObject.SetActive(true);
        }

        // Transform newBrick = BrickSpawner.Instance.Spawn(brickSpawnPoint.color.ToString(), spawnPos, Quaternion.Euler(0, 90, 0));
        // newBrick.gameObject.SetActive(true);
        
        StopAllCoroutines();
    }

    public virtual void AddUnspawnedGridPosition(Vector2Int position)
    {
        if (!unspawnedGrid.Contains(position))
        {
            unspawnedGrid.Enqueue(position);
        }
    }

    public virtual void AddPickedUpBrickColor(Color color)
    {
        PickedUpBrickColor.Add(color);
    }

    protected virtual int GetRandomColorIndexFromPickedUpColor()
    {
        if (pickedUpBrickColor.Count == 0) return -1;
        int index = Random.Range(0, pickedUpBrickColor.Count);
        return index;
    }

    public virtual void RemoveColor(Color characterColor)
    {
        PickedUpBrickColor.RemoveAll(color => color == characterColor);
        foreach (BrickSpawnPoint brickSpawnPoint in groundCtrl.GridManager.Grid.Values.ToList<BrickSpawnPoint>())
        {
            if (brickSpawnPoint.color == characterColor)
            {
                if (GetBrickFromCoordinate(brickSpawnPoint.coordinates) == null) return;
                BrickSpawner.Instance.Despawn(GetBrickFromCoordinate(brickSpawnPoint.coordinates));
            }
        }
    }

    protected virtual Transform GetBrickFromCoordinate(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x;
        position.z = coordinates.y;

        foreach (Transform brick in SpawnedBricks)
        {
            if (brick.position.x == position.x && brick.position.z == position.z)
            {
                return brick;
            }
        }
        return null;
    }
    public virtual void IsStartOfTheStage()
    {
        isStartOfTheStage = true;
    }

}
