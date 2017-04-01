using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Li_life : MonoBehaviour
{
    public static float life;
/*--------------------------------------------------------*/
    // Healt bar
    public Scrollbar Healt_bar;
/*--------------------------------------------------------*/

    // Update is called once per frame
    void Awake()
    {
        life = 1;
    }
	void Update ()
    {
        Healt_bar.size = life;
	}
}
