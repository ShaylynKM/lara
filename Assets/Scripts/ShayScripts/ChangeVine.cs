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
    int id; 

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


    /// <summary>
    /// A function called when a vine needs to be changed. Either the vine is cut by its neighbour, or the player themselves, taking a bool param that specifies which case it is.  
    /// </summary>
    /// <param name="isCutByNeighbour"> False if the player directly cuts the vine, true if not. </param>
    public void CutVine(bool isCutByNeighbour)
    {
        /* We split into 3 possible cases where this is called: 
            Case 1: Player attempts to cut vine and it fails, because the vine is already cut. 
            Case 2: Player attempts to cut vine and it hasn't already been cut, therefore succeeds. That vine must also cut its neighbours. 
            Case 3: Player does not directly cut this instance of vine, and it is instead called by the original, directly cut vine, making it a neighbour vine. 
        
        */


        //Case 1 
        if ((isVisible == false) && (render.enabled == false) && (isCutByNeighbour == false))
        {
            Debug.Log("You can't cut this! It has already been cut"); 
            //and maybe play a sound? 
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
        if ((render.enabled == true) && (isVisible == true))
        {
            this.render.enabled = false; 
            this.isVisible = false; 
        }
        
        else if ((render.enabled == false) && (isVisible == false))
        {
                this.render.enabled = true; 
                this.isVisible = true; 
        }

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
