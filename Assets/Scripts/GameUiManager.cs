using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{

    bool gameOver;
    int score;
    public Sprite[] scoreDigits;
    string scoreString;
    public GameObject gameOverMenu;
    public AudioManager audioManager;

    Image digit1;
    Image digit2;
    Image digit3;
    Image digit4;

    int digitOneNo;
    int digitTwoNo;
    int digitThreeNo;
    int digitFourNo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioManager.gameBackgroundMusic.Play();
        gameOver = false;
        score = 0;
        digit1 = GameObject.Find("digit1").GetComponent<Image>();
        digit2 = GameObject.Find("digit2").GetComponent<Image>();
        digit3 = GameObject.Find("digit3").GetComponent<Image>();
        digit4 = GameObject.Find("digit4").GetComponent<Image>();

        digit1.GetComponent<Image>().sprite = scoreDigits[0];
        digit2.GetComponent<Image>().sprite = scoreDigits[0];
        digit3.GetComponent<Image>().sprite = scoreDigits[0];
        digit4.GetComponent<Image>().sprite = scoreDigits[0];


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setScoreDigits()
    {
        scoreString = score.ToString();
        Debug.Log("Score is: " + scoreString);
        //set first (rightmost) digit
        digitFourNo = (int)Char.GetNumericValue(scoreString[0]);

        if (score > 9) //set second
        {
            digitThreeNo = digitFourNo;
            digitFourNo = (int)Char.GetNumericValue(scoreString[1]);

            if (score > 99) //third
            {
                digitTwoNo = digitThreeNo;
                digitThreeNo = (int)Char.GetNumericValue(scoreString[1]);
                digitFourNo = (int)Char.GetNumericValue(scoreString[2]);

                if (score > 999) //4th digit
                {
                    digitOneNo = digitTwoNo;
                    digitTwoNo = (int)Char.GetNumericValue(scoreString[1]);
                    digitThreeNo = (int)Char.GetNumericValue(scoreString[2]);
                    digitFourNo = (int)Char.GetNumericValue(scoreString[3]);
                }
            }
        }
        digit4.GetComponent<Image>().sprite = scoreDigits[digitFourNo];
        digit3.GetComponent<Image>().sprite = scoreDigits[digitThreeNo];
        digit2.GetComponent<Image>().sprite = scoreDigits[digitTwoNo];
        digit1.GetComponent<Image>().sprite = scoreDigits[digitOneNo];

    }

    public void ScoreUpdate() 
    {
        if (!gameOver)
        {
            score += 1;
        }

        setScoreDigits();
    }

    public void AddPillBonus()
    {
        if (!gameOver)
        {
            score += 3;
        }

        setScoreDigits();
    }

    public void AddVaccineBonus()
    {
        if (!gameOver)
        {
            score += 5;
        }

        setScoreDigits();
    }

    public void GameOverActivated()
    {
        gameOver = true;
        gameOverMenu.gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0; //pauses the game  
        audioManager.gameBackgroundMusic.Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1; //resumes the game 
        audioManager.gameBackgroundMusic.Play();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load again same scene
        Resume();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }




}
