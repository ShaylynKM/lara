using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_3 : MonoBehaviour
{
    private VineCutting vine4Cutting;
    private FreeTranslate ladybugTranslate;
    private GameObject orangeLadybug;

    void Start()
    {
        vine4Cutting = GameObject.Find("Vine4").GetComponent<VineCutting>();
        ladybugTranslate = GameObject.Find("Ladybug1").GetComponent<FreeTranslate>();
        orangeLadybug = GameObject.Find("Ladybug2");

        ladybugTranslate.isDraggable = false;
    }

    void Update()
    {
        if (vine4Cutting.isCut)
        {
            float speed = 5f; 
            float moveAmount = speed * Time.deltaTime;

            orangeLadybug.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            orangeLadybug.transform.Translate(Vector3.up * moveAmount);
            ladybugTranslate.isDraggable = true;
        }
    }
}
