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
        gameOver = false;
        score = 1;
        digit1 = GameObject.Find("digit1").GetComponent<Image>();
        digit2 = GameObject.Find("digit2").GetComponent<Image>();
        digit3 = GameObject.Find("digit3").GetComponent<Image>();
        digit4 = GameObject.Find("digit4").GetComponent<Image>();

        digit1.GetComponent<Image>().sprite = scoreDigits[0];
        digit2.GetComponent<Image>().sprite = scoreDigits[0];
        digit3.GetComponent<Image>().sprite = scoreDigits[0];
        digit4.GetComponent<Image>().sprite = scoreDigits[0];


      //  InvokeRepeating("scoreUpdate", 1.0f, 0.5f); //calls some function many times every some amount time
    }

    // Update is called once per frame
    void Update()
    {
        scoreString = score.ToString();
    }

    void setScoreDigits()
    {
        //set first (rightmost) digit
        digitFourNo = (int)Char.GetNumericValue(scoreString[0]);

        if (score > 10) //set second
        {
            int digitFourTemp = digitFourNo;
            digitThreeNo = (int)Char.GetNumericValue(scoreString[1]);
            digitFourNo = digitThreeNo;
            digitThreeNo = digitFourTemp;

            if (score > 100) //third
            {
                int digitThreeTemp = digitThreeNo;
                digitTwoNo = (int)Char.GetNumericValue(scoreString[2]);
                digitThreeNo = digitTwoNo;
                digitTwoNo = digitThreeTemp;

                if (score > 1000) //4th
                {
                    int digitTwoTemp = digitTwoNo;
                    digitOneNo = (int)Char.GetNumericValue(scoreString[3]);
                    digitTwoNo = digitOneNo;
                    digitOneNo = digitTwoTemp;
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

    public int GetScore()
    {
        return score;
    }

    public void GameOverActivated()
    {
        gameOver = true;
        gameOverMenu.gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0; //pauses the game   
    }

    public void Resume()
    {
        Time.timeScale = 1; //resumes the game   
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load again same scene
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }




}
