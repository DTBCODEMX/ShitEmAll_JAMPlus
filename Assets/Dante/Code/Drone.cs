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
    
    private Vector3 _currentTargetPos;
    private Coroutine _shootCoroutine = null;

    public void Start()
    {
        SetNewTargetPos();
        FollowTarget();

    }

    private void Update()
    {
        Transform mTransform;
        (mTransform = transform).position = Vector3.MoveTowards(transform.position, _currentTargetPos, Time.deltaTime * _speed);
        var leftRay = Physics2D.Raycast(mTransform.position, -mTransform.right, _rayLenght);
        var righttRay = Physics2D.Raycast(mTransform.position, mTransform.right, _rayLenght);

        if (leftRay || righttRay)
        {
            
        }
    }

    public void Init(Transform target)
    {
        _targetTransform = target;
    }

    private void SetNewTargetPos()
    {
        _currentTargetPos = _targetTransform.position;
    }

    private void FollowTarget()
    {
        StartCoroutine(FollowTargetCor()); 
    }
    

    private IEnumerator FollowTargetCor()
    {
        yield return new WaitForSeconds(_waitTime);
        SetNewTargetPos();
        FollowTarget();
    }
    
}
