using System;
using System.Collections;
using System.Collections.Generic;
//using MoreMountains.Tools;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody = null;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _shit_starting_location = null;
    [SerializeField] private GameObject _shit_prefab = null;
    [SerializeField] private Animator _animator;
    private static int horizontal_speed_id = Animator.StringToHash("PlayerSpeedHorizontal");
    public float speed = 2.00f;
    private bool _do_flap = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0.0f;
        Debug.Assert(_joystick, "joystick needs to be asigned a joysick");
        Debug.Assert(_shit_starting_location, "_shit_starting_location needs to be asigned a gameobject");
        Debug.Assert(_shit_prefab, "_shit_prefab needs to be asigned a prefab");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float vertical_input = _joystick.Vertical;
        float horizonatal_input = _joystick.Horizontal;

        transform.Translate(Vector3.right * (horizonatal_input * speed * Time.deltaTime));
        transform.Translate(Vector3.up * (vertical_input * speed * Time.deltaTime));

        _animator.SetFloat("PlayerSpeedHorizontal", MathF.Abs(horizonatal_input));

        flip_sprite(horizonatal_input);
    }

    public void shit()
    {
        GameObject go = Instantiate(_shit_prefab, _shit_starting_location.transform);

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

}