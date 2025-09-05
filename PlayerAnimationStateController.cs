using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsDead)
        {
            animator.SetBool("isDead", true);
        }
    }
}
