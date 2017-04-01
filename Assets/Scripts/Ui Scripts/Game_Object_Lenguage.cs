using UnityEngine;
using System.Collections;

public class Game_Object_Lenguage : MonoBehaviour
{
    public GameObject[] Gameobject_to_instantiate;

    // Use this for initialization
    void Start()
    {
        Instantiate(Gameobject_to_instantiate[Static_Implements.Lenguage], gameObject.transform.position, gameObject.transform.rotation);
    }

}
