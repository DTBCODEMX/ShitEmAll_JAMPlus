using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField, Range(0.1f, 15)] private float _ShootingTime;
    [SerializeField] private BalaMovement BalaPrefab;
    [SerializeField] private LayerMask _layerMask = default;

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
        yield return new WaitUntil(() => _canShoot);
        yield return new WaitForSeconds(_ShootingTime);
        Shoot();

        WaitForShoot();
    }
    
    private bool _isVisibleForFirstTime = false;
    private bool _canShoot = false;
    public void OnRenderVisibiltyChanged(bool state)
    {
        if (_isVisibleForFirstTime) return;
        _canShoot = true;
        _isVisibleForFirstTime = state;
    }

    private void Shoot()
    {
        var position = _transform.position;
        var playerPos = _player.transform.position;
        var shootDir = playerPos - position;
        var hit = Physics2D.Raycast(_transform.position, -_transform.right, 5.3f, _layerMask);
        if (hit)
        {
            Debug.Log("h");
            playerPos = hit.point;
            shootDir.y = 0;
        }

        
        var dir = shootDir.y > 0 ? _transform.right : -_transform.right;
        var angle = Vector2.Angle(dir, shootDir);
        if (shootDir.y < 0)
            angle -= 180;

        var rot = Quaternion.AngleAxis(angle, Vector3.forward);
        var bala = Instantiate(BalaPrefab, position, rot);
        bala.Init(Vector3.right);
    }
}