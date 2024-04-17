using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LadybugVinePuzzle : MonoBehaviour
{
    //private VineCutting vine4Cutting;
    private GameObject redLadybug;
    private GameObject orangeLadybug;
    private GameObject secateurs;

    [SerializeField]
    private UnityEvent pathClear;

    private ChangeScenes changeScenes;

    [SerializeField]
    private SpriteRenderer[] vinesToCut;
    [SerializeField]
    private ChangeVine[] vinesCut;

    private SpriteRenderer vinesToCutRenderer;

    private void CheckIfVinesAreCut()
    {
        bool areVinesCut = true;
        foreach (ChangeVine vineCut in vinesCut)
        {
            areVinesCut &= !vineCut.isVisible;
        }
        if (areVinesCut)
        {
            pathClear.Invoke();
        }
        return;
        // If all of the vines in the path of the ladybug are cut, invoke an event which calls the function from LadybugPath that moves the ladybug and ends the puzzle.
        foreach (SpriteRenderer vineToCut in vinesToCut)
        {
            bool allVinesClear = false; // Variable to keep track of if all the vines in the path have their SpriteRenderers disabled

            if (vinesToCutRenderer?.enabled == true)
            {
                allVinesClear = false; // If any vine in the path has its renderer enabled, that means all vines have not been cleared.
                break;
            }

            if (allVinesClear == true)
            {
                pathClear.Invoke();
            }

        }
    }

    void Start()
    {
        changeScenes = GameObject.Find("SceneManager").GetComponent<ChangeScenes>();

        //vine4Cutting = GameObject.Find("Vine4").GetComponent<VineCutting>();
        redLadybug = GameObject.Find("Ladybug1");
        //orangeLadybug = GameObject.Find("Ladybug2");
        secateurs = GameObject.Find("Secateurs");

        Debug.Log("Number of vines to clear = " + vinesToCut.Length);
    }

    void Update()
    {

        CheckIfVinesAreCut();

        //if (vine4Cutting.isCut)
        //{
        //    float speed = 5f; 
        //    float moveAmount = speed * Time.deltaTime;

        //    orangeLadybug.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        //    orangeLadybug.transform.Translate(Vector3.up * moveAmount);

        //    redLadybug.transform.Translate(Vector3.up * moveAmount);

        //    Destroy(secateurs); // Destroy the secateurs when the last vine is cut

        //    StartCoroutine(StartNewScene());
        //}
    }

    //IEnumerator StartNewScene()
    //{
    //    yield return new WaitForSeconds(4f);
    //    changeScenes.LoadNextScene();
    //}
}
