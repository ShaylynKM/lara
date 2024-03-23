using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTranslate : MonoBehaviour
{
    public Transform target;
    public float snapDistance = 1f; // Distance threshold for snapping to the target

    private bool isDragging = false;
    private Vector3 mouseOffset;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x - mouseOffset.x, mousePos.y - mouseOffset.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, transform.position) < snapDistance)
            {
                isDragging = true;
                mouseOffset = mousePos - transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, target.position) < snapDistance)
            {
                transform.position = target.position;
            }
            isDragging = false;
        }
    }
}
