using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject healingObject;
    float timer = 2f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int spawnIndex = Random.Range(0, 3);
            if (spawnPoints[spawnIndex].childCount == 0)
            {
                timer = 2f;
                Instantiate(healingObject, spawnPoints[spawnIndex]);
            }
            else
            {
                return;
            }
        }
    }
}
