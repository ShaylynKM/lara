using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzle : MonoBehaviour
{
    private GameObject redLadybug;
    private GameObject yellowLadybug;
    private GameObject vine4Cutting;
    private GameObject cutVine;
    private GameObject secateurs;

    [SerializeField]
    private GameObject[] bigFlowers;

    private void Awake()
    {
        redLadybug = GameObject.Find("RedLadybug");
        yellowLadybug = GameObject.Find("YellowLadybug");
        vine4Cutting = GameObject.Find("Vine4Cutting");
        cutVine = GameObject.Find("CutVine");
        secateurs = GameObject.Find("Secateurs");
    }

    void Start()
    {
        // Hide the cut vine and show the uncut vine
        cutVine.SetActive(false);
        vine4Cutting.SetActive(true);
    }

    void Update()
    {
        
    }
}
