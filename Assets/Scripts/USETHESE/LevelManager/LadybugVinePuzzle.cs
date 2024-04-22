using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class LadybugVinePuzzle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent pathClear;

    [SerializeField]
    private SpriteRenderer[] vinesToCut;
    [SerializeField]
    private ChangeVine[] vinesCut;

    private SecateursCollider secateursCollider;

    private PlayableDirector playableDirector;

    private void Awake()
    {
        secateursCollider = (SecateursCollider)GameObject.FindObjectOfType(typeof(SecateursCollider));

        playableDirector = GetComponent<PlayableDirector>();
    }

    private void CheckIfVinesAreCut()
    {
        bool areVinesCut = true;
        foreach (ChangeVine vineCut in vinesCut)
        {
            areVinesCut &= !vineCut.gameObject.activeSelf;
        }
        if (areVinesCut)
        {
            playableDirector.Play();
            pathClear.Invoke();
            Destroy(secateursCollider); // Destroy the secateurs collider when the puzzle is complete so the player can't keep cutting vines.
            Invoke("StartNewScene", (float)playableDirector.duration); // Loads the next scene after the playable director finishes playing the camera sequence
        }
    }

    void Update()
    {
        CheckIfVinesAreCut();
    }

}
