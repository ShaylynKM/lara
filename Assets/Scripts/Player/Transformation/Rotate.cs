using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float[] presetRotations;
    public float rotationSensitivity = 15f;
    public GameObject rotationPivot;
    [SerializeField] private float minRotation = -180f;
    [SerializeField] private float maxRotation = 180f;

    private Quaternion initialRotation;
    private Vector3 initialMousePosition;
    private bool isDragging = false;
    private float closestRotation = 0f;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                initialMousePosition = Input.mousePosition;
            }
        }

        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - initialMousePosition;
            float rotationFactor = mouseDelta.x * rotationSensitivity * Time.deltaTime;
            float clampedRotation = Mathf.Clamp(transform.localRotation.eulerAngles.z + rotationFactor, minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler(0f, 0f, clampedRotation);

            initialMousePosition = Input.mousePosition; // Update initial mouse position
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            SnapToClosestRotation();
        }
    }

    private void SnapToClosestRotation()
    {
        float minDifference = Mathf.Infinity;
        
        foreach (float rotation in presetRotations)
        {
            float difference = Mathf.Abs(transform.localRotation.eulerAngles.z - rotation);
            if (difference < minDifference)
            {
                minDifference = difference;
                closestRotation = rotation;
            }
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, closestRotation);
    }

    public float GetRotation()
    {
        return closestRotation;
    }
}
