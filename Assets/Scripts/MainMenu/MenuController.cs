using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    [Header ("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue=null;
    [SerializeField] private Slider volumeSlider=null;
    [SerializeField] private GameObject confirmationPrompt=null;      

    [Header ("Levels To Load")]
    public string newGameLevel;
    private string levelToLoad;

    [SerializeField] private GameObject noSaveGameDialog=null;  

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void loadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSaveGameDialog.SetActive(true);
        }

    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text=volume.ToString("0.0");
    }
    
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
