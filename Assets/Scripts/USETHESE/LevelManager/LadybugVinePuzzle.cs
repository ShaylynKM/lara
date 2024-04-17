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
        }
    }

    void Update()
    {
        CheckIfVinesAreCut();
    }

}
