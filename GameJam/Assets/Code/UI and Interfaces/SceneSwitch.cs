using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InterFacing
{
    public class SceneSwitch : MonoBehaviour
    {
        // Switch the scene to the Starting screen of the game.
        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        // Switch the first playable world of the game.
        public void ToMainGameWorldOne()
        {
            SceneManager.LoadScene("TychoScene");
        }

        // Shut down this instance of the game.
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
