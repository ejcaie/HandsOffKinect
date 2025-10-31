using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum PlayerState 
    {
        idle, readyUp, light, medium, heavy, block, counter, dead
    }

public class PlayerHealth : MonoBehaviour
{
    public RoundManager roundManager;
    public string playerID;
    public int totalHealth;
    public int currentHealth;
    public PlayerState currentState;
    public PlayerState previousState;
    public Slider healthBar;

    public bool readyUpPose;
    public bool lightPose;
    public bool mediumPose;
    public bool heavyPose;
    public bool blockPose;
    public bool counterPose;


    void Start()
    {
        playerID = this.name;
        currentHealth = totalHealth;
        currentState = PlayerState.idle;
    }

    void Update()
    {
        previousState = currentState;

        switch(currentState)
        {
            case PlayerState.dead:
                break;
            case PlayerState.idle:
                if (readyUpPose)
                {
                    currentState = PlayerState.readyUp;
                    readyUpPose = false;
                    lightPose = false;
                    mediumPose = false;
                    heavyPose = false;
                    blockPose = false;
                    counterPose = false;
                }
                break;
            case PlayerState.readyUp:
                if (roundManager.inRound == true)
                {
                    if (lightPose)
                    {
                        currentState = PlayerState.light;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (mediumPose)
                    {
                        currentState = PlayerState.medium;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (heavyPose)
                    {
                        currentState = PlayerState.heavy;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (blockPose)
                    {
                        currentState = PlayerState.block;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (counterPose)
                    {
                        currentState = PlayerState.counter;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                break;
            case PlayerState.light:
                if (roundManager.inRound == true)
                {
                    if (mediumPose)
                    {
                        currentState = PlayerState.medium;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (heavyPose)
                    {
                        currentState = PlayerState.heavy;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (blockPose)
                    {
                        currentState = PlayerState.block;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (counterPose)
                    {
                        currentState = PlayerState.counter;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                else if (readyUpPose) currentState = PlayerState.readyUp;
                break;
            case PlayerState.medium:
                if (roundManager.inRound == true)
                {
                    if (lightPose)
                    {
                        currentState = PlayerState.light;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (heavyPose)
                    {
                        currentState = PlayerState.heavy;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (blockPose)
                    {
                        currentState = PlayerState.block;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (counterPose)
                    {
                        currentState = PlayerState.counter;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                else if (readyUpPose) currentState = PlayerState.readyUp;
                break;
            case PlayerState.heavy:
                if (roundManager.inRound == true)
                {
                    if (lightPose)
                    {
                        currentState = PlayerState.light;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (mediumPose)
                    {
                        currentState = PlayerState.medium;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (blockPose)
                    {
                        currentState = PlayerState.block;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (counterPose)
                    {
                        currentState = PlayerState.counter;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                else if (readyUpPose) currentState = PlayerState.readyUp;
                break;
            case PlayerState.block:
                if (roundManager.inRound == true)
                {
                    if (lightPose)
                    {
                        currentState = PlayerState.light;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (mediumPose)
                    {
                        currentState = PlayerState.medium;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (heavyPose)
                    {
                        currentState = PlayerState.heavy;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (counterPose)
                    {
                        currentState = PlayerState.counter;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                else if (readyUpPose) currentState = PlayerState.readyUp;
                break;
            case PlayerState.counter:
                if (roundManager.inRound == true)
                {
                    if (lightPose)
                    {
                        currentState = PlayerState.light;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (mediumPose)
                    {
                        currentState = PlayerState.medium;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (heavyPose)
                    {
                        currentState = PlayerState.heavy;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                    else if (blockPose)
                    {
                        currentState = PlayerState.block;
                        readyUpPose = false;
                        lightPose = false;
                        mediumPose = false;
                        heavyPose = false;
                        blockPose = false;
                        counterPose = false;
                    }
                }
                else if (readyUpPose) currentState = PlayerState.readyUp;
                break;
        }

        healthBar.value = currentHealth;
        if (currentHealth > totalHealth) currentHealth = totalHealth;
        if (currentHealth <= 1) currentState = PlayerState.dead;



        //For Wizard of Oz playtest
        if (Input.GetKeyDown(KeyCode.Q) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.idle;
        }

        if (Input.GetKeyDown(KeyCode.W) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.readyUp;
        }

        if (Input.GetKeyDown(KeyCode.E) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.light;
        }

        if (Input.GetKeyDown(KeyCode.R) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.medium;

        }
        if (Input.GetKeyDown(KeyCode.T) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.heavy;
        }
        if (Input.GetKeyDown(KeyCode.Y) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.block;
        }
        if (Input.GetKeyDown(KeyCode.U) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.counter;
        }
        if (Input.GetKeyDown(KeyCode.I) && playerID == "Player1 Manager")
        {
            currentState = PlayerState.dead;
        }



        if (Input.GetKeyDown(KeyCode.A) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.idle;
        }

        if (Input.GetKeyDown(KeyCode.S) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.readyUp;
        }

        if (Input.GetKeyDown(KeyCode.D) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.light;
        }

        if (Input.GetKeyDown(KeyCode.F) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.medium;

        }
        if (Input.GetKeyDown(KeyCode.G) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.heavy;
        }
        if (Input.GetKeyDown(KeyCode.H) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.block;
        }
        if (Input.GetKeyDown(KeyCode.J) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.counter;
        }
        if (Input.GetKeyDown(KeyCode.K) && playerID == "Player2 Manager")
        {
            currentState = PlayerState.dead;
        }
    }
}
