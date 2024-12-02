using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFire : BonusBase
{
    protected new void Start()
    {
        base.Start();
        ballScripts = FindObjectsOfType<BallScript>();
    }

    public override void BonusActivate() {
        foreach (var bs in ballScripts)
        {
            if (bs == null) {
                continue;
            }
            bs.spriteRenderer.color = new Color(1f, 0.5f, 0f);
            bs.damage = 4;
        }
    }
}
