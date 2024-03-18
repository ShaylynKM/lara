using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    // 3 different sizes the object can be
    [SerializeField] private float smallValue;
    [SerializeField] private float mediumValue;
    [SerializeField] private float largeValue;

    private Vector3 smallScale;
    private Vector3 mediumScale;
    private Vector3 largeScale;

    private int frameCount = 60; // The amount of frames to interpolate between the different sizes
    private int framesElapsed = 0;

    private void Awake()
    {
        smallValue = .5f;
        mediumValue = 1.5f;
        largeValue = 3f;

        // Initializing the sizes for the object
        smallScale = new Vector3(smallValue, smallValue, smallValue);
        mediumScale = new Vector3(mediumValue, mediumValue, mediumValue);
        largeScale = new Vector3(largeValue, largeValue, largeValue);

        transform.localScale = mediumScale; // Sets the object to its medium size before the game starts
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseDrag()
    {
        int addFrame = 1;

        framesElapsed = (framesElapsed + addFrame) % (frameCount + addFrame); // Resets framesElapsed to 0 after reaching the desired value

        float interpolationRatio = (float)framesElapsed / frameCount; // Casts these variables as floats before dividing to get our ratio

        // Mouse dragging up
        if(Input.GetAxis("Mouse Y") < 0)
        {
            Debug.Log("Smaller???");
            transform.localScale = Vector3.Lerp(largeScale, smallScale, interpolationRatio);
        }

        // Mouse dragging down
        if (Input.GetAxis("Mouse Y") > 0)
        {
            Debug.Log("Bigger?!?!??!");
            transform.localScale = Vector3.Lerp(smallScale, largeScale, interpolationRatio);
        }
    }

    private void OnMouseUp()
    {
        
    }

}
