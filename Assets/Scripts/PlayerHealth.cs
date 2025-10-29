using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    public enum playerState 
    {
        idle, checkPose, pose1, pose2, pose3, pose4, pose5, dead
    }

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;
    public playerState currentState;

    void Start()
    {
        currentHealth = totalHealth;
        currentState = idle;
    }

    void Update()
    {
        
    }
}
