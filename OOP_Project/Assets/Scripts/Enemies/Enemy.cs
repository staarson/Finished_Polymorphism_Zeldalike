using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("How much XP the player gets when he kills the Enemy")]
    public int _xpValue = 10;
    public float _maxHp = 1;
    public float _damage = 1;

    private float _curHp;

    protected virtual void Awake()
    {
        _curHp = _maxHp;
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Needs to be overriden in Subclasses to move the Enemy
    /// </summary>
    protected virtual void Move()
    {

    }

    protected virtual void Die()
    {
        FindObjectOfType<PlayerController>()._Experience += _xpValue;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player != null)//Wenn mit Player kollidiert
        {
            player._CurHp -= _damage;
            Die();
        }
    }

    public float _CurHp
    {
        get { return _curHp; }
        set
        {
            _curHp = value;
            if (_curHp <= 0)
                Die();
        }
    }

}
