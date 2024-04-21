using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Scene = UnityEditor.SearchService.Scene;

public class OpenEyePuzzle : MonoBehaviour
{
    [SerializeField]
    private PathTranslate eyeLid;
    [SerializeField]
    private GameObject eyeFlower;
    [SerializeField]
    private GameObject eyeTarget;
    [SerializeField]
    private GameObject wholeEye;
    
    private FreeTranslate eyeLidTranslate;
    private Scale wholeEyeScale;
    [SerializeField] private string nextLevel;
    public UnityEvent puzzleSolved;
    
    private PlayableDirector playableDirector; // Camera transition
    [SerializeField] private float startTransitionTime = 3f;
    private bool puzzleComplete = false;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        Invoke("EnablePuzzle", startTransitionTime);
    }

    void Start()
    {
       // changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();
        
       // eyeLid = GameObject.Find("eyeTrans");
        //eyeFlower = GameObject.Find("eyeFlower");
        //eyeTarget = GameObject.Find("p1");
        //flowerTarget = GameObject.Find("FlowerTarget");
        //eyeLidTranslate = eyeLid.GetComponent<FreeTranslate>();
        //eyeFlowerTranslate = eyeFlower.GetComponent<FreeTranslate>();

        //eyeFlowerTranslate.isDraggable = false;
    }

    void EnablePuzzle()
    {
        eyeLid.IsDraggable = true;
    }

    void Update()
    {
        if (eyeLid.transform.position == eyeTarget.transform.position && !eyeLid.IsDragging && !puzzleComplete)
        {
            puzzleComplete = true;
            SceneAndCam();
            //eyeLidTranslate.isDraggable = false;

        }

        //if (eyeFlower.transform.position == flowerTarget.transform.position)
        //{
        //    StartCoroutine(StartNewScene());
        //    //wholeEyeScale.isDraggable = true;
        //}
    }

    private void SceneAndCam()
    {
        eyeLid.IsDraggable = false;
        playableDirector.Play();
        Invoke("StartNewScene", (float)playableDirector.duration); // Loads the next scene after the playable director finishes playing the camera sequence
    }

    private void StartNewScene()
    {
        SceneManager.LoadScene(nextLevel); //SceneManager.GetActiveScene().buildIndex + 1);
    }

 
}
