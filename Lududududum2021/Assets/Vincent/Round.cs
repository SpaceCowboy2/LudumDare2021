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
    public GameObject player1 = null;
    public GameObject player2 = null;
    public Transform posP1 = null;
    public Transform posP2 = null;

    public int ScoreMax = 0;

    private int nbCurrentRound = 0;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private float timer = 0f;
    private bool onRound = false;

    private void Update()
    {
        if (onRound)
        {
            timer += Time.deltaTime;
        }

        timerText.text = ((int)timer / 60).ToString("00") + " : " + ((int)timer%60).ToString("00");
    }

    public void StartRound()
    {
        onRound = true;
        endRoundPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        player1.transform.position = posP1.position;
        player2.transform.position = posP2.position;
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

    public void AddScorePlayer1()
    {
        scoreP1++;
    }

    public void AddScorePlayer2()
    {
        scoreP2++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            AddScorePlayer1();
            EndRound();
        }
        else if (other.tag == "Player2")
        {
            AddScorePlayer2();
            EndRound();
        }
    }

}
