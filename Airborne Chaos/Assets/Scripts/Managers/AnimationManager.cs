using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void SetThrowing(bool value)
    {
        animator.SetBool("isThrowing", value);
        Debug.Log("isThrowing: " + value);
    }
    public void SetOnCollision(bool value)
    {
        animator.SetBool("isOnCollision", value);
    }
    public void PlayIdle()
    {
        animator.SetBool("isThrowing", false);
        animator.SetBool("isOnCollision", false);
    }
}
