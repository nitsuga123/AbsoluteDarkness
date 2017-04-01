using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Paused : MonoBehaviour 
{
	public GameObject Pause_Menu;
/*--------------------------------------------------------*/
    // Objetos
    public Button Pause_Button;
/*--------------------------------------------------------*/



    public void On_Pause()
	{
        /* Inhabilitando:
        Luz
        Teclado
        Boton de pausa
        */
        Light_Controller.Lights_interruptor = true;

        Li_Move.Teclado_interruptor = true;     

        Pause_Button.GetComponent<Button>().interactable = false;
        // Tiempo : off
        Time.timeScale = 0;

        //Activando: Menu
        Pause_Menu.SetActive(true); 
	}
    public void Off_Pause()
    {
        /* habilitando:
        Luz
        Teclado
        Boton de pausa
        */
        Li_Move.Teclado_interruptor = false;

        Light_Controller.Lights_interruptor = false;

        Pause_Button.GetComponent<Button>().interactable = true;
        // Tiempo : off
        Time.timeScale = 1;

        //Activando: Menu
        Pause_Menu.SetActive(false);
    }
}
