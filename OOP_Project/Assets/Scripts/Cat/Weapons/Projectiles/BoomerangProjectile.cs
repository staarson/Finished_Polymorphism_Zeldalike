using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour {

    public int _damage;
    public float _projectileDuration;

    public Transform _toReturnTransform;
    public Vector3 _targetPos;
    private Vector3 _originPos;

    private float _timeAlive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy._CurHp -= _damage;
        }
    }

    private void Awake()
    {
        _originPos = transform.position;
    }

    private void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive < _projectileDuration / 2)
            transform.position = Vector3.Lerp(_originPos, _targetPos, (_timeAlive / _projectileDuration) * 2);
        else if (_timeAlive < _projectileDuration)
        {
            transform.position = Vector3.Lerp(_targetPos, _toReturnTransform.position, (-_projectileDuration / 2 + (_timeAlive / _projectileDuration) * 2));
            Vector2 dir = _toReturnTransform.position - _targetPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
            Destroy(gameObject);
        //Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.DrawLine(Camera.main.transform.position, mouseWorldPos);
    }
}
