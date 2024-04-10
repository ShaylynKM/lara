using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VineCutting : MonoBehaviour
{
    public Sprite cutSprite; // Assign the cut sprite in the inspector

    private Sprite originalSprite;
    public bool isCut = false;
    private SpriteRenderer spriteRenderer;

    public UnityEvent SecateursSnipped;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scissors") && !isCut)
        {
            CutVine();
        }
    }

    private void CutVine()
    {
        isCut = true;
        // Change sprite to indicate that the vine is cut
        spriteRenderer.sprite = cutSprite;
        // Add any additional logic here, e.g., play sound effects, trigger particle effects, etc.
    }

    public void ResetVine(Sprite originalSprite)
    {
        isCut = false;
        spriteRenderer.sprite = originalSprite;
    }
}