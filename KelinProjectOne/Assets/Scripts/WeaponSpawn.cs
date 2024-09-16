using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject[] weapons;
    bool spawned;
    float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !spawned)
        {
            timer = 2f;
            Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, Quaternion.identity);
            spawned = true;
        }
    }
}
