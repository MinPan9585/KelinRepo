using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, 0.01f);
    }

}
