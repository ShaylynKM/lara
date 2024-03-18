using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaScale : MonoBehaviour
{
    [SerializeField]
    public Vector3[] presetSizes;

    private Vector3 initialSize;
    private Vector3 mouseStartingPosition;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the mouse click hits the object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                mouseStartingPosition = Input.mousePosition;
            }
        }

        if (isDragging)
        {
            // Calculate the change in the mouse position
            Vector3 mouseDelta = (Input.mousePosition - mouseStartingPosition);
            // Calculate the scale factor based on mouse movement
            float scaleFactor = 1f + (mouseDelta.magnitude * 0.01f);
            //Apply the new scale
            transform.localScale = initialSize * scaleFactor;
        }

        // Check if the button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            SnapToClosestSize();
        }
    }

    private void SnapToClosestSize()
    {
        float minDistance = Mathf.Infinity;
        Vector3 closestSize = Vector3.zero;

        // Loop through the preset sizes
        foreach (Vector3 size in presetSizes)
        {
            // Calculate the distance between the current and the preset sizes
            float distance = Vector3.Distance(transform.localScale, size);
            // Check if the distance is smaller than the minimum distance
            if (distance < minDistance)
            {
                minDistance = distance;
                closestSize = size;
            }
        }

        transform.localScale = closestSize;
    }
}
