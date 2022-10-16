using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaManager : MonoBehaviour
{
    public int _health = 10;

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
        transform.localScale = new Vector3(0.25f,_health, 0);
  

        if (_health == 0)
        {
            //GameOver();

        }
        
    }
}
