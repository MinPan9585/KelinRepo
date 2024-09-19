using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public GameObject bullet;
    public float speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        { }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
