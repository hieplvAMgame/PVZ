using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyIdle : StateBase
{
    public override State State => State.Idle;

    [SerializeField] bool isSF;

    public override void OnEnter()
    {
        animationControl.PlayAnimIdle();
        DebugHelper.Log("Ally Idle", "blue");
        time = 0;
    }

    public override void OnExit()
    {

    }

    public override void OnPhysicUpdate()
    {
    }
    float time = 0;
    [SerializeField] GameObject sun;
    GameObject o;
    public override void OnUpdate()
    {
        if (!isSF) return;
        if (time >= 8)
        {
            Vector2 posSpawn = GetPosSpawn(1);
            o = Instantiate(sun, transform.position, Quaternion.identity);
            o.transform.DOMove(posSpawn, .3f);
             // spawn sun
             time = 0;
        }
        else
            time += Time.deltaTime;
    }
    public Vector2 GetPosSpawn(float radius)
    {
        float r = Random.Range(0, 2f* Mathf.PI);
        float randomRadius = Random.Range(0, radius);

        return new Vector2(transform.position.x + randomRadius * Mathf.Cos(r)
            , transform.position.y + randomRadius * Mathf.Sin(r));
    }
}
