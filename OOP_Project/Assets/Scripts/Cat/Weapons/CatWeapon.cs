using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWeapon : MonoBehaviour {

    public int _damage = 1;
    public float _projectileSpeed = 1;

    public virtual void Shoot()
    {
        //Needs to be overriden in ChildClasses
    }
}
