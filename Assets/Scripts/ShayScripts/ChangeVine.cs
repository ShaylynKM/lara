using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVine : MonoBehaviour
{
<<<<<<< Updated upstream
    private SpriteRenderer render;
=======
    private SpriteRenderer render; 

    [SerializeField]
    int id;
>>>>>>> Stashed changes

    public bool isVisible { get; private set; }

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


    /// <summary>
    /// A function called when a vine needs to be changed. Either the vine is cut by its neighbour, or the player themselves, taking a bool param that specifies which case it is.  
    /// </summary>
    /// <param name="isCutByNeighbour"> False if the player directly cuts the vine, true if not. </param>
    public void CutVine(bool isCutByNeighbour)
    {
        foreach (GameObject neighbour in neighbours)
        {
            SpriteRenderer neighbourRenderer;
            neighbourRenderer = neighbour.GetComponent<SpriteRenderer>();


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

        //Case 2
        else if ((isVisible == true) && (render.enabled == true) && (isCutByNeighbour == false)) 
        {
            this.ReverseVine(); 
            foreach (GameObject vine in neighbours)
            {
                //Get the neighbouring vine instance and cut it, specifying that it needs to cut no other vines nearby 
                (vine.GetComponent<ChangeVine>()).CutVine(true);
            }

        }

        //Case 3
        else if (isCutByNeighbour == true)
        {
            this.ReverseVine();
        }

        else
        { //player attempts to cut vine, need to cut if possible, and if so, also cut neighbours 
            Debug.Log("Error! render.enabled != isVisible, or CutVines is being called in an unexpected way");
        }

    }

/// <summary>
/// Takes whatever the current state of the calling vine instance is and reverses it. 
/// </summary>
    private void ReverseVine()
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

        else
        {
            Debug.Log("Error! Render status and isVisible do not match");
        }
    }


    public void SetID(int id)
    {
        this.id = id; 
    }
    
    public int GetID()
    {
        return id;
    }

}