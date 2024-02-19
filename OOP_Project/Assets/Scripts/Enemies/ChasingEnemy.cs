using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : Enemy {

    public float _movSpeed;
    private PlayerController _player;

	protected override void Awake()
    {
        base.Awake();
        _player = FindObjectOfType<PlayerController>();
    }

    protected override void Move()
    {
        base.Move();
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * _movSpeed * Time.fixedDeltaTime;
    }
}
