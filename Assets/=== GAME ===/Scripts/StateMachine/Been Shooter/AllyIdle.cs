using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyIdle : StateBase
{
    public override State State => State.Idle;

    public override void OnEnter()
    {
        animationControl.PlayAnimIdle();
        DebugHelper.Log("Ally Idle", "blue");
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
