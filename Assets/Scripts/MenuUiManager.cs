using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuUiManager : MonoBehaviour
{

    public AudioManager audioManager;
    private string steeringMethod;
    public Button touchButton;
    public Button tiltButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SteeringMethod")) //check the steering settings where set by player
        {
            steeringMethod = PlayerPrefs.GetString("SteeringMethod");
        } else
        { //default
            steeringMethod = "touch";
        }
        SetUpSteeringMethodButtons();
        audioManager.mainMenuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetUpSteeringMethodButtons()
    {
        if (steeringMethod == "touch")
        {
            touchButton.gameObject.SetActive(true);
            tiltButton.gameObject.SetActive(false);
            
        } else if (steeringMethod == "tilt")
        {
            touchButton.gameObject.SetActive(false);
            tiltButton.gameObject.SetActive(true);
        }
    }

    public void SelectSteeringMethod()
    {
        if (steeringMethod == "touch")
        {
            steeringMethod = "tilt";
        }
        else if (steeringMethod == "tilt")
        {
            steeringMethod = "touch";
        }
        SetUpSteeringMethodButtons();
        PlayerPrefs.SetString("SteeringMethod", steeringMethod);
        PlayerPrefs.Save();
    }
}
