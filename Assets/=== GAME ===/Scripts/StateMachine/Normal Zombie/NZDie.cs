using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NZDie : StateBase
{
    public override State State => State.Die;

    public override void OnEnter()
    {
        DebugHelper.Log("Ally Attack", "#ff00a6");
        stateMachine.gameObject.SetActive(false);
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
