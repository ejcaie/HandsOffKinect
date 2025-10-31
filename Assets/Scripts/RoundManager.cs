using System;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public PlayerHealth player1Manager;
    public PlayerHealth player2Manager;
    public Slider timer;

    private bool clockRunning = false;

    void Start()
    {
        timer.value = 5f;
        ReadyUp();
    }

    void ReadyUp()
    {
        player1Manager.currentState = PlayerState.idle;
        player2Manager.currentState = PlayerState.idle;

        if (player1Manager.currentState == PlayerState.readyUp && player2Manager.currentState == PlayerState.readyUp)
        {
            clockRunning = true;
        }

        return;
    }

    void Update()
    {
        if (clockRunning) timer.value = timer.value - 1 * Time.deltaTime;

        if (timer.value < 0) EndRound();
    }

    public void EndRound()
    {
        if (player1Manager.currentHealth < 0 || player2Manager.currentHealth < 0)
        {
            print("we done");
            clockRunning = false;
            Results();
        }
        else
        {
            //if both players ready up
            //StartRound();
        }
    }

    public void Results()
    {

    }

}
