using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LadybugVinePuzzle : MonoBehaviour
{
    [SerializeField]
    private UnityEvent pathClear;

    [SerializeField]
    private SpriteRenderer[] vinesToCut;
    [SerializeField]
    private ChangeVine[] vinesCut;

    private SecateursCollider secateursCollider;

    private void Awake()
    {
        secateursCollider = (SecateursCollider)GameObject.FindObjectOfType(typeof(SecateursCollider));
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
            pathClear.Invoke();
            Destroy(secateursCollider); // Destroy the secateurs collider when the puzzle is complete so the player can't keep cutting vines.
        }
    }

    void Update()
    {
        CheckIfVinesAreCut();
    }

}
