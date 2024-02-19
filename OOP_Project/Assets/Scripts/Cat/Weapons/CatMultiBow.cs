using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMultiBow : CatWeapon {

    public GameObject _multiArrowPrefab;

    public override void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector2 dir = mouseWorldPos - transform.position;
        float angle1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 70;
        FireArrow(angle1);
        float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        FireArrow(angle2);
        float angle3 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 110;
        FireArrow(angle3);
    }

    void FireArrow(float angle)
    {
        GameObject newArrowGO = Instantiate(_multiArrowPrefab, transform.position, Quaternion.identity);
        newArrowGO.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        newArrowGO.GetComponent<Arrow>()._damage = _damage;
    }
}
