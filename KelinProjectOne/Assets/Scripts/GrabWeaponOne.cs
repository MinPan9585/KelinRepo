using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeaponOne : MonoBehaviour
{
    private Queue<GameObject> grabbedWeapons = new Queue<GameObject>();
    public Transform[] hands;
    public float force;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThrowAllWeapon();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            GrabWeapon(other.gameObject);
        }
    }

    private void GrabWeapon(GameObject obj)
    {
        if (grabbedWeapons.Count >= 5)
        {
            return;
        }
        if (grabbedWeapons.Count < 5)
        {
            grabbedWeapons.Enqueue(obj);
            obj.gameObject.transform.SetParent(hands[grabbedWeapons.Count - 1]);
            obj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void ThrowWeapon()
    {
        if (grabbedWeapons.Count > 0)
        {
            GameObject obj = grabbedWeapons.Dequeue();
            obj.gameObject.transform.SetParent(null);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(force * new Vector3(0,1,1));

            //play animation

            //obj.gameObject.transform.position = transform.position + transform.forward * 5;
        }
    }

    private void ThrowAllWeapon()
    {
        if (grabbedWeapons.Count > 0)
        {
            while (grabbedWeapons.Count > 0)
            {
                GameObject obj = grabbedWeapons.Dequeue();
                obj.gameObject.transform.SetParent(null);
                obj.gameObject.transform.position = transform.position + transform.forward * 5;
            }
        }
    }
}
