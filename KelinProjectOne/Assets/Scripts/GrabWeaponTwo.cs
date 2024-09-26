using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeaponTwo : MonoBehaviour
{
    public AudioController audioCon;
    private Queue<GameObject> grabbedWeapons = new Queue<GameObject>();
    public Transform[] hands;
    public float force;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ThrowWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
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
        if (grabbedWeapons.Count > 5)
        {
            return;
        }
        if (grabbedWeapons.Count < 6)
        {
            grabbedWeapons.Enqueue(obj);
            obj.gameObject.transform.SetParent(transform);
            obj.gameObject.transform.localPosition = new Vector3(1, 1, 1);
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
            rb.AddForce(force * new Vector3(0, 1, 1));
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
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(force * new Vector3(0, 1, 1));
            }
        }
    }
}
