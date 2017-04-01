using UnityEngine;
using System.Collections;

public class Move_Reference : MonoBehaviour
{
    // Objetos
    GameObject Axis_x_reference;
    public float Axis_y_reference = 0f;
/*--------------------------------------------------------*/




    // Use this for initialization
	void Start ()
    {
        Axis_x_reference = GameObject.Find("Li");
	}	
	// Update is called once per frame
	void Update ()
    {
        // Comprobacion : Li - move
        if (Axis_x_reference != null)
        {
            transform.position = new Vector3(Axis_x_reference.transform.position.x, Axis_y_reference, -10f);
        }
        else
        {
            Axis_x_reference = GameObject.Find("Li");
        }
	}
}
