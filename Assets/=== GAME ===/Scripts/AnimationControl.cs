using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Action onAttack = null;
    [SerializeField] Animator anim;

    public void PlayAnimIdle()
    {
        anim.Play("Idle");
    }
    [ContextMenu("Attack Anim")]
    public void PlayAnimAttack()
    {
        anim.Play("Attack");    
    }
    public void PlayAnimDie()
    {

    }
    public void Attack()
    {
        onAttack?.Invoke();
    }
    public void OnAttack(Action action) => onAttack = action;
}
