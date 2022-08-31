using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ModificationAim : ModificationWeapon
{
    private readonly IAim _aim;
    private readonly Vector3 _aimPosition;    


    public ModificationAim(IAim aim, Vector3 aimPosition)
    {
        _aim = aim;
        _aimPosition = aimPosition;        
    }

    protected override Weapon AddModification(Weapon weapon)
    {
        var aim = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.identity);
        weapon.SetBarrelPosition(_aim.BarrelPositionAim);
        return weapon;        
    }

    protected override Weapon DeleteModification(Weapon weapon)
    {
        var aim = GameObject.FindGameObjectWithTag("Aim");
        aim.SetActive(false);        
        return weapon;
    }

}
