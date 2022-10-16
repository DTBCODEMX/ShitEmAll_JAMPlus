using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBound : MonoBehaviour
{
 [SerializeField] private GameObject bottom_left = null;
 [SerializeField] private GameObject top_right = null;

 [SerializeField] private PlayerController _player_ref;

    // Start is called before the first frame update
    void Start()
    {
        bottom_left = GameObject.FindGameObjectWithTag("BottomLeft");
        top_right= GameObject.FindGameObjectWithTag("TopRight");
        Debug .Assert(bottom_left != null,"bottom left must be defined");
        Debug .Assert(top_right != null, "top_right must be defined");
        _player_ref = FindObjectOfType<PlayerController>();
        
    }

    void Update()
    {
        Vector2 player_position = _player_ref.transform.position;
        Vector2 top_right_pos = top_right.transform.position;
        Vector2 bottom_left_pos = bottom_left.transform.position;
        if (player_position.x > top_right_pos.x )
        {
            _player_ref.transform.position = new Vector2(top_right_pos.x,player_position.y) ;
        }
        if (player_position.y > top_right_pos.y )
        {
            _player_ref.transform.position = new Vector2( player_position.x, top_right_pos.y ) ;
        }
        if (player_position.x < bottom_left_pos.x)
        {
            _player_ref.transform.position = new Vector2(bottom_left_pos.x, player_position.y) ;
        }

        if (player_position.y < bottom_left_pos.y)
        {
            _player_ref.transform.position = new Vector2(player_position.x, bottom_left_pos.y) ;
        }
    }
}
