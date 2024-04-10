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

    private int pointIndex;

    public UnityEvent BugMeeting;

    private void Awake()
    {
        transform.position = wayPoints[pointIndex].transform.position; // Sets the position to the first point
    }

    private void Update()
    {

    }

    public void MoveBug()
    {
        // Moves the ladybug to the next point on the path
        if (pointIndex <= wayPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[pointIndex].transform.position, bugSpeed * Time.deltaTime);

            // If we are at the last point, invoke the event
            if(transform.position == wayPoints[pointIndex].transform.position)
            {
                StartCoroutine(WaitToChangeScene()); // Wait 4 seconds before changing scenes
                BugMeeting.Invoke(); // Meant to call the scene changer script
            }
        }
    }

    IEnumerator WaitToChangeScene()
    {
        yield return new WaitForSeconds(4f);
    }

}
