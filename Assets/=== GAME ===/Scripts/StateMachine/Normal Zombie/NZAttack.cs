using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NZAttack : StateBase
{
    public override State State => State.Attack;

    public override void OnEnter()
    {
        animationControl.PlayAnimAttack();
        DebugHelper.Log("NZ Attack", "cyan");
    }

    public override void OnExit()
    {
    }

    public override void OnPhysicUpdate()
    {
    }

    public override void OnUpdate()
    {
    }
}
