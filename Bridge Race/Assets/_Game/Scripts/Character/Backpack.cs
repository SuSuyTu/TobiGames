using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] protected Stack<Brick> brickStack = new Stack<Brick>();
    public Stack<Brick> BrickStack => brickStack;
    [SerializeField] protected float stackFallRadius;
    protected Vector2Int brickCoordinate;

    // protected virtual void Start()
    // {
    //     Invoke(nameof(RemoveAllStack), 10f);
    // }

    public virtual void AddStack(GameObject brick)
    {
        Vector3 brickPos = brick.transform.localPosition;
        brickCoordinate = new Vector2Int((int)brickPos.x, (int)brickPos.z);

        //PlayerCtrl.Instance.PlayerGameSession.CurrentGridManager.Grid[brickCoordinate].isPickedUp = true;
        PlayerCtrl.Instance.PlayerGameSession.CurrentGridManager.Grid[brickCoordinate].isSpawned = false;
        PlayerCtrl.Instance.PlayerGameSession.CurrentBrickManager.AddUnspawnedGridPosition(brickCoordinate);
        PlayerCtrl.Instance.PlayerGameSession.CurrentBrickManager.AddPickedUpBrickColor(brick.GetComponent<Brick>().Color);

        if (IsAlreadyHasBricksStack())
        {
            brick.transform.position = this.transform.position;
            brick.transform.SetParent(this.transform);
        }
        else
        {
            Vector3 newPos = brickStack.Peek().transform.position;
            newPos.y += 0.5f;  
            brick.transform.position = newPos;
            brick.transform.SetParent(this.transform);
        }

        brick.transform.localRotation = Quaternion.Euler(0, 90, 0);
        brickStack.Push(brick.GetComponent<Brick>());

    }

    public virtual void AddFallenStack(GameObject brick)
    {
        brick.tag = "Brick";
        brick.name = PlayerCtrl.Instance.Color.ToString();
        brick.GetComponent<MeshRenderer>().material.color = PlayerCtrl.Instance.UnityColor;
        brick.GetComponent<Brick>().SetColor(PlayerCtrl.Instance.Color);
        if (IsAlreadyHasBricksStack())
        {
            brick.transform.position = this.transform.position;
            brick.transform.SetParent(this.transform);
        }
        else
        {
            Vector3 newPos = brickStack.Peek().transform.position;
            newPos.y += 0.5f;  
            brick.transform.position = newPos;
            brick.transform.SetParent(this.transform);
        }

        brick.transform.localRotation = Quaternion.Euler(0, 90, 0);
        brickStack.Push(brick.GetComponent<Brick>());
    }

    public virtual bool IsAlreadyHasBricksStack()
    {
        return brickStack.Count == 0;
    }

    public virtual void RemoveStack()
    {
        int brickCount = this.transform.childCount;
        if (brickCount == 0)
        {
            Debug.Log("Cannot remove stack");
            return;
        }

        GameObject topBrick = this.transform.GetChild(brickCount - 1).gameObject;
        brickStack.Pop();
        BrickSpawner.Instance.Despawn(topBrick.transform);
    }

    public virtual void RemoveAllStack()
    {
        int brickCount = brickStack.Count;
        //if (brickCount == 0) return;

        while (!IsAlreadyHasBricksStack())
        {
            Brick fallenBrick = brickStack.Pop();
            fallenBrick.gameObject.tag = "Fallen Brick";
            BrickSpawner.Instance.Hold(fallenBrick.transform);
            fallenBrick.SetColor(Color.NoColor);
            fallenBrick.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.gray;
            fallenBrick.gameObject.name = "Fallen Brick";

            BrickFall(fallenBrick.transform);
        }
    }

    public virtual void BrickFall(Transform brick)
    {
        float x = Random.Range(-2, 2) * stackFallRadius;
        float z = Random.Range(-2, 2) * stackFallRadius;
        Vector3 fallPos = new Vector3(x, 0.07f, z) + new Vector3(transform.position.x, 0, transform.position.z);
        brick.transform.position = fallPos;
        brick.transform.rotation = Quaternion.identity;
    }
}
