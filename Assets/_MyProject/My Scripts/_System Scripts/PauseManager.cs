using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManager;
    StarterAssets.StarterAssetsInputs playerControls;

    public string thisSceneName;

    UIManager uIManager;

    [HideInInspector] public bool isPausing;

    private void Awake()
    {
        pauseManager = this;
    }

    private void Start()
    {
        uIManager = UIManager.uIManager;
        uIManager.pauseMenuContainer.SetActive(false);
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new StarterAssets.StarterAssetsInputs();

            
        }
    }

    private void DoPause(InputAction.CallbackContext obj)
    {

    }

    public void PauseGame() //called from PlayerInput
    {
        uIManager.pauseMenuContainer.SetActive(true);

        isPausing = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        isPausing = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        uIManager.pauseMenuContainer.SetActive(false);
    }

    public void RestartGame()
    {
       SceneManager.LoadScene(thisSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
