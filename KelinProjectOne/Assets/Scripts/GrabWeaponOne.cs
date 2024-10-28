using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeaponOne : MonoBehaviour
{
    public AudioController audioCon;
    private Queue<GameObject> grabbedWeapons = new Queue<GameObject>();
    public Transform[] hands;
    public float force;
    public Animator anim;
    public Transform armSocket;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //ThrowWeapon();
            StartCoroutine("ThrowWeaponCoroutine");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine("ThrowAllWeaponCoroutine");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (grabbedWeapons.Count < 5)
            {
                if (other.gameObject.GetComponent<FruitBullet>().isFirstContact == false)
                {
                    return;
                }
                else
                {
                    GrabWeapon(other.gameObject);
                    other.gameObject.GetComponent<FruitBullet>().isFirstContact = false;
                    //Debug.Log("111");
                }
            }
            else
            {
                return;
            } 
        }
    }

    private void GrabWeapon(GameObject obj)
    {
        //if (grabbedWeapons.Count >= 5)
        //{
        //    return;
        //}
        //if (grabbedWeapons.Count < 5)
        //{
            //Debug.Log("Queue count before enqueue: " + grabbedWeapons.Count);
            grabbedWeapons.Enqueue(obj);
            armSocket.GetChild(grabbedWeapons.Count - 1).gameObject.SetActive(true);
            //Debug.Log("Queue count before enqueue: " + grabbedWeapons.Count);
            obj.gameObject.transform.SetParent(hands[grabbedWeapons.Count - 1]);
            obj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            obj.GetComponent<FruitBullet>().isHold = true;
        obj.GetComponent<FruitBullet>().isPlayerOne = true;
        //}
    }

    //private void ThrowWeapon()
    //{
    //    if (grabbedWeapons.Count > 0)
    //    {
    //        GameObject obj = grabbedWeapons.Dequeue();
    //        obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

    //        obj.gameObject.transform.SetParent(null);
    //        Rigidbody rb = obj.GetComponent<Rigidbody>();
    //        rb.isKinematic = false;
    //        rb.AddForce(force * new Vector3(0, 1, 1));
    //        obj.GetComponent<FruitBullet>().isHold = false;
    //    }
    //}

    IEnumerator ThrowWeaponCoroutine()
    {
        if (grabbedWeapons.Count > 0)
        {
            //Debug.Log("Queue count before Dequeue: " + grabbedWeapons.Count);
            GameObject obj = grabbedWeapons.Dequeue();
            //Debug.Log("Queue count after Dequeue: " + grabbedWeapons.Count);
            obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

            

            yield return new WaitForSeconds(0.7f);

            obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.SetActive(false);
            obj.gameObject.transform.SetParent(null);
            
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(force * new Vector3(0, 1, 1));
            obj.GetComponent<FruitBullet>().isHold = false;
        }
    }

    //private void ThrowAllWeapon()
    //{
    //    if (grabbedWeapons.Count > 0)
    //    {
    //        while (grabbedWeapons.Count > 0)
    //        {
    //            GameObject obj = grabbedWeapons.Dequeue();
    //            obj.gameObject.transform.SetParent(null);
    //            Rigidbody rb = obj.GetComponent<Rigidbody>();
    //            rb.isKinematic = false;
    //            rb.AddForce(force * new Vector3(0, 1, 1));
    //        }
    //    }
    //}

    IEnumerator ThrowAllWeaponCoroutine()
    {
        if (grabbedWeapons.Count > 0)
        {
            while (grabbedWeapons.Count > 0)
            {
                GameObject obj = grabbedWeapons.Dequeue();
                obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<Animator>().SetTrigger("Throw");

                yield return new WaitForSeconds(0.7f);

                obj.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.SetActive(false);
                obj.gameObject.transform.SetParent(null);
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(force * new Vector3(0, 1, 1));
                //yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
