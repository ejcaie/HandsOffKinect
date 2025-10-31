using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer bodyRenderer;
    public PlayerHealth playerController;

    private readonly int IdleHash = Animator.StringToHash("Idle");
    private readonly int WalkingHash = Animator.StringToHash("Walking");
    private readonly int JumpingHash = Animator.StringToHash("Jumping");
    private readonly int DeadHash = Animator.StringToHash("Dead");
    private readonly int DashHash = Animator.StringToHash("Dash");

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
                    animator.CrossFade(WalkingHash, 0);
                    break;
                case PlayerState.light:
                    animator.CrossFade(JumpingHash, 0);
                    break;
                case PlayerState.medium:
                    animator.CrossFade(DeadHash, 0);
                    break;
                case PlayerState.heavy:
                    animator.CrossFade(DashHash, 0);
                    break;
                case PlayerState.block:
                    animator.CrossFade(DashHash, 0);
                    break;
                case PlayerState.counter:
                    animator.CrossFade(DashHash, 0);
                    break;
                case PlayerState.dead:
                    animator.CrossFade(DashHash, 0);
                    break;
            }
        }
    }
}
