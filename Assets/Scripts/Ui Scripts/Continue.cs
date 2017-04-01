using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public Sprite [] Not_Interactible;

    // Use this for initialization
    void Start()
    {
        string Saved_world = PlayerPrefs.GetString("World: ");
        if (Saved_world == "") 
        {
            GetComponent<Button>().interactable = false;
        }
    }
    public void Load_Continue()
    {
        // Desuscripcion
        Lenguage.Off_Event();

        string Saved_world = PlayerPrefs.GetString("World: ");
        Static_Implements.Scene_direction = Saved_world ;

        SceneManager.LoadScene("Loading");
    }
}
