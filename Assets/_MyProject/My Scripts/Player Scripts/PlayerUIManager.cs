using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIManager : MonoBehaviour
{
    public Image healthBar;

    public void AdjustHealthBar(float currentHealthValue, float maxHealthValue)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealthValue / maxHealthValue;
        }
    }
}
