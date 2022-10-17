using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is so the enemy know when they have been hit by a projectile from the player
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyMask : MonoBehaviour
{
    [SerializeField] private LayerMask _player_projectile_mask;
    [SerializeField] private BoxCollider2D _box;
    //[Se]
    [SerializeField] private bool _is_dead = false;

    void Start()
    {
        _player_projectile_mask = 1 << LayerMask.NameToLayer("PlayerProjectiles");
        _box = GetComponent<BoxCollider2D>();
        _is_dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapBox(_box.transform.position, _box.size, 0.0f, _player_projectile_mask);
        if (!col) return;
        _is_dead = true; 
//        var a =  Resources.Load("Lapida");
        gameObject.SetActive(false);
    }
    
    public bool is_dead => _is_dead;


}