using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //1. Declaración de variables
    public float velocidad; //Velocidad del jugador
    Rigidbody2D rb2d;
    SpriteRenderer spRd;
    
    void Start()
    {

        //2. Capturo y asocio los componentes Rigidbody2D y Sprite Renderer del Jugador
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {

        


        //3. Movimiento horizontal
        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidad, rb2d.velocity.y);

        //4. Sentido horizontal (para girar el render del jugador)
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }


        //3. Movimiento horizontal
        float movimientoV = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector2(movimientoV * velocidad, rb2d.velocity.x);

        //4. Sentido horizontal (para girar el render del jugador)
        if (movimientoV > 0)
        {
            spRd.flipY = false;
        }
        else if (movimientoV < 0)
        {
            spRd.flipY = false;
        }

    }

   
}