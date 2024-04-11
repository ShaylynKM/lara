using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class LadybugPath : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;

    private float bugSpeed = 5f;

    private int pointIndex = 0;

    public UnityEvent BugMeeting;

    [SerializeField]
    private Transform lastWaypoint;


    private void Awake()
    {
        transform.position = wayPoints[pointIndex].transform.position; // Sets the position to the first point
    }

    private void Update()
    {
        //MoveBug();

        if (transform.position == lastWaypoint.transform.position)
        {
            StartCoroutine(WaitToChangeScene());
        }
    }

    public void MoveBug()
    {

        // Moves the ladybug to the next point on the path
        if (pointIndex < wayPoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[pointIndex].transform.position, bugSpeed * Time.deltaTime);

            // Point index is increased when the ladybug reaches a point
            if(transform.position == wayPoints[pointIndex].transform.position)
            {
                pointIndex ++;
            }
        }

    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(2);

        BugMeeting.Invoke(); // Meant to call the scene changer script
    }

}
