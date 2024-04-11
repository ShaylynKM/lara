using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVine : MonoBehaviour
{
    private Renderer render;

    [SerializeField]
    private bool isVisible = true;

    private bool hasBeenCut;

    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    public Secateurs secateurs;
  
     void Awake()
     {
        render = GetComponent<Renderer>();

        secateurs = (Secateurs)GameObject.FindObjectOfType(typeof(Secateurs));

        if(isVisible == true)
        {
            render.enabled = true;
            hasBeenCut = false;
        }
        else
        {
            render.enabled = false;
            hasBeenCut = true;
        }

     }

    private void Start()
    {
        
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

    public void ChangeNeighbours()
    {
        foreach(GameObject neighbour in neighbours)
        {
            isVisible = !isVisible;
            Debug.Log("Toggled");
        }
    }
}
