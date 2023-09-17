using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager gameplayManager;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    private void Awake()
    {
        gameplayManager = this;

        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }

    //Note:
    //The functionality of this function is currently only for made for this Showcase
    //Hoverer, it can be adjusted and fleshed out later on in development
    public void GameOverState() 
    {
        //Do Game Over functions here

        gameOverScreen.SetActive(true);
    }

    public void VictoryState()
    {
        victoryScreen.SetActive(true);
    }
}
