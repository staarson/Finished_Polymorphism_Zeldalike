using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBow : CatWeapon {

    public GameObject _arrowPrefab;

    public override void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        GameObject newArrowGO = Instantiate(_arrowPrefab, transform.position, Quaternion.identity);
        Vector2 dir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        newArrowGO.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        newArrowGO.GetComponent<Arrow>()._damage = _damage;
    }
}
