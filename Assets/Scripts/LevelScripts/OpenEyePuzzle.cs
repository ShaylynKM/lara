using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyePuzzle : MonoBehaviour
{
    private GameObject eyeLid;
    private GameObject eyeFlower;
    private GameObject eyeTarget;
    private GameObject flowerTarget;
    private GameObject wholeEye;

    private ChangeScenes changeScenes;
    private FreeTranslate eyeLidTranslate;
    private FreeTranslate eyeFlowerTranslate;
    private Scale wholeEyeScale;

    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();
        
        eyeLid = GameObject.Find("eyeTrans");
        eyeFlower = GameObject.Find("eyeFlower");
        eyeTarget = GameObject.Find("EyeTarget");
        flowerTarget = GameObject.Find("FlowerTarget");
        //wholeEye = GameObject.Find("Eye");
        eyeLidTranslate = GameObject.Find("eyeTrans").GetComponent<FreeTranslate>();
        eyeFlowerTranslate = GameObject.Find("eyeFlower").GetComponent<FreeTranslate>();
        //wholeEyeScale = GameObject.Find("Eye").GetComponent<Scale>();

        eyeFlowerTranslate.isDraggable = false;
        //wholeEyeScale.isDraggable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeLid.transform.position == eyeTarget.transform.position)
        {
            eyeFlowerTranslate.isDraggable = true;
        }

        if (eyeFlower.transform.position == flowerTarget.transform.position)
        {
            StartCoroutine(StartNewScene());
            //wholeEyeScale.isDraggable = true;
        }
    }

    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(2f);
        changeScenes.LoadNextScene();
    }
}
