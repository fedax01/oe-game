using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slime;
    public float spawnInterval = 2f;
    private float spawnTimer = 0f;
    private System.Random rnd = new System.Random();
    private Vector3[] spawnPositions =  new Vector3[]
    { 
        new Vector3(-7.53f, 3.77f,0),
        new Vector3(0.39f, 1.4f, 0),
        new Vector3(5.69f, 3.83f,0)
    };
    // Start is called before the first frame update
    void Start()
    {
        slime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            spawnTimer = 0f;
            int positionIndex = rnd.Next(spawnPositions.Length);
            Vector3 randomPosition = spawnPositions[positionIndex];

            GameObject newSlime = Instantiate(slime, randomPosition, slime.transform.rotation);
            newSlime.SetActive(true);
        }

    }
}
