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
        var owner = GetOwner<Ally>();
        go = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        go.Setup(Vector2.right, speedProjectile, owner.data);
        go.tag = owner.tag;
    }
    [SerializeField] Projectile projectile;
    [SerializeField] Transform shootingPoint;
    [SerializeField] float speedProjectile;
    Projectile go;

}
