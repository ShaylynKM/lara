using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeVine : MonoBehaviour
{
    private Renderer render;

    [SerializeField]
    private bool isVisible = true;

    [SerializeField]
    private GameObject[] neighbours = new GameObject[2]; // The vines parallel to this vine

    public Secateurs secateurs;
  
    private void Awake()
    {
        render = GetComponent<Renderer>();

        secateurs = (Secateurs)GameObject.FindObjectOfType(typeof(Secateurs));
        Debug.Log("foiund");

        if(isVisible == true)
        {
            render.enabled = true;
        }
        else
        {
            render.enabled = false;
        }

    }

    public void CutVine()
    {
        if(isVisible == true)
        {
            Debug.Log("cutwooooo");
        }
    }
}
