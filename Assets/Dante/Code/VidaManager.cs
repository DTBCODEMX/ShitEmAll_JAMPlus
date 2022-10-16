using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaManager : MonoBehaviour
{
    [Range(0, 10)] public int _health = 10;

    public static VidaManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(_health,0.25f, 0);


        if (_health == 0)
        {
            //GameOver();

        }
        
    }
}
