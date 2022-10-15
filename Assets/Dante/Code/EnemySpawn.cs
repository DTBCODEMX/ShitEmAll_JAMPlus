using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] 
    private EnemyBehaviour _enemySpawn;

    [SerializeField] private Transform[] _spawns;
    
    private void Start()
    {
       
    }
}
