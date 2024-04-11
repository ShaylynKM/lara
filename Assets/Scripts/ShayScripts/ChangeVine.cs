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

    private bool hasBeenCut;

    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    public Secateurs secateurs;
  
     void Awake()
     {
        render = GetComponent<SpriteRenderer>();

        secateurs = (Secateurs)GameObject.FindObjectOfType(typeof(Secateurs));

        if(isVisible == true)
        {
            render.enabled = true;
            isVisible = false;
            hasBeenCut = false;
        }
        else
        {
            render.enabled = false;
            hasBeenCut = true;
        }

     }

    public void CutVine()
    {
        if(hasBeenCut == false)
        {
            render.enabled = false; // Hide the vine when it is cut
            hasBeenCut = true;
            ChangeNeighbours();
        }
        else
        {
            return;
        }

    }

    public void ReverseCut()
    {

    }

    public void ChangeNeighbours()
    {
        foreach(GameObject neighbour in neighbours)
        {
            SpriteRenderer neighbourRenderer;
            neighbourRenderer = neighbour.GetComponent<SpriteRenderer>();

            // If the parallel vines are cut, reverse the cut. If they're uncut, cut them.

            if(neighbourRenderer.enabled == true)
            {
                neighbourRenderer.enabled = false;
            }
            else if(neighbourRenderer.enabled == false)
            {
                neighbourRenderer.enabled = true;
            }
        }
    }
}
