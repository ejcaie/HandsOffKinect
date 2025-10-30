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
        //player1Manager.currentState
        //player2Manager.switch(currentState).idle;
        RoundUpdate();
    }

    void RoundUpdate()
    {
        if (timer.value > 0)
        {
            timer.value = timer.value - 1 * Time.deltaTime;
            RoundUpdate();
        }
        else EndRound();
    }

    public void EndRound()
    {
        print("its so over");
    }

}
