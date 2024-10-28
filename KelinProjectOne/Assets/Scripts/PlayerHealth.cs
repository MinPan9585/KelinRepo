using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    public Image healthBar;

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
        else if(currentHp >= maxHp)
        {
            currentHp = maxHp;
        }
        healthBar.fillAmount = (float)currentHp / maxHp;
    }
}
