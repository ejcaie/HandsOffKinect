using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer bodyRenderer;
    public PlayerHealth playerController;

    private readonly int IdleHash = Animator.StringToHash("idle");
    private readonly int ReadyUpHash = Animator.StringToHash("readyUp");
    private readonly int LightHash = Animator.StringToHash("light");
    private readonly int MediumHash = Animator.StringToHash("medium");
    private readonly int HeavyHash = Animator.StringToHash("heavy");
    private readonly int BlockHash = Animator.StringToHash("block");
    private readonly int CounterHash = Animator.StringToHash("counter");
    private readonly int DeadHash = Animator.StringToHash("dead");

    void Update()
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (playerController.previousState != playerController.currentState)
        {
            switch (playerController.currentState)
            {
                case PlayerState.idle:
                    animator.CrossFade(IdleHash, 0);
                    break;
                case PlayerState.readyUp:
                    animator.CrossFade(ReadyUpHash, 0);
                    break;
                case PlayerState.light:
                    animator.CrossFade(LightHash, 0);
                    break;
                case PlayerState.medium:
                    animator.CrossFade(MediumHash, 0);
                    break;
                case PlayerState.heavy:
                    animator.CrossFade(HeavyHash, 0);
                    break;
                case PlayerState.block:
                    animator.CrossFade(BlockHash, 0);
                    break;
                case PlayerState.counter:
                    animator.CrossFade(CounterHash, 0);
                    break;
                case PlayerState.dead:
                    animator.CrossFade(DeadHash, 0);
                    break;
            }
        }
    }
}
