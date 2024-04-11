using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;

public class Secateurs : MonoBehaviour
{
    private float zValue = 0f;

    private void Update()
    {
        // Makes the secateurs follow the mouse. Cannot put it down like in the freetranslate script.

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = zValue;
        transform.position = mousePos;
    }

}
