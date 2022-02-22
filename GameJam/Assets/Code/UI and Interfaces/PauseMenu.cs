using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject     _pauseMenu;                 // Pause screen.         
    [SerializeField] private GameObject     _settingsMenu;              // Settings interface.

    private bool    _paused             = false;                        // Is the game currently paused.




    [System.Obsolete]
    private void Update()
    {
        // Switch on or off the pause menu when the settings aren't open.
        if (Input.GetButtonDown("Pause"))
        {

            if (!_settingsMenu.active)
            {
                if (!_paused)
                {
                    PauseGame();
                }
                else
                {
                    UnPauseGame();
                }
            }
        }
    }




    // Freeze the game and load the menu interface.
    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale  = 0;
        _paused         = true;
    }


    // Unfreeze the game and unload the menu interface.
    public void UnPauseGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale  = 1;
        _paused         = false;
    }
}
