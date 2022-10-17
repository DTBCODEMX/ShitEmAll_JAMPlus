using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(Rigidbody2D))]
public class LevelEnd : MonoBehaviour
{
    public string next_scene;
    void Start()
    {
        Debug.Assert(next_scene != "", "give string the name of next level dude");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(next_scene);
        }
    }
}