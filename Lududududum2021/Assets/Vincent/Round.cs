using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{

    public GameObject endRoundPanel = null;
    public GameObject mainMenuPanel = null;
    public Text timerText = null;
    public Text scoreP1Text = null;
    public Text scoreP2Text = null;
    public Text roundText = null;
    public GameObject buttonNextRound = null;
    public GameObject buttonRestartRound = null;

    public int ScoreMax = 0;

    /*public Player player1;
    public Player player2;*/

    private int nbCurrentRound = 0;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private float timer = 0f;
    private bool onRound = false;

    public bool endRound = false;

    private void Update()
    {
        if (onRound)
        {
            timer += Time.deltaTime;
        }

        if (endRound)
        {
            endRound = false;
            EndRound();
        }

        timerText.text = ((int)timer / 60).ToString("00") + " : " + ((int)timer%60).ToString("00");
    }

    public void StartRound()
    {
        onRound = true;
        endRoundPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        nbCurrentRound++;
        timer = 0f;
    }

    public void EndRound()
    {
        onRound = false;

        endRoundPanel.SetActive(true);
        scoreP1Text.text = scoreP1.ToString();
        scoreP2Text.text = scoreP2.ToString();
        roundText.text = nbCurrentRound.ToString();

        if (scoreP1 == ScoreMax ||scoreP2 == ScoreMax)
        {
            EndGame();
        }
    }

    public void Restart()
    {
        onRound = false;
        scoreP1 = 0;
        scoreP2 = 0;
        nbCurrentRound = 0;
        StartRound();
    }

    public void EndGame()
    {
        buttonNextRound.SetActive(false);
        buttonRestartRound.SetActive(true);
    }

    public void MainMenu()
    {
        endRoundPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
