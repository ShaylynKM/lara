using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaScale : MonoBehaviour
{
    [SerializeField]
    public Vector3[] presetSizes;

    private float mouseSensitivity = 0.5f;
    private float minimumScaleClamp = 0.1f;
    private float maximumScaleClamp = 10f;

    private Vector3 initialSize;
    private Vector3 currentSize; 
    private Vector3 mouseStartingPosition;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
        currentSize = initialSize; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the mouse click hits the object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                mouseStartingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (isDragging)
        {
            // Calculate the change in the mouse position
            Vector3 mouseDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStartingPosition);

            float scaleFactor = 1f;

            // Check the direction of mouse movement to determine scaling behavior
            if (mouseDelta.x > 0) // Dragging towards the right
            {
                scaleFactor += mouseDelta.magnitude * mouseSensitivity;
            }                
            else // Dragging towards the left
            {
                scaleFactor -= mouseDelta.magnitude * mouseSensitivity;
            }
               
            // Apply the scale
            transform.localScale = currentSize * Mathf.Clamp(scaleFactor, minimumScaleClamp, maximumScaleClamp);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            SnapToClosestSize();
            currentSize = transform.localScale; 
        }
    }


    private void SnapToClosestSize()
    {
        float minDistance = Mathf.Infinity;
        Vector3 closestSize = Vector3.zero;

        // Loop through the preset sizes
        foreach (Vector3 size in presetSizes)
        {
            // Calculate the distance between the current size and the preset sizes
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
