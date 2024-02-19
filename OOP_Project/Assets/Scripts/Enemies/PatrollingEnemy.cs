using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    public float _patrolDistance = 2;
    public float _patrolSpeed = 1;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Move()
    {
        base.Move();
        Vector3 direction = new Vector3(1, 0, 0);

        transform.position += Mathf.Sin(Time.time * _patrolSpeed) * direction * _patrolDistance * Time.fixedDeltaTime;
    }
}
