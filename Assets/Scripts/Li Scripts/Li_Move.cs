using UnityEngine;
using System.Collections;

public class Li_Move : MonoBehaviour
{

    // Interruptores
    public static bool Teclado_interruptor;
    bool Trigger_interruptor = false;
    bool Ground_Check;
    bool Salto_interruptor;
    bool Recuperacion_interruptor;
/*--------------------------------------------------------*/
    // Objetos
    public GameObject Ground_validator;
/*--------------------------------------------------------*/
    // Componentes de este objeto
    Animator Animator;
    Rigidbody2D Rigibody_2D;
    SpriteRenderer Sprite_renderer;
/*--------------------------------------------------------*/
    // Variables mesurables
    public float Fall_Validator;
    public float velocity_strength;
    public float Jump_strength;
    float Radio_validator = 0.25f;
    float Y_inicial;
/*--------------------------------------------------------*/
    // variables del tiempo
    float Check_trigger_time;
    public float Delay_time;
    float Check_recuperacion_time;
    float Delay_recuperacion_time = 0.5f;
/*--------------------------------------------------------*/
    // Layers
    public LayerMask Ground_layer;
/*--------------------------------------------------------*/




    // Use this for initialization
    void Start ()
    {
        Teclado_interruptor = false;

        Animator = GetComponent<Animator>();
        Rigibody_2D = GetComponent<Rigidbody2D>();
        Sprite_renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ground_Check = Physics2D.OverlapCircle(Ground_validator.transform.position,Radio_validator,Ground_layer);

        if (Teclado_interruptor == false)
        {
            if (Input.GetKey(KeyCode.W) && Ground_Check)
            { 
                Rigibody_2D.velocity = new Vector2(0f, Jump_strength);
            }
            if (Input.GetKey(KeyCode.D))
            {
                // Animacion: Salto_Recuperacion -> Off
                Animation_check("Salto_Recuperacion");

                Sprite_renderer.flipX = false;
                // Animacion: Marcha -> On
                Animator.SetBool("Marcha", true);
                transform.Translate(new Vector2(velocity_strength, 0f) * Time.deltaTime);
                // Correcion: Circle collider Offset 
                GetComponent<CircleCollider2D>().offset = new Vector2(0.1f, -0.125f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                // Animacion: Salto_Recuperacion -> Off
                Animation_check("Salto_Recuperacion");

                Sprite_renderer.flipX = true;
                // Animacion: Marcha -> On
                Animator.SetBool("Marcha", true);
                transform.Translate(new Vector2(-velocity_strength, 0f) * Time.deltaTime);
                // Correcion: Circle collider Offset 
                GetComponent<CircleCollider2D>().offset = new Vector2(-0.1f, -0.125f);
            }
        }
        if (Teclado_interruptor ||
            Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true)
        {
            if (Time.time > Check_recuperacion_time && Recuperacion_interruptor)
            {
                Recuperacion_interruptor = false;
                Animator.SetBool("Salto_Recuperacion",false);
            }
            // Animacion: Marcha -> Off
            Animator.SetBool("Marcha", false);
            // Correcion: Circle collider Offset 
            GetComponent<CircleCollider2D>().offset = new Vector2(0f,-0.125f);
        }
    }
    void Update()
    {
        if (Trigger_interruptor)
        {
            if (Time.time >= Check_trigger_time)
            {              
                // Animacion: Daño -> Off
                Animator.SetBool("Daño", false);
                GetComponent<CircleCollider2D>().isTrigger = false;
                // Modo trigger descativado
                Trigger_interruptor = false;
                // Teclado activado
                Teclado_interruptor = false;
            }
        }

        if (Ground_Check == false)
        {
            Salto_interruptor = true;
            // Comprobacion Salto/Caida
            if ((gameObject.transform.position.y - Y_inicial) > 0)
            {
                // Animacion: Salto_Recuperacion -> Off
                Animation_check("Salto_Recuperacion");

                // Animacion: Salto_Up -> On
                Animator.SetBool("Salto_Up", true);
            }
            if ((gameObject.transform.position.y - Y_inicial) < 0)
            {
                // Animacion: Salto_Up -> Off
                Animator.SetBool("Salto_Up", false);
                // Animacion: Salto_Down -> On
                Animator.SetBool("Salto_Down", true);
            }
        }
        if (Ground_Check && Salto_interruptor)
        {
            if (Animator.GetBool("Salto_Down"))
            {
                Salto_interruptor = false;
                // Animacion: Salto_Recuperacion -> On
                Animator.SetBool("Salto_Recuperacion", true);

                // actualizacion del tiempo: tiempo de recuperacion tras quedarse quieto 
                Check_recuperacion_time = Time.time + Delay_recuperacion_time;
                Recuperacion_interruptor = true;

                // Animacion: Salto_Down -> Off
                Animator.SetBool("Salto_Down", false);
            }
            else
                Animator.SetBool("Salto_Up", false);
        }
   
        Y_inicial = gameObject.transform.position.y;
/*--------------------------------------------------------*/
        // Muerte por caida
        if (transform.position.y <= Fall_Validator)
        {
            Destroy(gameObject);
        }
/*--------------------------------------------------------*/
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemigo" && Li_life.life > 0.09)
        {
            // Animacion : Daño -> On
            Animator.SetBool("Daño", true);
            
            // Teclado_desactivado
            Teclado_interruptor = true;

            if (gameObject.transform.position.x < coll.transform.position.x)
                Rigibody_2D.velocity = new Vector3(-1.5f, 2.5f, 0f);
            if (gameObject.transform.position.x > coll.transform.position.x)
                Rigibody_2D.velocity = new Vector3(1.5f, 2.5f, 0f);

            // personaje intangible
            GetComponent<CircleCollider2D>().isTrigger = true;
            // Modo trigger activado
            Trigger_interruptor = true;
            // actualizando el tiempo : para cerrar el ciclo
            Check_trigger_time = Time.time + Delay_time;
        }
    }
    public void Animation_check(string animation)
    {
        if (Animator.GetBool(animation))
        {
            Animator.SetBool(animation, false);
        }
    }
    //End
}
