using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IAmmunation
{
    Rigidbody BulletInstance { get; }
    float TimeToDestroy { get; }
}
