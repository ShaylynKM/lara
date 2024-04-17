using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMaterialsPuzzle : MonoBehaviour
{
    private GameObject brush;
    private GameObject pencil;
    private GameObject curtain1;
    private GameObject curtain2;
    private GameObject curtainTarget1;
    private GameObject curtainTarget2;
    private GameObject objectsTarget;

    private ChangeScenes changeScenes;
    private Bobbing bobbingGroup2;
    private FadeIn fadeIn;
    private FreeTranslate brushTranslate;
    private FreeTranslate pencilTranslate;
    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();

        brush = GameObject.Find("Brush");
        pencil = GameObject.Find("Pencil");
        curtain1 = GameObject.Find("Curtain1");
        curtain2 = GameObject.Find("Curtain2");
        curtainTarget1 = GameObject.Find("CurtainTarget1");
        curtainTarget2 = GameObject.Find("CurtainTarget2");
        objectsTarget = GameObject.Find("ObjectsTarget");

        bobbingGroup2 = GameObject.Find("AudienceGroup2").GetComponent<Bobbing>();
        fadeIn = GameObject.Find("Audience").GetComponent<FadeIn>();
        brushTranslate = GameObject.Find("Brush").GetComponent<FreeTranslate>();
        pencilTranslate = GameObject.Find("Pencil").GetComponent<FreeTranslate>();

        brushTranslate.isDraggable = false;
        pencilTranslate.isDraggable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (curtain1.transform.position == curtainTarget1.transform.position && curtain2.transform.position == curtainTarget2.transform.position)
        {
            StartCoroutine(fadeIn.FadeInObjects());
            brushTranslate.isDraggable = true;
            pencilTranslate.isDraggable = true;
        }
        
        if (brush.transform.position == objectsTarget.transform.position || pencil.transform.position == objectsTarget.transform.position)
        {
            bobbingGroup2.enabled = false;
        }

        if (brush.transform.position == objectsTarget.transform.position && pencil.transform.position == objectsTarget.transform.position)
        {
            StartCoroutine(StartNewScene());
        }
            
    }

    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(2f);
        changeScenes.LoadNextScene();
    }
}
