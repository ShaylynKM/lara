using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVine : MonoBehaviour
{    
    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    public void ChangeNeighbours()
    {
        foreach (GameObject neighbourGameObject in neighbours)
        {
            var neighbour = neighbourGameObject.GetComponent<ChangeVine>();

            // If the parallel vines are cut, reverse the cut. If they're uncut, cut them.

            if (neighbour.gameObject.activeSelf)
            {
                neighbour.gameObject.SetActive(false);
            }
            else
            {
                neighbour.gameObject.SetActive(true);
            }
        }
    }

    // For cutting vines, then calling the function that changes the neighbour vines
    public void CutVine()
    {
        ChangeNeighbours();

        if (this.gameObject.activeSelf)              
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }


    }

}