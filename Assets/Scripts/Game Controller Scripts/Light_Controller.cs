using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Light_Controller : MonoBehaviour
{
    // Interruptores
    public static bool Lights_interruptor ;
/*--------------------------------------------------------*/
    //objetos
    public GameObject Light;
/*--------------------------------------------------------*/
    // textos
    public Text Light_counter;
/*--------------------------------------------------------*/
    // Ray
    private Ray Pulsacion;
/*--------------------------------------------------------*/
    // luces: variable constante por nivel
    public int Lvl_lights;
    public string Lights {get; set;}




    // Use this for initialization
    void Start()
    {
        Lights_interruptor = false;

        Lights = Lvl_lights.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        Light_counter.text = Lvl_lights.ToString() + "/" + Lights;

        if (Lights_interruptor == false)
        {
            if (Input.GetMouseButtonDown(0) && Lvl_lights > 0)
            {
                Pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Comprobacion: Unlighted
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 position = new Vector3(Pulsacion.origin.x, Pulsacion.origin.y, -1f);
                    Instantiate(Light, position, transform.rotation);
                    Lvl_lights--;
                }             
            }
        }
	}
}
