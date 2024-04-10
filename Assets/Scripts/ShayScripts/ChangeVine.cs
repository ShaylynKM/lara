using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeVine : MonoBehaviour
{
    private bool isCut;

    private Renderer render;

    public bool IsVisible = true;

    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    private void Awake()
    {
        render = GetComponent<Renderer>();

        if(IsVisible == true)
        {
            render.enabled = true;
        }
        else
        {
            render.enabled = false;
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scissors") && !isCut)
        {
            CutVine();
        }
    }

    private void CutVine()
    {

    }
}
