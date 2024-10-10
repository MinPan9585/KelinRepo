using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBullet : MonoBehaviour
{
    public GameObject explodeFX;
    public float radius;
    public LayerMask layerMask;
    public bool isHold = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isHold)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                if (Physics.OverlapSphere(transform.position, radius, layerMask) != null)
                {
                    Debug.Log("hit something");
                    Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
                    if(hits.Length > 0)
                    {
                        //if (hits[0].gameObject.CompareTag("Player"))
                        {
                            Debug.Log("Hit Player");
                            hits[0].gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
                        }
                    }
                }



                Instantiate(explodeFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
