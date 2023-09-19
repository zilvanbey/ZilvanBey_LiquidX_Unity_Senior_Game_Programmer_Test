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
    //The functionality of this function is currently only made for this Showcase
    //Hoverer, it can be extended by adding additional functionalities as development progresses
    public void GameOverState() 
    {
        gameOverScreen.SetActive(true);

        //Do Game Over functions here
    }

    public void VictoryState()
    {
        victoryScreen.SetActive(true);

        //Do Victory functions here
    }
}
