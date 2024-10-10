using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHp;
    public int maxHp;

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    private void Update()
    {
        if(currentHp <= 0)
        {
            //game over
        }
    }
}
