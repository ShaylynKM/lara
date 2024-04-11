using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecateursCollider : MonoBehaviour
{
    public ChangeVine changeVine;

    private Collider2D vineCollider;

    void Awake()
    {
        changeVine = (ChangeVine)GameObject.FindObjectOfType(typeof(ChangeVine));

        vineCollider = changeVine.GetComponent<Collider2D>();
    }
    
    void Update()
    {
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
