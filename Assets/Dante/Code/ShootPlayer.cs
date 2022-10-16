using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField, Range(0.1f, 15)] private float _ShootingTime;
    [SerializeField] private BalaMovement BalaPrefab;

    private PlayerController _player;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _player = FindObjectOfType<PlayerController>();
        Debug.Assert(_player, "There has to be a player in the active scene");
    }


    private void Start()
    {
        
        WaitForShoot();
    }

    private void WaitForShoot()
    {
        StartCoroutine(WaitForShootCor());
    }

    private IEnumerator WaitForShootCor()
    {
        yield return new WaitForSeconds(_ShootingTime);
        Shoot();

        WaitForShoot();
    }


    private void Shoot()
    {
        var position = _transform.position;
        var playerPos = _player.transform.position;
        var shootDir = playerPos - position;
        var dir = shootDir.y > 0 ? _transform.right : -_transform.right;
        var angle = Vector2.Angle(dir, shootDir);
        if (shootDir.y < 0)
            angle -= 180;
        
        var rot = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(BalaPrefab, position, rot);
        
    }
}