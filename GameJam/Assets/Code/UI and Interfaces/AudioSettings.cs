using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    // Code based on https://www.youtube.com/watch?v=yWCHaTwVblk&ab_channel=Hooson


    [SerializeField] private Slider             _musicVolumeSlider;                 // Slider object responsible for setting the ingame sound volume.
    [SerializeField] private TextMeshProUGUI    _musicVolumeText;                   // Text showing the current volume of the ingame sound.




    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            LoadSettings();
        }
        else
        {
            LoadSettings();
        }
    }




    public void ChangeVolume()
    {
        AudioListener.volume = Mathf.RoundToInt(_musicVolumeSlider.value);
        SaveSettings();

        _musicVolumeText.text = Mathf.RoundToInt(_musicVolumeSlider.value * 100).ToString(); 
    }




    private void LoadSettings()
    {
        _musicVolumeSlider.value = PlayerPrefs.GetInt("MusicVolume");

        _musicVolumeText.text = Mathf.RoundToInt(_musicVolumeSlider.value * 100).ToString();
    }


    private void SaveSettings()
    {
        PlayerPrefs.SetInt("MusicVolume", Mathf.RoundToInt(_musicVolumeSlider.value));
    }
}
