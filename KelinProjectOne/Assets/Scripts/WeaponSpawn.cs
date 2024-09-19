using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] weapons;
    float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            
            int spawnIndex = Random.Range(0, 4);
            if(spawnPoints[spawnIndex].childCount == 0)
            {
                timer = 2f;
                Instantiate(weapons[Random.Range(0, 6)], spawnPoints[spawnIndex]);
            }
            else
            {
                return;
            }
        }
    }
}
