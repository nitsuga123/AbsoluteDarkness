using UnityEngine;
using System.Collections;

public class Enemy_life : MonoBehaviour
{
    public float life;
/*--------------------------------------------------------*/
    // Interruptores
    public bool Destructible_interruptor;
/*--------------------------------------------------------*/
    // Daño 
    public float Damage;
/*--------------------------------------------------------*/



    
    void Delay_destroy()
    {
        GameObject Li = GameObject.Find("Li");
        Destroy(Li);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Li")
        {
            Li_life.life -= 0.1f;
            if (Li_life.life <= 0)
            {
                Li_Move.Teclado_interruptor = true;
                Animator Li_animator = coll.gameObject.GetComponent<Animator>();
                Li_animator.SetBool("Muerte",true);
                Invoke("Delay_destroy", 2.7f);
            }
        }
    }
}
