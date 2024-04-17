using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePuzzle : MonoBehaviour
{
    // ORDER OF OPERATIONS: Rotate, Translate, Scale 

    private GameObject yourPlate;

    [SerializeField]
    private GameObject[] plates;

    private void Awake()
    {
        yourPlate = GameObject.Find("YourPlate");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
