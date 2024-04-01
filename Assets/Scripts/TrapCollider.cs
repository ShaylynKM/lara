using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public GameObject[] vineObjects;
    public Sprite originalSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ladybug"))
        {
            // Reset vines to their original state
            foreach (GameObject vineObject in vineObjects)
            {
                VineCutting vineCutting = vineObject.GetComponent<VineCutting>();
                if (vineCutting != null)
                {
                    vineCutting.ResetVine(originalSprite);
                }
            }
        }
    }
}