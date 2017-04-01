using UnityEngine;
using System.Collections;

public class Platform_Lvl_Camera : MonoBehaviour
{
 
    // Componentes de este objeto
    Move_Reference Move_referencia;
/*--------------------------------------------------------*/
    // posicion
    public int Final_camera_position;
/*--------------------------------------------------------*/
    // velocidad
    float Camera_Velocity;
/*--------------------------------------------------------*/
    // Interruptores
    bool Camera_move_interruptor;
/*--------------------------------------------------------*/
    // contadores
    int contador;
/*--------------------------------------------------------*/



    // Use this for initialization
    void Start()
    {
        Move_referencia = Camera.main.GetComponent<Move_Reference>();
    }
    void Update()
    {
        if (Camera_move_interruptor)
        {
            if(contador < 15)
            {
                Move_referencia.Axis_y_reference += Camera_Velocity;
                contador ++;
            }
        }
        if (contador == (15 - 1))
        {
            contador = 0;

            Camera_move_interruptor = false;

            // corrector de la posicion
            if (Move_referencia.Axis_y_reference != Final_camera_position)
            {
                Move_referencia.Axis_y_reference = Final_camera_position;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (Move_referencia.Axis_y_reference != Final_camera_position)
        {

            Camera_Velocity = (Final_camera_position - Move_referencia.Axis_y_reference)/15;

            Camera_move_interruptor = true;
        }
    }
}
