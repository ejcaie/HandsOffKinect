using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum PlayerState 
    {
        idle, checkPose, pose1, pose2, pose3, pose4, pose5, dead
    }

public class PlayerHealth : MonoBehaviour
{
    public RoundManager roundManager;
    public string playerID;
    public int totalHealth;
    public int currentHealth;
    public PlayerState currentState;
    public Slider healthBar;

    void Start()
    {
        playerID = this.name;
        currentHealth = totalHealth;
        currentState = PlayerState.idle;
        print(currentHealth);
    }

    void Update()
    {

        switch(currentState)
        {
            case PlayerState.dead:
                break;
            case PlayerState.idle:
                
                break;
            case PlayerState.checkPose:
                break;
            case PlayerState.pose1:
                break;
            case PlayerState.pose2:
                break;
            case PlayerState.pose3:
                break;
            case PlayerState.pose4:
                break;
            case PlayerState.pose5:
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
}
