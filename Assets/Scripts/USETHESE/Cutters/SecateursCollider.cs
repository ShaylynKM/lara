using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecateursCollider : MonoBehaviour
{
    public ChangeVine changeVine;

    private AudioSource snip;

    void Awake()
    {
        changeVine = (ChangeVine)GameObject.FindObjectOfType(typeof(ChangeVine));
        snip = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // If the raycast hits the collider for a vine you can cut, cut the vine.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {            
            if (hit.collider.GetComponent<ChangeVine>())
            {
                snip.Play(); // Plays the snipping sound effect
                Debug.Log("played sound");

                var changeVine = hit.collider.GetComponent<ChangeVine>();

                changeVine?.CutVine();
            }

        }
    }

}
