using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnSight : MonoBehaviour
{
    [SerializeField, Range(0.5f, 20)] private float _speed = 0;
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField, Range(0.1f, 15)] private float _rayDistance = 5;
    [SerializeField] private Transform _hitOrigin;
    [SerializeField] private Vector2 _dir= Vector2.right;

    private void Update()
    {
        if (!_canMove) return;
        if(Physics2D.Raycast(_hitOrigin.position, _dir, _rayDistance, _layerMask)) return;
        
        transform.Translate(_speed * Time.deltaTime * _dir);
    }
    
    private bool _isVisibleForFirstTime = false;
    private bool _canMove = false;
    public void OnRenderVisibiltyChanged(bool state)
    {
        if (_isVisibleForFirstTime) return;
        _canMove = true;
        _isVisibleForFirstTime = state;
    }

    private void OnDrawGizmos()
    {
        var hit = Physics2D.Raycast(_hitOrigin.position, _dir, _rayDistance, _layerMask);
        if (hit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, hit.point);
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawLine(_hitOrigin.position, _hitOrigin.position + ((Vector3)_dir * _rayDistance));
        Gizmos.color = Color.white;
    }
}
