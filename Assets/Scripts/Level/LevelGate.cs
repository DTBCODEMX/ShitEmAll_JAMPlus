using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]
/// Used to put gates that holt the player progress
class LevelGate : MonoBehaviour
{
    // how many of something is required to deactivate this
    [SerializeField] private int _current_score = 0;
    public int score_for_deactivation = 3;
    [SerializeField] private BoxCollider2D _boundry = null;
    [SerializeField] private Rigidbody2D _body = null;

    void Start()
    {
        _boundry = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _body.gravityScale = 0.0f;
    }

    private void Update()
    {
        if (_current_score >= score_for_deactivation)
        {
            _boundry.enabled = false;
            _body.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void increase_score(int amount)
    {
        _current_score += amount;
    }

    public int current_score => _current_score;

    public void reset_score()
    {
        _current_score = 0;
    }
    
}