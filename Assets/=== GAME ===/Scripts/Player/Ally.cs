using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : CharacterBase
{
    [SerializeField] LayerMask whatIsEnemy;
    private void Awake()
    {
        stateMachine.InitStateMachine(animControl);
        data.Init();
        data.OnDie(() => stateMachine.ChangeState(State.Die));
    }
    RaycastHit2D hit;
    public override bool AnyTargetInAttackRange
    {
        get
        {
            if (!data.canAttack) return false;
            hit = Physics2D.Raycast(transform.position, Vector2.right, data.info.radiusAttack, whatIsEnemy);
            if (hit.collider != null) return true;
            return false;
        }
    }


    private void Update()
    {
        if (AnyTargetInAttackRange) stateMachine.ChangeState(State.Attack);
        else stateMachine.ChangeState(State.Idle);
    }
    private void OnDrawGizmos()
    {
        if (data != null && data.canAttack)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * data.info.radiusAttack);
        }
    }
    [ContextMenu("Set die")]
    public void SetDie()
    {
        data.MinusHp(data.hp);
    }
}
public abstract class CharacterBase : MonoBehaviour
{
    public StateMachine stateMachine;
    public AnimationControl animControl;
    public CharacterSO data;

    public abstract bool AnyTargetInAttackRange { get; }
}