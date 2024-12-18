using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    public string text = "+100";
    public Color backgroundColor = Color.yellow;
    public Color textColor = Color.black;
    public Text textComponent;
    public PlayerScript player;
    private SpriteRenderer spriteRenderer;
    public BallScript[] ballScripts;

    protected void Start() {
        textComponent = GetComponentInChildren<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballScripts = FindObjectsOfType<BallScript>();
        UpdateSpriteAndText();
    }

    public void UpdateSpriteAndText() {
        if (spriteRenderer is not null) {
            spriteRenderer.color = backgroundColor;
        }

        if (textComponent is not null) {
            textComponent.text = text;
            textComponent.color = textColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.tag;
        if (tag == "Player")
            {
                BonusActivate();
                Destroy(gameObject);
            }
    }

    public virtual void BonusActivate() {
        
        player.gameData.points += 100;
    }
}
