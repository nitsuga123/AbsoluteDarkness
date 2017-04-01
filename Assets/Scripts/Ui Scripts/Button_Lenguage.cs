using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Lenguage : MonoBehaviour
{
    public Sprite[] Source_image;
    public Sprite[] hightlighted;
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

        SpriteState Sprite_state = new SpriteState();
        Sprite_state.highlightedSprite = hightlighted[Static_Implements.Lenguage];

        Disable_Lenguage Disabled_lenguage = GetComponent<Disable_Lenguage>();
        if (Disabled_lenguage != null)
        {
            Sprite_state.disabledSprite = Disabled_lenguage.Disable_sprite[Static_Implements.Lenguage];
        }
        GetComponent<Button>().spriteState = Sprite_state;
    }
	
}
