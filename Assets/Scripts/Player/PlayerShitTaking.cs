using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for when the player character has to take a crap
/// </summary>
///
public class PlayerShitTaking : MonoBehaviour
{
    public int current_max_craps = 30;
    public int current_total_craps = 10;
    [SerializeField] private GameObject _shit_starting_location;
    [SerializeField] private GameObject _shit_prefab;

    void Start()
    {
        current_total_craps = 10;
        current_max_craps = 30;
        
        Debug.Assert(_shit_starting_location, "_shit_starting_location needs to be asigned a gameobject");
        Debug.Assert(_shit_prefab, "_shit_prefab needs to be asigned a prefab");
    }


    public void shit()
    {
        if (!can_player_shit()) return;
            
       GameObject go = Instantiate(_shit_prefab, _shit_starting_location.transform);
       current_total_craps = current_total_craps - 1;
    }
    
    public bool can_player_shit()
    {
        return current_total_craps > 0;
    }
    
    
}