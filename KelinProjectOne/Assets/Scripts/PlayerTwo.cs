using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.UpArrow))
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
    }
}
