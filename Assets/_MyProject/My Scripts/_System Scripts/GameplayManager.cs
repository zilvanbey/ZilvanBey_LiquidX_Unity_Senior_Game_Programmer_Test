using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager gameplayManager;

    private void Awake()
    {
        gameplayManager = this;
    }

    //Note:
    //The functionality of this function is currently only for made for this Showcase
    //Hoverer, it can be adjusted and fleshed out later on in development
    public void GameOverState() 
    {
        //Do Game Over functions here

        //Call Game Over Screen here
    }
}
