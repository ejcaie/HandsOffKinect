using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public PlayerHealth player1Manager;
    public PlayerHealth player2Manager;

    void Start()
    {
        
    }

    void StartRound()
    {
        player1Manager.switch(currentState).idle;
        player2Manager.switch(currentState).idle;
    }

    void EndRound()
    {

    }

}
