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
            StartCoroutine("ThrowWeaponCoroutine");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartCoroutine("ThrowAllWeaponCoroutine");
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
        if (grabbedWeapons.Count < 5)
        {
            grabbedWeapons.Enqueue(obj);
            obj.gameObject.transform.SetParent(hands[grabbedWeapons.Count - 1]);
            obj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            obj.GetComponent<FruitBullet>().isHold = true;
        }
    }

    private void ThrowWeapon()
    {
        if (grabbedWeapons.Count > 0)
        {
            GameObject obj = grabbedWeapons.Dequeue();
            obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

            obj.gameObject.transform.SetParent(null);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(force * new Vector3(0, 1, 1));
            obj.GetComponent<FruitBullet>().isHold = false;
        }
    }

    IEnumerator ThrowWeaponCoroutine()
    {
        if (grabbedWeapons.Count > 0)
        {
            GameObject obj = grabbedWeapons.Dequeue();
            obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

            yield return new WaitForSeconds(0.7f);

            obj.gameObject.transform.SetParent(null);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(force * new Vector3(0, 1, 1));
            obj.GetComponent<FruitBullet>().isHold = false;
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

    IEnumerator ThrowAllWeaponCoroutine()
    {
        if (grabbedWeapons.Count > 0)
        {
            while (grabbedWeapons.Count > 0)
            {
                GameObject obj = grabbedWeapons.Dequeue();
                obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

                yield return new WaitForSeconds(0.7f);

                obj.gameObject.transform.SetParent(null);
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(force * new Vector3(0, 1, 1));
                //yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
