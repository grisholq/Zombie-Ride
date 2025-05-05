using UnityEngine;

public class ZombieAnimator
{
    private Animator animator;
    
    public ZombieAnimator(Animator animator)
    {
        this.animator = animator;
    }
    
    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void StopMovement()
    {
        SetSpeed(0);
    }
}
