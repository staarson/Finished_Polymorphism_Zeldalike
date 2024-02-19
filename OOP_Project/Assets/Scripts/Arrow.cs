using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float _speed;
    public float _damage;
	
	private void FixedUpdate () {
        transform.position += transform.up * _speed * Time.fixedDeltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy._CurHp -= _damage;
        }

        Destroy(gameObject);
    }
}
