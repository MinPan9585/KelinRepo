using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBullet : MonoBehaviour
{
    public GameObject explodeFX;
    public float radius;
    public LayerMask layerMask;
    public bool isHold = false;
    public bool isFirstContact = true;
    public int index;
    GameObject watermelonBlockOne;
    GameObject watermelonBlockTwo;
    public bool isPlayerOne = false;
    public GameObject player;
    public int damage;

    private void Start()
    {
        GameObject uiCanvas = GameObject.Find("Canvas");
        watermelonBlockOne = uiCanvas.transform.GetChild(6).gameObject;
        watermelonBlockTwo = uiCanvas.transform.GetChild(7).gameObject;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isHold)
        {
            if(other.gameObject.CompareTag("Healing"))
            {
                if (isPlayerOne)
                {
                    player = GameObject.Find("PlayerOne");
                }
                else
                {
                    player = GameObject.Find("PlayerTwo");
                }
                Debug.Log("Healing");
                
                        player.GetComponent<PlayerHealth>().currentHp += 20;
                        Destroy(other.transform.parent.gameObject);
            }
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
                            hits[0].gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                        }
                    }

                    if (index == 5)
                    {
                        if (isPlayerOne)
                        {   
                            if(watermelonBlockOne.activeSelf == true)
                            {
                                return;
                            }
                            else
                            {
                                watermelonBlockOne.SetActive(true);
                                StartCoroutine(CloseWatermelonOne());
                            }
                        }
                        else
                        {
                            if (watermelonBlockTwo.activeSelf == true)
                            {
                                return;
                            }
                            else
                            {
                                watermelonBlockTwo.SetActive(true);
                                StartCoroutine(CloseWatermelonTwo());
                            }
                        }
                    }
                }

                

                Instantiate(explodeFX, transform.position, Quaternion.identity);
                Destroy(gameObject, 4);
            }
        }
        
    }

    IEnumerator CloseWatermelonOne()
    {
        yield return new WaitForSeconds(3f);
        watermelonBlockOne.SetActive(false);
        print("333");
    }
    IEnumerator CloseWatermelonTwo()
    {
        yield return new WaitForSeconds(3f);
        watermelonBlockTwo.SetActive(false);
    }
}
