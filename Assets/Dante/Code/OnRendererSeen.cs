using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnRendererSeen : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> OnRendererVisibilityChanged;

    private Renderer _renderer;
    private bool _currentState = false;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (_currentState != _renderer.isVisible)
        {
            _currentState = _renderer.isVisible;
            OnRendererVisibilityChanged.Invoke(_currentState);
        }
    }
}
