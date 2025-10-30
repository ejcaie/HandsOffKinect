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
    public int savedPose;
    public int totalHealth;
    public int currentHealth;
    public PlayerState currentState;
    public Slider healthBar;

    void Start()
    {
        playerID = this.name;
        currentHealth = totalHealth;
        currentState = PlayerState.idle;
    }

    void Update()
    {
        switch(currentState)
        {
            case PlayerState.dead:
                roundManager.EndRound();
                print(playerID "dead");
                break;
            case PlayerState.idle:
                savedPose = 0;
                print(playerID "idle");
                break;
            case PlayerState.checkPose:
                CheckPose();
                print(playerID "checking");
                break;
            case PlayerState.pose1:
                savedPose = 1;
                CheckPose();
                print(playerID "light");
                break;
            case PlayerState.pose2:
                savedPose = 2;
                CheckPose();
                print(playerID "medium");
                break;
            case PlayerState.pose3:
                savedPose = 3;
                CheckPose();
                print(playerID "heavy");
                break;
            case PlayerState.pose4:
                savedPose = 4;
                CheckPose();
                print(playerID "heal");
                break;
            case PlayerState.pose5:
                savedPose = 5;
                CheckPose();
                print(playerID "block")
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

    void CheckPose()
    {

    }
}
