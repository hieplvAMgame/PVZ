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
        data.OnDie(() => 
        stateMachine.ChangeState(State.Die));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ally"))
        {
            collision.TryGetComponent(out Projectile p);
            if(p!= null)
            {
                data.MinusHp(p.GetDamage);
                p.gameObject.SetActive(false);
            }
        }
    }
}
