using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BlockWithBonus : BlockScript
{
    [SerializeField]
    private GameObject bonusPrefab;
    [SerializeField]
    private Color backgroundColor;
    [SerializeField]
    private Color textColor;
    [SerializeField]
    private string text;
    

    protected new void Start() {
        base.Start();
    }

    protected override void OnBlockDestroy()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        GameObject bonusObject = Instantiate(bonusPrefab, position, rotation);
        var bonus = Random.Range(0, 4);
        if (bonus == 0)
        {
            BonusBase bonusScriptObject = bonusObject.AddComponent<BonusBase>();
            bonusScriptObject.backgroundColor = backgroundColor;
            bonusScriptObject.text = text;
            bonusScriptObject.player = playerScript;
            bonusScriptObject.textColor = textColor;
        }
        else if (bonus == 1)
        {
            BonusFire bonusScriptObject = bonusObject.AddComponent<BonusFire>();
            bonusScriptObject.backgroundColor = new Color(1, 0.5f, 0);
            bonusScriptObject.text = "Fire";
        }
        else if (bonus == 2)
        {
            BonusSteel bonusScriptObject = bonusObject.AddComponent<BonusSteel>();
            bonusScriptObject.backgroundColor = Color.grey;
            bonusScriptObject.text = "Steel";
        }
        else if (bonus == 3)
        {
            BonusNorm bonusScriptObject = bonusObject.AddComponent<BonusNorm>();
            bonusScriptObject.backgroundColor = Color.white;
            bonusScriptObject.text = "Norm";
        }

        base.OnBlockDestroy();
    }
}
