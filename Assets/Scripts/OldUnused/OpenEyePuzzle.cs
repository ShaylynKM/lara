using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OpenEyePuzzle : MonoBehaviour
{
    private GameObject eyeLid;
    private GameObject eyeFlower;
    private GameObject eyeTarget;
    private GameObject wholeEye;

    private ChangeScenes changeScenes;
    private FreeTranslate eyeLidTranslate;
    private FreeTranslate eyeFlowerTranslate;
    private Scale wholeEyeScale;

    private PlayableDirector playableDirector; // Camera transition

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    void Start()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();
        
        eyeLid = GameObject.Find("eyeTrans");
        //eyeFlower = GameObject.Find("eyeFlower");
        eyeTarget = GameObject.Find("p1");
        //flowerTarget = GameObject.Find("FlowerTarget");
        eyeLidTranslate = GameObject.Find("eyeTrans").GetComponent<FreeTranslate>();
        //eyeFlowerTranslate = GameObject.Find("eyeFlower").GetComponent<FreeTranslate>();

        eyeFlowerTranslate.isDraggable = false;
    }

    void Update()
    {
        if (eyeLid.transform.position == eyeTarget.transform.position)
        {
            eyeLidTranslate.isDraggable = false;

        }

        //if (eyeFlower.transform.position == flowerTarget.transform.position)
        //{
        //    StartCoroutine(StartNewScene());
        //    //wholeEyeScale.isDraggable = true;
        //}
    }

    public void SceneAndCam()
    {
        playableDirector.Play();
        Invoke("StartNewScene", (float)playableDirector.duration); // Loads the next scene after the playable director finishes playing the camera sequence
    }

    private void StartNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 
}
