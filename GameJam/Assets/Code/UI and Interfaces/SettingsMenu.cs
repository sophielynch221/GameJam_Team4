using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    private void Update()
    {
        // If the corresponding key is pressed, close down the settings menu.
        if (Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))
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
