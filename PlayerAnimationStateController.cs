using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathAnimation(bool isDead)
    {
        animator.SetBool("isDead", isDead);
    }


}
