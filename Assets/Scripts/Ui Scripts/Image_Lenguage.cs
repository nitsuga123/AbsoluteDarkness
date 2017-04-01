using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image_Lenguage : MonoBehaviour
{
    public Sprite[] Source_image;
/*--------------------------------------------------------*/
    // Objetos
    public bool Lenguage_button;
/*--------------------------------------------------------*/




    // Use this for initialization
    void Awake ()
    {
        if (Lenguage_button)
        {
            Lenguage.Change_lenguage += Change_lenguage_manager;
        }

        Change_lenguage_manager();
    }
    public void Change_lenguage_manager()
    {
        Image Image = this.GetComponent<Image>();

        Image.sprite = Source_image[Static_Implements.Lenguage];
    }
}
