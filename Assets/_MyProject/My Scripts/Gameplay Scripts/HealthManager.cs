using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth = 3;

    public void Damage (float damageValue)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageValue;
        }
  
        else if(currentHealth <= 0)
        {
            Dead();
            GameplayManager.gameplayManager.GameOverState();
        }
    }

    public void Dead()
    {
        //Do Death Function Here
    }
}
