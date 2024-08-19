using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBackpack : Backpack
{
    [SerializeField] protected BotCtrl botCtrl;
    protected Stack<Brick> botBrickStack = new Stack<Brick>();
    public Stack<Brick> BotBrickStack => botBrickStack;
    public override void AddStack(GameObject brick)
    {
        Vector3 brickPos = brick.transform.localPosition;
        brickCoordinate = new Vector2Int((int)brickPos.x, (int)brickPos.z);

        botCtrl.BotGameSession.CurrentGridManager.Grid[brickCoordinate].isSpawned = false;
        botCtrl.BotGameSession.CurrentBrickManager.AddUnspawnedGridPosition(brickCoordinate);
        botCtrl.BotGameSession.CurrentBrickManager.AddPickedUpBrickColor(brick.GetComponent<Brick>().Color);

        if (IsAlreadyHasBricksStack())
        {
            brick.transform.position = this.transform.position;
            brick.transform.SetParent(this.transform);
        }
        else
        {
            Vector3 newPos = this.botBrickStack.Peek().transform.position;
            newPos.y += 0.5f;  
            brick.transform.position = newPos;
            brick.transform.SetParent(this.transform);
        }

        brick.transform.localRotation = Quaternion.Euler(0, 90, 0);
        this.botBrickStack.Push(brick.GetComponent<Brick>());
    }

    public override void AddFallenStack(GameObject brick)
    {
        brick.tag = "Brick";
        brick.name = botCtrl.Color.ToString();
        brick.GetComponent<MeshRenderer>().material.color = botCtrl.UnityColor;
        brick.GetComponent<Brick>().SetColor(botCtrl.Color);
        if (IsAlreadyHasBricksStack())
        {
            brick.transform.position = this.transform.position;
            brick.transform.SetParent(this.transform);
        }
        else
        {
            Vector3 newPos = botBrickStack.Peek().transform.position;
            newPos.y += 0.5f;  
            brick.transform.position = newPos;
            brick.transform.SetParent(this.transform);
        }

        brick.transform.localRotation = Quaternion.Euler(0, 90, 0);
        botBrickStack.Push(brick.GetComponent<Brick>());
    }

    public override void RemoveStack()
    {
        int brickCount = this.transform.childCount;
        if (brickCount == 0)
        {
            Debug.Log("Cannot remove stack");
            return;
        }

        GameObject topBrick = this.transform.GetChild(brickCount - 1).gameObject;
        this.botBrickStack.Pop();
        BrickSpawner.Instance.Despawn(topBrick.transform);
    }
    public override bool IsAlreadyHasBricksStack()
    {
        return this.botBrickStack.Count == 0;
    }
}
