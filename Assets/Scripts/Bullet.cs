using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Bullet : IAmmunation
{
    public Rigidbody BulletInstance { get; }
    public float TimeToDestroy { get; }
    
    public Bullet(Rigidbody bulletInstance, float timeToDestroy)
    {
        BulletInstance = bulletInstance;
        TimeToDestroy = timeToDestroy;
    }
}
