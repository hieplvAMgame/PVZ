using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDie : StateBase
{
    public override State State => State.Die;

    public override void OnEnter()
    {
        stateMachine.gameObject.SetActive(false);
        DebugHelper.Log("Ally Idle", "red");
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
