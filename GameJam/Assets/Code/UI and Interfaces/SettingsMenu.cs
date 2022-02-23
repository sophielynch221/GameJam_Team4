using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    Movement inputActions;

    private void Start()
    {
        inputActions = new Movement();
        inputActions.Enable();
    }

    private void Update()
    {
        // If the corresponding key is pressed, close down the settings menu.
        if (inputActions.Player.Pause.triggered)
        {
            CloseSettingsMenu();
        }    
    }

    // Unload the settings interface.
    public void CloseSettingsMenu()
    {
        this.gameObject.SetActive(false);
    }
}
