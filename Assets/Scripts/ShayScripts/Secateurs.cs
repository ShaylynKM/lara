using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;

public class Secateurs : MonoBehaviour
{
    public ChangeVine changeVine;

    private Collider2D vineCollider;

    private float zValue = 0f;


    private void Awake()
    {
        changeVine = (ChangeVine)GameObject.FindObjectOfType(typeof(ChangeVine));


        vineCollider = changeVine.GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = zValue;
        transform.position = mousePos;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if(hit.collider == vineCollider && Input.GetMouseButtonDown(0))
        {
            changeVine.CutVine();
        }
        
    }

}
