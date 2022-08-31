using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Weapon : IFire
{
    private Transform _barrelPosition;
    private IAmmunation _bullet;
    private float _force;
    private AudioClip _audioClip;
    private readonly AudioSource _audioSource;
    private GameObject _modification;
    

    public Weapon(IAmmunation bullet, Transform barrelPosition, float force, AudioSource audioSource, AudioClip audioClip, GameObject modification)
    {
        _bullet = bullet;
        _barrelPosition = barrelPosition;
        _force = force;
        _audioSource = audioSource;
        _audioClip = audioClip;
        _modification = modification;
    }

    public void SetBarrelPosition(Transform barrelPosition)
    {
        _barrelPosition = barrelPosition;
    }

    public void SetBullet(IAmmunation bullet)
    {
        _bullet = bullet;
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        _audioClip = audioClip;
    }    
    
    public void RemoveAim(GameObject aim)
    {
        _modification = aim;
    }

    public void Fire()
    {
        var bullet = Object.Instantiate(_bullet.BulletInstance, _barrelPosition.position, Quaternion.identity);
        bullet.AddForce(_barrelPosition.forward * _force);
        Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
        _audioSource.PlayOneShot(_audioClip);
    }
}
