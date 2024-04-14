using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVine : MonoBehaviour
{
    private SpriteRenderer render;

    [SerializeField]
    private bool isVisible = true;

    private bool changedByNeighbour;

    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    public Secateurs secateurs;
  
     void Awake()
     {
        render = GetComponent<SpriteRenderer>();

        secateurs = (Secateurs)GameObject.FindObjectOfType(typeof(Secateurs));

        if (render.enabled == true)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }

    }

    public void ChangeNeighbours()
    {
        foreach (GameObject neighbour in neighbours)
        {            
            SpriteRenderer neighbourRenderer;
            neighbourRenderer = neighbour.GetComponent<SpriteRenderer>();

            // If the parallel vines are cut, reverse the cut. If they're uncut, cut them.

            if (neighbourRenderer.enabled == true)
            {               
                neighbourRenderer.enabled = false;                
                changedByNeighbour = true;
                IsChangedByNeighbour();
            }
            else if (neighbourRenderer.enabled == false)
            {                
                neighbourRenderer.enabled = true;                
                changedByNeighbour = true;  /// check this variable; seems odd
                IsChangedByNeighbour();
            }
        }
    }


    // For cutting vines, then calling the function that changes the neighbour vines
    public void CutVine()
    {
        if (render.enabled == true)
        {
            if (isVisible == true) // && changedByNeighbour == false)               
            {
                render.enabled = false; // Hide the vine when it is cut
                ChangeNeighbours();
                isVisible = false;
            }
            else if (isVisible == false) // && changedByNeighbour == true)
            {
                render.enabled = true;
                ChangeNeighbours();
                isVisible = true;
            }
        }

    }

    // Trying to flag when a vine is changed by a neighbour vine vs cut by the players

    public void IsChangedByNeighbour()
    {
        if (changedByNeighbour == true && isVisible == false)       
        {
            render.enabled = true;            
            Debug.Log("Changed by neighbour: visible");
        }
        else if (changedByNeighbour == true && isVisible == true)        
        {
            render.enabled = false;            
            Debug.Log("Changed by neighbour: visible");

        }
    }

}
