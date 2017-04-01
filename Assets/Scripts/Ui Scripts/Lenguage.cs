using UnityEngine;
using System.Collections;

public delegate void Change_Lenguage();

public class Lenguage : MonoBehaviour
{

    public static event Change_Lenguage Change_lenguage;

    public void On_Event_Change_lenguage(int Lenguage)
    {
        Static_Implements.Lenguage = Lenguage;

        PlayerPrefs.SetInt("Lenguage: ", Lenguage);

        Change_lenguage();
    }
    public static void Off_Event()
    {
        Change_lenguage = null;
    }
}
