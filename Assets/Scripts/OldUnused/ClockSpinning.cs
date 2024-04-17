using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpinning : MonoBehaviour
{
    private GameObject brush;
    private GameObject pencil;
    private GameObject brushTarget;
    private GameObject pencilTarget;
    private GameObject tools;
    private GameObject rotationPivot;

    private ChangeScenes changeScenes;
    private Rotate toolsRotate;
    private FreeTranslate brushTranslate;
    private FreeTranslate pencilTranslate;

    public float initialBrushSpeed = 360f;
    public float maxBrushSpeed = 1080f;
    public float brushAccelerationRate = 50f;

    public float initialPencilSpeed = 30f;
    public float maxPencilSpeed = 90f;
    public float pencilAccelerationRate = 20f;

    private float currentBrushSpeed;
    private float currentPencilSpeed;
    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();

        brush = GameObject.Find("Brush");
        pencil = GameObject.Find("Pencil");
        brushTarget = GameObject.Find("BrushTarget");
        pencilTarget = GameObject.Find("PencilTarget");
        tools = GameObject.Find("Tools");
        rotationPivot = GameObject.Find("RotationPivot");

        toolsRotate = GameObject.Find("Tools").GetComponent<Rotate>();
        brushTranslate = GameObject.Find("Brush").GetComponent<FreeTranslate>();
        pencilTranslate = GameObject.Find("Pencil").GetComponent<FreeTranslate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brush.transform.position == brushTarget.transform.position)
        {
            brushTranslate.isDraggable = false;
            brushTranslate.enabled = false;
        }
        if (pencil.transform.position == pencilTarget.transform.position)
        {
            pencilTranslate.isDraggable = false;
            pencilTranslate.enabled = false;
        }

        if (brush.transform.position == brushTarget.transform.position && pencil.transform.position == pencilTarget.transform.position)
        {
            toolsRotate.enabled = true;
        }

        if (toolsRotate.GetRotation() == 135)
        {
            if (currentBrushSpeed < maxBrushSpeed)
            {
                currentBrushSpeed += brushAccelerationRate * Time.deltaTime;
            }
            if (currentPencilSpeed < maxPencilSpeed)
            {
                currentPencilSpeed += pencilAccelerationRate * Time.deltaTime;
            }
            toolsRotate.enabled = false;
            RotateAroundPivot(pencil.transform, rotationPivot.transform, currentPencilSpeed * Time.deltaTime);
            RotateAroundPivot(brush.transform, rotationPivot.transform, currentBrushSpeed * Time.deltaTime);
        }
    }

    void RotateAroundPivot(Transform pointer, Transform pivot, float rotationAmount)
    {
        pointer.RotateAround(pivot.position, Vector3.forward, rotationAmount);
        StartCoroutine(StartNewScene());
    }

    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(5f);
        changeScenes.LoadNextScene();
    }
}
