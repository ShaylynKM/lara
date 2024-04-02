using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTranslate : MonoBehaviour
{
    public Transform[] pathPoints;
    public float snapDistance = 0.5f; // Distance threshold for snapping to the target

    private Transform closestPoint;
    private bool isDragging = false;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z; // Ensure z-position is the same as the object
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Find the closest path point to the mouse position
            closestPoint = GetClosestPathPoint();
            if (closestPoint != null)
            {
                isDragging = true;
            }
        }
        if(Input.GetMouseButton(0) && isDragging)
        {
            // Check if the mouse release position is close enough to the target path point
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 projectedPoint = Vector3.Project((mousePos - pathPoints[0].position), (pathPoints[1].position - pathPoints[0].position)) + pathPoints[0].position;
            float pathDistance = (pathPoints[0].position - pathPoints[1].position).magnitude;
            float p0Distance = (pathPoints[0].position - projectedPoint).magnitude;
            float p1Distance = (pathPoints[1].position - projectedPoint).magnitude;
            if(p0Distance > pathDistance || p1Distance > pathDistance)
            {
                projectedPoint = GetClosestPathPoint().position;
            }

            mousePos.z = transform.position.z;
            transform.position = projectedPoint;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            // Check if the mouse release position is close enough to the target path point
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 projectedPoint = Vector3.Project((mousePos - pathPoints[0].position), (pathPoints[1].position - pathPoints[0].position)) + pathPoints[0].position;
            float pathDistance = (pathPoints[0].position - pathPoints[1].position).magnitude;
            float p0Distance = (pathPoints[0].position - projectedPoint).magnitude;
            float p1Distance = (pathPoints[1].position - projectedPoint).magnitude;
            if (p0Distance > pathDistance || p1Distance > pathDistance)
            {
                projectedPoint = GetClosestPathPoint().position;
            }
            Vector3 closestPoint =GetClosestPathPoint().position;
            // Ensure z-position is the same as the object
            float distanceToTarget = Vector3.Distance(projectedPoint, closestPoint);
            if (distanceToTarget < snapDistance)
            {
                transform.position = closestPoint;
                Debug.Log("Puzzle Solved!");
            }
            isDragging = false;
        }
    }

    // Function to find the closest path point to the mouse position
    private Transform GetClosestPathPoint()
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        foreach (Transform point in pathPoints)
        {
            float distance = Vector3.Distance(point.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = point;
            }
        }
        return closest;
    }
}
