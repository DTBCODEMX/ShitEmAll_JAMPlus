using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody = null;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layer_mask;
    [SerializeField] private BoxCollider2D _box_collider;
    private static int horizontal_speed_id = Animator.StringToHash("PlayerSpeedHorizontal");
    public float speed = 2.00f;
    public bool is_dead = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0.0f;
        Debug.Assert(_joystick,"joystick needs to be asigned a joysick" );
        _animator = GetComponent<Animator>();
        _layer_mask = 1 << LayerMask.NameToLayer("Enemies");
        _box_collider = GetComponent<BoxCollider2D>();
        is_dead = false;
    }

    void Update()
    {
        float vertical_input = _joystick.Vertical;
        float horizonatal_input = _joystick.Horizontal;
        
        transform.Translate(Vector3.right * (horizonatal_input * speed * Time.deltaTime));
        transform.Translate(Vector3.up * (vertical_input * speed * Time.deltaTime));

       handle_collision(); 
        

        _animator.SetFloat("PlayerSpeedHorizontal", MathF.Abs(horizonatal_input));
        
        flip_sprite(horizonatal_input);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            GetComponent<PlayerShitTaking>().increment_current_total_craps(5);
            Destroy(col.gameObject);
        }
    }


    private void flip_sprite(float direction)
    {
        Vector2 scale = transform.localScale;
        if (direction > 0.0f)
        {
            scale.x = -1.0f;
        }
        else if (direction < 0.0f)
        {
            scale.x = 1.0f;
        }
        transform.localScale = scale;
    }

    private void handle_collision()
    {
        if (!Physics2D.OverlapBox(transform.position, _box_collider.size, 0.0f, _layer_mask))
        {
            return;
        }
        print("The dude got me");
        gameObject.SetActive(false);
    }
    
    
}