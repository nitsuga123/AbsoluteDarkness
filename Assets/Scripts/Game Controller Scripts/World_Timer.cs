using UnityEngine;
using System.Collections;

public class World_Timer : MonoBehaviour
{
    public string World;




	// Use this for initialization
	void Awake ()
    {
        if (World != "")
        {
            // Punto de Guardado
            PlayerPrefs.SetString("World: ",World);
        }
        else
            Debug.Log("error: 0_reference");
	}
	
}
