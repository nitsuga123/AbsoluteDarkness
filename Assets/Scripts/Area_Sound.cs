using UnityEngine;
using System.Collections;

public class Area_Sound : MonoBehaviour {

   // Radio de accion
   public float Radio;
/*--------------------------------------------------------*/
    // Coordenadas : X_1 < x_2
    float X_1;
    float X_2;
    /*--------------------------------------------------------*/



    // Use this for initialization
    void Start()
    {
        X_1 = transform.position.x - Radio;
        X_2 = transform.position.x + Radio;
    }
    void Update()
    {
        if (GameObject.Find("Li") != null)
        {
            if (GameObject.Find("Li").transform.position.x >= X_1 &&
               GameObject.Find("Li").transform.position.x <= X_2)
            {
                GetComponent<AudioSource>().volume = 0.25f;
            }
            else
                GetComponent<AudioSource>().volume = 0;
        }
    }
}
