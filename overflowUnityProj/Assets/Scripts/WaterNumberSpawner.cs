using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNumberSpawner : MonoBehaviour
{

    public GameObject floatingNumberPrefab; // assign your number prefab
    public Sprite[] numberSprites;          // assign all number sprites here
    public Transform waterTransform;        // the water object
    public float spawnInterval = 0.5f;      // time between spawns
    public float spawnWidth = 5f;           // width inside water to spawn numbers

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnNumber();
            timer = 0f;
        }
    }

    private void SpawnNumber()
    {
        // Random horizontal spawn within the water
        Vector3 spawnPos = new Vector3(
            waterTransform.position.x + Random.Range(-spawnWidth / 2f, spawnWidth / 2f),
            waterTransform.position.y,
            0f
        );

        GameObject number = Instantiate(floatingNumberPrefab, spawnPos, Quaternion.identity);

        // Pick random sprite
        Sprite randomSprite = numberSprites[Random.Range(0, numberSprites.Length)];

        // Initialize the floating number and pass in the water width
        number.GetComponent<FloatingNumber2D>().SetNumber(randomSprite);
    }
}
