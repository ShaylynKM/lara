using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.Events; 
 
public class PathTranslate : MonoBehaviour 
{ 
    [SerializeField] 
    Transform[] pathPoints; 
    public float snapDistance = 0.5f; // Distance threshold for snapping to the target 
    [SerializeField] private float grabDistance = .5f; 
    private Transform closestPoint; 
    private bool isDragging = false; 
    public bool IsDraggable { get; set; } 
    public bool IsDragging 
    { 
        get { return isDragging;} 
        private set { } 
    } 
 
 
 
    // Update is called once per frame 
    void Update() 
    { 
        if (!IsDraggable) 
        { 
            return; 
        } 
        if (isDragging) 
        { 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
             
            mousePos.z = transform.position.z; // Ensure z-position is the same as the object 
            transform.position = mousePos; 
        } 
 
        if (Input.GetMouseButtonDown(0)) 
        { 
            // Find the closest path point to the mouse position 
            //closestPoint = GetClosestPathPoint(); 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = 0; 
            float mouseDistance = (transform.position - mousePos).magnitude; 
            Debug.LogFormat("Mouse Pos is {0}, object position is {1} and distance is {2}", mousePos, transform.position, mouseDistance); 
            isDragging =  mouseDistance < grabDistance 
                ? true 
                : false; 
 
 
        } 
        if(Input.GetMouseButton(0) && isDragging) 
        { 
            // Check if the mouse release position is close enough to the target path point 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = transform.position.z; 
            Vector3 projectedPoint = Vector3.Project((mousePos - pathPoints[0].position), (pathPoints[1].position - pathPoints[0].position)) + pathPoints[0].position; 
            float pathDistance = (pathPoints[0].position - pathPoints[1].position).magnitude; 
            float p0Distance = (pathPoints[0].position - projectedPoint).magnitude; 
            float p1Distance = (pathPoints[1].position - projectedPoint).magnitude; 
            if(p0Distance > pathDistance || p1Distance > pathDistance) 
            { 
                projectedPoint = GetClosestPathPoint().position; 
            } 
 
            projectedPoint = GetClosestProjectedPoint(mousePos); 
             
            transform.position = projectedPoint; 
        } 
 
        if (Input.GetMouseButtonUp(0) && isDragging) 
        { 
            // Check if the mouse release position is close enough to the target path point 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = transform.position.z; 
            Vector3 projectedPoint = Vector3.Project((mousePos - pathPoints[0].position), (pathPoints[1].position - pathPoints[0].position)) + pathPoints[0].position; 
            float pathDistance = (pathPoints[0].position - pathPoints[1].position).magnitude; 
            float p0Distance = (pathPoints[0].position - projectedPoint).magnitude; 
            float p1Distance = (pathPoints[1].position - projectedPoint).magnitude; 
            if (p0Distance > pathDistance || p1Distance > pathDistance) 
            { 
                projectedPoint = GetClosestPathPoint().position; 
            } 
            projectedPoint = GetClosestProjectedPoint(mousePos); 
            Vector3 closestPoint =GetClosestPathPoint().position; 
             
            // Ensure z-position is the same as the object 
            float distanceToTarget = Vector3.Distance(projectedPoint, closestPoint); 
            if (distanceToTarget < snapDistance) 
            { 
                transform.position = closestPoint; 
                
            } 
            isDragging = false; 
        } 
    } 
 
    private Vector3 GetClosestProjectedPoint(Vector3 mousePos) 
    { 
        Vector3 closestPoint = new Vector3(); 
        float closestDistance = Mathf.Infinity; 
        for (int i = 0; i < pathPoints.Length - 1; i++) 
        { 
            Vector3 projectedPoint = Vector3.Project((mousePos - pathPoints[i].position), (pathPoints[i+1].position - pathPoints[i].position)) + pathPoints[i].position; 
            float pathDistance = (pathPoints[i].position - pathPoints[i+1].position).magnitude; 
            float p0Distance = (pathPoints[i].position - projectedPoint).magnitude; 
            float p1Distance = (pathPoints[i+1].position - projectedPoint).magnitude; 
            if(p0Distance > pathDistance || p1Distance > pathDistance) 
            { 
                projectedPoint = GetClosestPathPoint().position; 
            } 
 
            if ((mousePos - projectedPoint).magnitude < closestDistance) 
            { 
                closestDistance = (mousePos - projectedPoint).magnitude; 
                closestPoint = projectedPoint; 
            } 
        } 
 
        return closestPoint; 
 
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
