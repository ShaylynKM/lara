using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    private Rotate rotate;
    private GameObject leafWater;
    private GameObject dirt;
    private GameObject seed;
    private GameObject babyFlower;
    private bool rigidbodyAdded = false;

    private float targetRotation = 60f;
    private float thresholdYPosition = -7.5f;

    // Start is called before the first frame update
    void Start()
    {
        rotate = GameObject.Find("leafLeaf").GetComponent<Rotate>();
        leafWater = GameObject.Find("leafWater");
        dirt = GameObject.Find("dirt");
        seed = GameObject.Find("seed");
        babyFlower = GameObject.Find("babyFlower");
    }

    // Update is called once per frame
    void Update()
    {
        if (leafWater != null)
        {
            float leafWaterYAxis = leafWater.transform.position.y;

            if (rotate.GetRotation() >= targetRotation && !rigidbodyAdded)
            {
                leafWater.AddComponent<Rigidbody>();
                rigidbodyAdded = true;
            }

            if (leafWaterYAxis <= thresholdYPosition)
            {
                seed.SetActive(false);

                Sprite newSprite = Resources.Load<Sprite>("L1_CloseDirt");

                SpriteRenderer dirtSpriteRenderer = dirt.GetComponent<SpriteRenderer>();
                if (dirtSpriteRenderer != null && newSprite != null)
                {
                    dirtSpriteRenderer.sprite = newSprite;
                    Debug.Log("changed");
                    StartCoroutine(ActivateBabyFlower());
                }
                else
                {
                    Debug.Log("man");
                }
            }
        }
    }

    IEnumerator ActivateBabyFlower()
    {
        yield return new WaitForSeconds(1f);
        babyFlower.SetActive(true);
        float speedFactor = 0.1f; 
        float minMoveSpeed = 0.2f * speedFactor; 
        float maxMoveSpeed = 0.8f * speedFactor;
        float minDistanceToMove = 0.5f;
        float maxDistanceToMove = 1.5f;
        float shakeRange = 0.04f * speedFactor; 
        float thresholdYPositionBabyFlower = -2.7f;

        while (babyFlower.transform.position.y < thresholdYPositionBabyFlower)
        {
            float moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            float distanceToMove = Random.Range(minDistanceToMove, maxDistanceToMove) * speedFactor; 
            float shakeAmount = Random.Range(-shakeRange, shakeRange) * speedFactor;
            Vector3 shakeVector = new Vector3(shakeAmount, 0f, 0f);
            float step = moveSpeed * Time.deltaTime;
            Vector3 newPosition = babyFlower.transform.position + Vector3.up * step * distanceToMove + shakeVector;
            babyFlower.transform.position = newPosition;
            yield return null;
        }

        babyFlower.transform.position = new Vector3(babyFlower.transform.position.x, thresholdYPositionBabyFlower, babyFlower.transform.position.z);
    }



}