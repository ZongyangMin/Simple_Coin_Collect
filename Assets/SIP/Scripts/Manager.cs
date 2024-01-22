using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    float startFinishTime = 3.0f;
    float endTime = 3.0f;
    float gameTime = 11.0f;
    public TextMeshProUGUI countDown;
    public TextMeshProUGUI gameTimer;
    public TextMeshProUGUI coinCountNum;
    public GameObject win;
    public GameObject lose;
    bool startGame = false;
    public bool canMove = false;
    public GameObject menuScreen;
    public GameObject timer;
    public GameObject coinCounter;
    public GameObject instructions;
    bool gameWin = false;
    bool gameLose = false;
    public bool gameEnd = false;
    public float countCoins;
    public GameObject startMusic;
    public GameObject gameMusic;
    public GameObject winMusic;
    public GameObject loseMusic;
    public GameObject inGameInstructions;
    bool gameTrueEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        countCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(startFinishTime>=0)
        {
            DisplayTime(startFinishTime);
            startFinishTime -= Time.deltaTime;
        }
        else if(startFinishTime<0 && !gameTrueEnd)
        {
            startGame = true;
            menuScreen.SetActive(false);
        }
        else if(startFinishTime<0 && !startGame)
        {
            DisplayTime(endTime);
            endTime -= Time.deltaTime;
        }

        if(startGame)
        {
            canMove = true;
            timer.SetActive(true);
            coinCounter.SetActive(true);
            startDisplayTime(gameTime);
            gameTime -= Time.deltaTime;
            DisplayCoinCount();
            gameMusic.SetActive(true);
            startMusic.SetActive(false);
            inGameInstructions.SetActive(true);
        }
        if(countCoins == 3)
        {
            startGame = false;
            inGameInstructions.SetActive(false);
            canMove = false;
            menuScreen.SetActive(true);
            timer.SetActive(false);
            coinCounter.SetActive(false);
            instructions.SetActive(false);
            win.SetActive(true);
            gameMusic.SetActive(false);
            winMusic.SetActive(true);
            gameTrueEnd = true;
        }
        if(gameEnd || gameTime<0)
        {
            startGame = false;
            inGameInstructions.SetActive(false);
            canMove = false;
            menuScreen.SetActive(true);
            timer.SetActive(false);
            coinCounter.SetActive(false);
            instructions.SetActive(false);
            lose.SetActive(true);
            gameMusic.SetActive(false);
            loseMusic.SetActive(true);
            gameTrueEnd = true;
        }
        if(endTime<0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        countDown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void DisplayCoinCount()
    {
        coinCountNum.text = string.Format("{0}/3", countCoins);
    }
    void startDisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        gameTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
