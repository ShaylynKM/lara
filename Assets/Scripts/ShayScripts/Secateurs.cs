using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;

public class Secateurs : MonoBehaviour
{
    public ChangeVine changeVine { get; private set; }

    private void Awake()
    {
        changeVine = (ChangeVine)GameObject.FindObjectOfType(typeof(ChangeVine));
    }

    private void OnMouseDrag()
    {
        Snip();
    }

    public void Snip()
    {
        if (Input.GetMouseButtonDown(1)) // Click RMB
        {
            changeVine?.CutVine();
        }
    }
}
