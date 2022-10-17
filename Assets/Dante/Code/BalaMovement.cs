using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField, Range(0.5f, 20)] private float _speed = 2;

    private Vector3 _dir;
    
    public void Init(Vector3 dir, float speed = 2)
    {
        _dir = dir;
        _speed = speed;
    }
    
    
    void Update()
    {
        //Moverse logic
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hola");

        if (other.gameObject.name == "Pajaro")
        {

            Debug.Log("Choqu�");
            Destroy(gameObject);
            //gameover()


        }
        if (other.gameObject.name == "Ally")
        {
            Destroy(gameObject);
            VidaManager.instance._health -= 1;
        }
    }

}
