using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSway : MonoBehaviour
{
    public float swaySpeed = 1f;
    public float swayAmount = 10f;
    public float swayOffset = 0f;

    private Quaternion initialRotation;
    private Vector3 initialLocalPosition;

    void Start()
    {
        initialRotation = transform.localRotation;
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        float sway = Mathf.Sin((Time.time + swayOffset) * swaySpeed) * swayAmount;
        Quaternion swayRotation = Quaternion.AngleAxis(sway, Vector3.forward);
        transform.localRotation = initialRotation * swayRotation;
    }
}


