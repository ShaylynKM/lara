using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    private VineCutting vine4Cutting;
    private GameObject redLadybug;
    private GameObject orangeLadybug;

    void Start()
    {
        vine4Cutting = GameObject.Find("Vine4").GetComponent<VineCutting>();
        redLadybug = GameObject.Find("Ladybug1");
        orangeLadybug = GameObject.Find("Ladybug2");
    }

    void Update()
    {
        if (vine4Cutting.isCut)
        {
            float speed = 5f; 
            float moveAmount = speed * Time.deltaTime;

            orangeLadybug.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            orangeLadybug.transform.Translate(Vector3.up * moveAmount);
            
            redLadybug.transform.Translate(Vector3.up * moveAmount);
        }
    }
}
