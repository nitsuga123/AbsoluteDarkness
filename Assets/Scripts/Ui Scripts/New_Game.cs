using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{

    public GameObject [] To_active;
    public GameObject[] Interactable;

    
    public void Load_New_Game()
    {
        string Saved_world = PlayerPrefs.GetString("World: ");
        if (Saved_world != "")
        {
            foreach (GameObject interactable in Interactable)
            {
                interactable.GetComponent<Button>().interactable = false;
            }
            foreach (GameObject to_active in To_active)
            {
                to_active.SetActive(true);
            }
        }
        else
        {
            // Desuscripcion
            Lenguage.Off_Event();

            SceneManager.LoadScene("World_1");
        }
    }
    public void On_Intercatible()
    {
        foreach (GameObject interactable in Interactable)
        {
            interactable.GetComponent<Button>().interactable = true;
        }
    }
}
