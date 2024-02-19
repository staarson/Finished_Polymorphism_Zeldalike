using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherProjectile : MonoBehaviour {

    public GameObject _explodingParticleEffect;
    public float _speed;
    public float _damage;
    public float _explosionRadius;
    
	
	private void FixedUpdate () {
        transform.position += transform.up * _speed * Time.fixedDeltaTime;
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        Explode();

        Destroy(gameObject);
    }

    private void Explode()
    {
        Instantiate(_explodingParticleEffect, transform.position, Quaternion.identity);
        Collider2D[] affectedColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        for (int i = 0; i < affectedColliders.Length; i++)
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
}
