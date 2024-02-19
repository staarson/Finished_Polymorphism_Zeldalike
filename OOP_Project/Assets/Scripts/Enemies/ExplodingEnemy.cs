using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy {

    public float _explosionRadius;
    public GameObject _explodingParticleEffect;

    protected override void Die()
    {
        base.Die();
        Instantiate(_explodingParticleEffect, transform.position, Quaternion.identity);
        Collider2D[] affectedColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        for(int i=0; i<affectedColliders.Length; i++)
        {
            PlayerController player = affectedColliders[i].GetComponent<PlayerController>();
            if (player != null)
                player._CurHp -= _damage;
            else
            {
                Enemy enemy = affectedColliders[i].GetComponent<Enemy>();
                if (enemy != null && enemy != this)
                    enemy._CurHp -= _damage;
            }
        }

    }

    /// <summary>
    /// Draws the range of the explosion when the pumpkin is selected
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
