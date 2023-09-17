using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManager;
    
    public GameObject pauseMenuContainer;

    private void Awake()
    {
        uIManager = this;
    }

}
