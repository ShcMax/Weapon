using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

internal sealed class Example : MonoBehaviour
{
    private IFire _fire;

    [Header("Start Gun")]
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _barrelPosition;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    [Header("Muffler Gun")]
    [SerializeField] private AudioClip _audioClipMuffler;
    [SerializeField] private float _volumeFireOnMuffler;
    [SerializeField] private Transform _barrelPositionMuffler;
    [SerializeField] private GameObject _muffler;

    [Header("Aim Gun")]
    [SerializeField] private Transform _barrelPositionAim;
    [SerializeField] private GameObject _aim;
    [SerializeField] private GameObject _clone;

    
    private void Start()
    {
        IAmmunation ammunation = new Bullet(_bullet, 3.0f);
        var weapon = new Weapon(ammunation, _barrelPosition, 999.0f, _audioSource, _audioClip, _clone);

        var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
        ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
        modificationWeapon.ApplyModification(weapon);
        _fire = modificationWeapon;

        var aim = new Aim(_barrelPosition, _aim, _clone);
        ModificationWeapon modificationWeapon1 = new ModificationAim(aim, _barrelPositionAim.position);
        modificationWeapon1.ApplyModification(weapon);
        _fire = modificationWeapon1;       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _fire.Fire();            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IAmmunation ammunation = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunation, _barrelPosition, 999.0f, _audioSource, _audioClip, _clone);
            var aimClone = new Aim(_barrelPosition, _aim, _clone);
            ModificationWeapon modificationWeapon = new ModificationAim(aimClone, _barrelPositionAim.position);
            modificationWeapon.RemoveModification(weapon);
            _fire = modificationWeapon;
        }
    }

}
