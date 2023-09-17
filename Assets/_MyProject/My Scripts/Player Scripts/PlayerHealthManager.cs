using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float currentHealth = 3;
    float healthStore;

    private void Awake()
    {
        healthStore = currentHealth;
    }

    public void Damage(float damageValue)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageValue;
        }

        else if (currentHealth <= 0)
        {
            Dead();  
        }

        //I put this here for simplicity, in the future UIs can be adjusted using Unity Events
        PlayerUIManager playerUI = GetComponent<PlayerUIManager>();
        if(playerUI != null)
        {
            playerUI.AdjustHealthBar(currentHealth, healthStore);
        }
    }

    public void Dead()
    {
        //Do Death Function Here
        GameplayManager.gameplayManager.GameOverState();
    }
}
