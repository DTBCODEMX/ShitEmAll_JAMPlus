using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private const float DEFAULT_MAX_HORIZONALTAL_DISTANCE_FROM_PLAYER = 10.0f;
    [SerializeField] private PlayerController _player_ref = null;
    
    // added this because the name is very long
    [Tooltip("max horizontal distance from player")]
    [SerializeField] private float _max_horizonaltal_distance_from_player = 0.0f;
    void Start()
    {
        _player_ref = GameObject.FindObjectOfType<PlayerController>();
        if (_max_horizonaltal_distance_from_player < 0.01f)
        {
            _max_horizonaltal_distance_from_player = DEFAULT_MAX_HORIZONALTAL_DISTANCE_FROM_PLAYER;
        }

    }

    void Update()
    { 
      float current_distance = (transform.position.x - _player_ref.transform.position.x);

      if (MathF.Abs(current_distance) > _max_horizonaltal_distance_from_player)
      {
          float direction_to_move = 0.0f;
          if (current_distance > 0.0f)
          {
              direction_to_move = -1.0f;
          }
          else
          {
              direction_to_move = 1.0f;
          }
          
          transform.Translate( _player_ref.speed * direction_to_move * Time.deltaTime, 0,0);
      }
      
      

    } 
}
