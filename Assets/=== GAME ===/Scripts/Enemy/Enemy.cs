using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    public override bool AnyTargetInAttackRange => throw new System.NotImplementedException();

    private void Awake()
    {
        stateMachine.InitStateMachine(animControl);
        data.Init();
        data.OnDie(() => stateMachine.ChangeState(State.Die));
    }
}
