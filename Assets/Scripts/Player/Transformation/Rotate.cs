using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    public float[] presetRotations;

    private float rotationSensitivity = 10f;

    private Quaternion initialRotation;
    private Quaternion currentRotation; // Store the current rotation when dragging
    private Vector3 mouseStartingPosition;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.localRotation;
        currentRotation = initialRotation; // Set currentRotation to initialRotation initially
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
                mouseStartingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentRotation = transform.localRotation; // Update currentRotation at the beginning of dragging
            }
        }

        if (isDragging)
        {
            // Calculate the change in the mouse position
            Vector3 mouseDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStartingPosition);
            // Calculate the rotation factor based on mouse movement 
            float rotationFactor = mouseDelta.x * rotationSensitivity;

            // Apply the rotation
            transform.localRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationFactor);
        }

        // Check if the button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            SnapToClosestRotation();
            currentRotation = transform.localRotation; // Update currentRotation after rotation
        }
    }

    private void SnapToClosestRotation()
    {
        float minDifference = Mathf.Infinity;
        float closestRotation = 0f;

        // Loop through the preset rotations
        foreach (float rotation in presetRotations)
        {
            // Calculate the difference between the current and the preset rotation
            float difference = Mathf.Abs(transform.localRotation.eulerAngles.z - rotation);
            // Check if the difference is smaller than the minimum difference
            if (difference < minDifference)
            {
                minDifference = difference;
                closestRotation = rotation;
            }
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, closestRotation);
    }
}
