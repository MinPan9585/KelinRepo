using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnArms : MonoBehaviour
{
    public Transform[] armPos;
    public GameObject armPrefab;
    
    void Start()
    {
        for (int i = 0; i < armPos.Length; i++)
        {
            Instantiate(armPrefab, armPos[i]);
        }
    }
}
