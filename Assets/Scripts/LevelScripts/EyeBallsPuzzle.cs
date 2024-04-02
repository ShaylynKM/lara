using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallsPuzzle : MonoBehaviour
{
    private GameObject laruClosed;
    private GameObject laruOpen;
    private GameObject laruClock;

    private GameObject eyeRed1;
    private GameObject eyeRed2;
    private GameObject eyeRed3;
    private GameObject eyeRed4;
    private GameObject eyeTarget1;
    private GameObject eyeTarget2;
    private GameObject eyeTarget3;
    private GameObject eyeTarget4;

    private ChangeScenes changeScenes;

    [SerializeField]
    private GameObject[] balls;

    private void Awake()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();

        laruClosed = GameObject.Find("LaruEyesClosed");
        laruOpen = GameObject.Find("LaruEyesOpen");
        laruClock = GameObject.Find("LaruEyeClock");

        eyeRed1 = GameObject.Find("EyeRed1");
        eyeRed2 = GameObject.Find("EyeRed2");
        eyeRed3 = GameObject.Find("EyeRed3");
        eyeRed4 = GameObject.Find("EyeRed4");
        eyeTarget1 = GameObject.Find("EyeTarget1");
        eyeTarget2 = GameObject.Find("EyeTarget2");
        eyeTarget3 = GameObject.Find("EyeTarget3");
        eyeTarget4 = GameObject.Find("EyeTarget4");
    }

    private void Start()
    {
        // Hides the first 2 sprites
        laruClock.SetActive(false);
        laruOpen.SetActive(false);

        // Makes sure the closed eye sprite is showing
        laruClosed.SetActive(true);
    }

    void Update()
    {
        if (eyeRed1.transform.position == eyeTarget1.transform.position || eyeRed2.transform.position == eyeTarget2.transform.position || eyeRed3.transform.position == eyeTarget3.transform.position || eyeRed4.transform.position == eyeTarget4.transform.position)
        {
            laruClock.SetActive(false);
            laruClosed.SetActive(false);
            laruOpen.SetActive(true);
        }

        if (eyeRed1.transform.position == eyeTarget1.transform.position && eyeRed2.transform.position == eyeTarget2.transform.position && eyeRed3.transform.position == eyeTarget3.transform.position && eyeRed4.transform.position == eyeTarget4.transform.position)
        {
            laruClock.SetActive(true);
            laruClosed.SetActive(false);
            laruOpen.SetActive(false);
            StartCoroutine(StartNewScene());
        }
    }

    IEnumerator StartNewScene()
    {
        yield return new WaitForSeconds(2f);
        changeScenes.LoadNextScene();
    }
}
