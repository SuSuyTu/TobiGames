using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGround : GroundCtrl
{
    [SerializeField] public Color winnerColor;
    protected override void LoadGridManager()
    {
        if (this.gridManager == null) return;
        base.LoadGridManager();
    }

    protected override void LoadBrickManager()
    {
        if (this.brickManager == null) return;
        base.LoadBrickManager();
    }

    protected override void LoadColorManager()
    {
        base.LoadColorManager();
        winnerColor = this.colorManager.ColorSpawnList[0];
        Debug.Log(winnerColor);
    }
}
