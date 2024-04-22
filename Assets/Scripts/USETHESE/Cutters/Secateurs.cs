using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Secateurs : MonoBehaviour
{
    private float zValue = 0f;

    [SerializeField]
    private Sprite open;

    [SerializeField]
    private Sprite closed;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
;       spriteRenderer.sprite = open;
    }

    private void Update()
    {
        // Makes the secateurs follow the mouse. Cannot put it down like in the freetranslate script.

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = zValue;
        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }

        if(Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
    }

    public void MakeInvisible()
    {
        this.gameObject.SetActive(false); // Makes the secateurs invisible after solving the puzzle. Called by PathClear event on LadybugVinePuzzle.cs
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = closed;
    }

    private void OnMouseUp()
    {
        spriteRenderer.sprite = open;
    }

}
