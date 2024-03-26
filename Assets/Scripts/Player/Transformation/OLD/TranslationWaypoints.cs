using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationWaypoints : MonoBehaviour
{
    private int loopCount = 1;

    private int subtractChild = 1;

    [Range(0f, 2f)] // Creates a slider for the size of the waypoints
    [SerializeField] private float waypointSize = 1f;

    private void OnDrawGizmos() // Called in the editor to draw something in the scene
    {
        foreach(Transform t in transform) // Takes every transform that is a child of our waypoint system
        {
            Gizmos.color = Color.cyan; // Picks a colour for the gizmos

            Gizmos.DrawWireSphere(t.position, waypointSize); // Draws a wire sphere
        }

        Gizmos.color = Color.red; // Picks the colour for the next gizmo

        for(int i = 0; i < transform.childCount - loopCount; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position); // Gets each child waypoint sequentially from the hierarchy
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - subtractChild).position, transform.GetChild(0).position); // Closes the line between the first and last sphere gizmo
    }
}
