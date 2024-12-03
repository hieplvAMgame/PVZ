using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NZIdle : StateBase
{
    public override State State => State.Idle;
    float moveSpeed;
    public override void OnEnter()
    {
        moveSpeed = stateMachine.transform.GetComponent<CharacterBase>().data.info.moveSpeed;
        animationControl.PlayAnimIdle();
        DebugHelper.Log("NZ Idle", "yellow");
    }

    public override void OnExit()
    {
        moveSpeed = 0;
    }

    public override void OnPhysicUpdate()
    {
    }

    public override void OnUpdate()
    {
        stateMachine.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
