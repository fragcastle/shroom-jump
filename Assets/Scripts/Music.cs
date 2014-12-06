using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Music : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey(Constants.MusicEnabled))
        {
            var musicEnabled = PlayerPrefs.GetInt(Constants.MusicEnabled) == 1;
            
            if (musicEnabled)
            {
                audio.Play();
            }
            
            var gameObject = GameObject.Find("MusicToggle");
            var toggle = gameObject.GetComponent<Toggle>();
            toggle.isOn = musicEnabled;
        }
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            audio.Play();
        else
            audio.Stop();
        
        PlayerPrefs.SetInt(Constants.MusicEnabled, enabled ? 1 : 0);
    }
}
