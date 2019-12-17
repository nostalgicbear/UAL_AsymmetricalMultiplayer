using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class GameController : MonoBehaviour
{
    float startWait = 5.0f;
    public bool gameWon = false;
    bool gameRunning = false;

    public Text timerText;
    private float totalTime = 10.0f;
    private float currentTimeLeft;

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public UnityEvent OnStartGame;

    public BoxManager redBox, blueBox;

    public Light gameStateLight;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {

        if(!gameRunning)
        {
            return;
        }

        currentTimeLeft = totalTime - (Time.timeSinceLevelLoad - startWait);
        timerText.text =currentTimeLeft.ToString();

        CheckForGameComplete();
        CheckForGameOver();
    }

    private void CheckForGameComplete()
    {
        if(redBox.currentBallCount >= redBox.totalBallsNeeded && blueBox.currentBallCount >= blueBox.totalBallsNeeded)
        {
            GameCompleted();
        }
    }

    private void CheckForGameOver()
    {
        if(!gameWon && currentTimeLeft <= 0)
        {
            GameFailed();
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(startWait);
        OnStartGame.Invoke();
        gameRunning = true;
    }

    private void GameFailed()
    {
        currentTimeLeft = 0.0f;
        gameRunning = false;
        Debug.LogError("GAME FAILED");
        SetLightColour(Color.red);
    }

    private void SetLightColour(Color colToSet)
    {
        gameStateLight.color = colToSet;
    }

    public void GameCompleted()
    {
        SetLightColour(Color.green);
        gameRunning = false;    
    }


}
