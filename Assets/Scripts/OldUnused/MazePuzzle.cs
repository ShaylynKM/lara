using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzle : MonoBehaviour
{
    private GameObject redLadybug;
    private GameObject yellowLadybug;
    private VineCutting vineCutting;
    private GameObject secateurs;

    [SerializeField]
    private GameObject[] bigFlowers;

    private void Awake()
    {
        redLadybug = GameObject.Find("RedLadybug");
        yellowLadybug = GameObject.Find("YellowLadybug");
        secateurs = GameObject.Find("Secateurs");

        vineCutting = GameObject.Find("Vine").GetComponent<VineCutting>();
        Debug.Log("found the vine");

    }

    void Update()
    {
      if(vineCutting.isCut)
        {
            Debug.Log("snippy snippy uwu");
            Destroy(secateurs); // Destroy the secateurs when the vine is cut
        }
    }
}
