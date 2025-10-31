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
    public int savedPose;
    public int totalHealth;
    public int currentHealth;
    public PlayerState currentState;
    public PlayerState previousState;
    public Slider healthBar;

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
                savedPose = 0;
                break;
            case PlayerState.readyUp:
                SavePose();
                break;
            case PlayerState.light:
                savedPose = 1;
                break;
            case PlayerState.medium:
                savedPose = 2;
                break;
            case PlayerState.heavy:
                savedPose = 3;
                break;
            case PlayerState.block:
                savedPose = 4;
                break;
            case PlayerState.counter:
                savedPose = 5;
                break;
        }



        healthBar.value = currentHealth;
        if (currentHealth > totalHealth) currentHealth = totalHealth;



        //For Wizard of Oz playtest
        if (Input.GetKeyDown(KeyCode.Q) && playerID == "Player1 Manager")
        {
            currentHealth = currentHealth - 2;
        }

        if (Input.GetKeyDown(KeyCode.W) && playerID == "Player1 Manager")
        {
            currentHealth = currentHealth - 4;
        }

        if (Input.GetKeyDown(KeyCode.E) && playerID == "Player1 Manager")
        {
            currentHealth = currentHealth - 5;
        }

        if (Input.GetKeyDown(KeyCode.R) && playerID == "Player1 Manager")
        {
            currentHealth = currentHealth + 3;
        }




        if (Input.GetKeyDown(KeyCode.A) && playerID == "Player2 Manager")
        {
            currentHealth = currentHealth - 2;
        }

        if (Input.GetKeyDown(KeyCode.S) && playerID == "Player2 Manager")
        {
            currentHealth = currentHealth - 4;
        }

        if (Input.GetKeyDown(KeyCode.D) && playerID == "Player2 Manager")
        {
            currentHealth = currentHealth - 5;
        }

        if (Input.GetKeyDown(KeyCode.F) && playerID == "Player2 Manager")
        {
            currentHealth = currentHealth + 3;
        }
    }

    void SavePose()
    {

    }
}
