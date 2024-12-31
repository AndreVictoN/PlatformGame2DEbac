using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("ANIM_Idle"))
        {
            animator.Play("ANIM_Idle", 0, 0);
        }
    }
}
