using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody = null;
    public float speed = 1.00f;
    private bool _do_flap = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0.0f;
    }

    void Update()
    {
        float horizonatal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * (horizonatal_input * speed * Time.deltaTime) );
        transform.Translate(Vector3.up * (vertical_input * speed * Time.deltaTime) );


    }

}