using System;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public PlayerHealth player1Manager;
    public PlayerHealth player2Manager;
    public Slider timer;

    public bool clockRunning = false;
    public bool inRound = false;
    public bool takingDamage = false;

    void Start()
    {
        timer.value = 5f;
    }

    void ReadyUp()
    {
        if (player1Manager.currentState == PlayerState.readyUp && player2Manager.currentState == PlayerState.readyUp)
        {
            timer.value = 5f;
            clockRunning = true;
            inRound = true;
        }

        return;
    }

    void Update()
    {
        if (clockRunning) timer.value = timer.value - 1 * Time.deltaTime;

        if (timer.value <= 0)
        {
            EndRound();
        }
        if (inRound == false)
        {
            ReadyUp();
        }
    }

    public void EndRound()
    {
        if (inRound)
        {
            if (player1Manager.currentState == PlayerState.light)
            {
                player2Manager.currentHealth = player2Manager.currentHealth - 2;
            }
            else if (player1Manager.currentState == PlayerState.medium)
            {
                if (player2Manager.currentState == PlayerState.block)
                {
                    player2Manager.currentHealth = player2Manager.currentHealth - 1;
                }
                else player2Manager.currentHealth = player2Manager.currentHealth - 3;
            }
            else if (player1Manager.currentState == PlayerState.heavy)
            {
                if (player2Manager.currentState == PlayerState.counter)
                {
                    player1Manager.currentHealth = player1Manager.currentHealth - 4;
                }
                else if (player2Manager.currentState != PlayerState.block)
                {
                    player2Manager.currentHealth = player2Manager.currentHealth - 4;
                }
            }

            if (player2Manager.currentState == PlayerState.light)
            {
                player1Manager.currentHealth = player1Manager.currentHealth - 2;
            }
            else if (player2Manager.currentState == PlayerState.medium)
            {
                if (player1Manager.currentState == PlayerState.block)
                {
                    player1Manager.currentHealth = player1Manager.currentHealth - 1;
                }
                else player1Manager.currentHealth = player1Manager.currentHealth - 3;
            }
            else if (player2Manager.currentState == PlayerState.heavy)
            {
                if (player1Manager.currentState == PlayerState.counter)
                {
                    player2Manager.currentHealth = player2Manager.currentHealth - 4;
                }
                else if (player1Manager.currentState != PlayerState.block)
                {
                    player1Manager.currentHealth = player1Manager.currentHealth - 4;
                }
            }
        }

        inRound = false;


        if (player1Manager.currentState == PlayerState.dead || player2Manager.currentState == PlayerState.dead)
        {
            clockRunning = false;
            Results();
        }
    }

    public void Results()
    {
        print("DING DING, GAME OVER");
    }

}
