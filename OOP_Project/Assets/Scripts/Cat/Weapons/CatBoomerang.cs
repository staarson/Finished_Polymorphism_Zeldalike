using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoomerang : CatWeapon {

    public GameObject _boomerangPrefab;
    public float _range = 5;

    public override void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3 dir = mouseWorldPos - transform.position;
        GameObject newArrowGO = Instantiate(_boomerangPrefab, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        newArrowGO.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        BoomerangProjectile boomerang = newArrowGO.GetComponent<BoomerangProjectile>();
        boomerang._damage = _damage;
        boomerang._toReturnTransform = transform;
        boomerang._targetPos = transform.position + dir.normalized * _range;
        boomerang._projectileDuration = _projectileSpeed;
    }
}
