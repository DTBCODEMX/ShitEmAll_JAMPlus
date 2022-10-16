using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPlayerShitCount : MonoBehaviour
{
    private PlayerShitTaking _player_shit_counter_ref = null;
    private TextMeshProUGUI _tmpro;
    void Start()
    {
        _player_shit_counter_ref = GameObject.FindObjectOfType<PlayerShitTaking >();
        _tmpro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
       _tmpro.text = _player_shit_counter_ref.current_total_craps.ToString();
    }
}
