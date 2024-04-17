using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecateursCollider : MonoBehaviour
{
    public ChangeVine changeVine;

    void Awake()
    {
        changeVine = (ChangeVine)GameObject.FindObjectOfType(typeof(ChangeVine));

    }
    
    void Update()
    {
        // If the raycast hits the collider for a vine you can cut, cut the vine.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {            
            if (hit.collider.GetComponent<ChangeVine>())
            {
                var changeVine = hit.collider.GetComponent<ChangeVine>();

                changeVine?.CutVine();
            }

        }
    }
}