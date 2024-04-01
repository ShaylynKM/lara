using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallsPuzzle : MonoBehaviour
{
    private GameObject laruClosed;
    private GameObject laruOpen;
    private GameObject laruClock;

    [SerializeField]
    private GameObject[] balls;

    private void Awake()
    {
        laruClosed = GameObject.Find("LaruEyesClosed");
        laruOpen = GameObject.Find("LaruEyesOpen");
        laruClock = GameObject.Find("LaruEyeClock");
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
        
    }
}
