using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            //grab the gun
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.localPosition = new Vector3(1, 1, 1);
        }
    }
}
