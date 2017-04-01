using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    //Objects
    public GameObject Li_prefab;
/*--------------------------------------------------------*/
    // Componentes de este objeto
    Light_Controller Light_controller;
/*--------------------------------------------------------*/


    // Use this for initialization
    void Start()
    {
        Light_controller = GetComponent<Light_Controller>();
    }
    // Update is called once per frame
    void Update ()
    {
        // comprobando : Li
        if (GameObject.Find("Li") == null)
        {
            GameObject[] Light_list = GameObject.FindGameObjectsWithTag("Light");
            foreach (GameObject light in Light_list)
            {
                Destroy(light);
            }
            // instanciado: Li
            GameObject Li = Instantiate(Li_prefab, transform.position, transform.rotation) as GameObject;
            Li.name = "Li";
            Li.GetComponent<Li_life>().Healt_bar = (Scrollbar)FindObjectOfType(typeof(Scrollbar));
            Li_life.life = 1;

            // Reiniciando el contador de luces
            Light_controller.Lvl_lights =  int.Parse(Light_controller.Lights);

        }
	
	}
}
