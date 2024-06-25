using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController instance;
    public Animator animator;

    private void Start()
    {
        instance = this;
        //animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Zapper.deadAnimation += DeadAnimation;
    }

    private void OnDisable()
    {
        Zapper.deadAnimation -= DeadAnimation;
    }

    public void jumpAnimation()
    {
        animator.SetTrigger("Jump");
    }

    public void DeadAnimation()
    {
        animator.SetTrigger("Dead");
    }

    public void RunAnimation()
    {
        animator.SetTrigger("run");
    }
}
