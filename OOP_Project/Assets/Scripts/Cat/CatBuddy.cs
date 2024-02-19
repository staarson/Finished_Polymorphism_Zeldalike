using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBuddy : MonoBehaviour {

    public CatBow _catBow;
    public CatMultiBow _catMultiBow;
    public CatBoomerang _catBoomerang;
    public CatRocketLauncher _catRocketLauncher;

    public CatWeapon _equippedWeapon;

    void Update () {

        //TODO: When KeyCode.Mouse1 is pressed -> shoot with the equipped weapon.
		if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            _equippedWeapon.Shoot();
        }
        //TODO: switch Weapons with 1,2,3 by setting _equippedWeapon to one of the 3 Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _equippedWeapon = _catBow;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _equippedWeapon = _catMultiBow;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            _equippedWeapon = _catBoomerang;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            _equippedWeapon = _catRocketLauncher;
    }
}
