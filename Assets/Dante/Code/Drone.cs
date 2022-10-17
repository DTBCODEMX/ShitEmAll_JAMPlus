using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _speed = 5;
    [SerializeField, Range(0.2f, 0.8f)] private float _waitTime = 0.2f;
    [SerializeField, Range(0.5f, 5)] private float _rayLenght = 2;
    
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _cadencyTime = 0.5f;
    [SerializeField] private BalaMovement _balaPrefab;

    private Vector3 _currentTargetPos;
    private Coroutine _shootCoroutine = null;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = transform;
    }
    
    public void Start()
    {
        SetNewTargetPos();
        FollowTarget();
    }

    private void Update()
    {
        if (!_canMove) return;
        _transform.position = Vector3.MoveTowards(_transform.position, _currentTargetPos, Time.deltaTime * _speed);
        var leftRay = Physics2D.Raycast(_transform.position, _transform.right, _rayLenght, layerMask: _playerMask);
        var righttRay = Physics2D.Raycast(_transform.position,_transform.right, _rayLenght, layerMask: _playerMask);
        
        if (leftRay || righttRay)
        {
            var dir = leftRay ? Vector3.left : Vector3.right;
            if (_shootCoroutine == null)
            {
                _shootCoroutine = StartCoroutine(ShootCor(dir));
            }
        }
    }

    private IEnumerator ShootCor(Vector3 dir)
    {
        var bala = Instantiate(_balaPrefab, _transform.position, Quaternion.identity);
        bala.Init(dir);
        
        yield return new WaitForSeconds(_cadencyTime);
        _shootCoroutine = null;
    }

    public void Init(Transform target)
    {
        _targetTransform = target;
    }

    private void OnWillRenderObject()
    {
        Debug.Log(Camera.current.name);
    }

    private void SetNewTargetPos()
    {
        _currentTargetPos = _targetTransform.position;
    }

    private void FollowTarget()
    {
        StartCoroutine(FollowTargetCor()); 
    }

    private bool _isVisibleForFirstTime = false;
    private bool _canMove = false;
    public void OnRenderVisibiltyChanged(bool state)
    {
        if (_isVisibleForFirstTime) return;
        _canMove = true;
        _isVisibleForFirstTime = state;
    }

    private IEnumerator FollowTargetCor()
    {
        yield return new WaitForSeconds(_waitTime);
        SetNewTargetPos();
        FollowTarget();
    }
    
}
