using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    // NOTE: This script requires the object to have a RigidBody2D, set to dynamic (with constraints so they don't fall down) and a BoxCollider2D
    // Object must be set to "Puzzle" layer

    private bool isDragging = false;

    private Vector3 offset; // Used to allow us to click anywhere on the object, rather than dead in the center.

    [SerializeField] private LayerMask puzzleLayer; // The layer mask used to detect if an object is part of the puzzle/should be interactable. Set this in the inspector.


    void Update()
    {
        DragObject();
    }

    void DragObject()
    {
        if(Input.GetMouseButtonDown(0)) // If currently clicking the left mouse button down
        {
            // Casting a ray from the mouse. Ray is sent from mouse position, straight into the screen (using Vector2.zero.)
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, puzzleLayer); // Ray should only hit the puzzle layer

            if(hit)
            {
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Records the difference between the clicked object's center and the clicked point on the camera plane

                isDragging = true; // Now we're dragging, bay bee
            }
        }
        else if(Input.GetMouseButtonUp(0)) // Releasing left mouse button
        {
            isDragging = false; // Now we're not dragging anymore, bay bee
        }

        if(isDragging == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset; // Move the object, taking into account the original offset
        }
    }
}
