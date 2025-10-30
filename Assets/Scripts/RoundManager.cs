using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public PlayerHealth player1Manager;
    public PlayerHealth player2Manager;
    public Slider timer;

    void Start()
    {
        timer.value = 5f;
        StartRound();
    }

    void StartRound()
    {
        //player1Manager.currentState.idle
        //player2Manager.switch(currentState).idle;
        //RoundUpdate();
    }

    void Update()
    {
        timer.value = timer.value - 1 * Time.deltaTime;
    }

    void RoundUpdate()
    {

    }

    public void EndRound()
    {
        print("its so over");

        if (player1Manager.currentHealth < 0 || player2Manager.currentHealth < 0)
        {
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
