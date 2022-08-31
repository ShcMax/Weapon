using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Aim : IAim
{
    public Transform BarrelPositionAim { get; }
    public GameObject AimInstance { get; }

    public GameObject AimClone { get; }

    public Aim(Transform barrelPositionAim, GameObject aimInstance, GameObject aimClone)
    {
        BarrelPositionAim = barrelPositionAim;
        AimInstance = aimInstance;
        AimClone = aimClone;
    }
}
