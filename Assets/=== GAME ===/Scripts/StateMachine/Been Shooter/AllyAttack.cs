        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : StateBase
{
    public override State State => State.Attack;

    public override void OnEnter()
    {
        animationControl.OnAttack(Attack);
        animationControl.PlayAnimAttack();
        DebugHelper.Log("Ally Attack", "magenta");
    }

    public override void OnExit()
    {
        animationControl.OnAttack(null);
    }
    public override void OnPhysicUpdate()
    {
    }

    public override void OnUpdate()
    {
    }
    void Attack()
    {
        // Spawn projectile
        // Sfx
        DebugHelper.Log("Ally Attack", "green");
    }
}
