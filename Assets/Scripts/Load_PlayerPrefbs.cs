using UnityEngine;
using System.Collections;

public class Load_PlayerPrefbs : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        if (PlayerPrefs.HasKey("Lenguage: "))
            Static_Implements.Lenguage = PlayerPrefs.GetInt("Lenguage: ");
	}

}
