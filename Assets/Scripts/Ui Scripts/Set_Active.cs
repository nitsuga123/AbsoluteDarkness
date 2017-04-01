using UnityEngine;
using System.Collections;

public class Set_Active : MonoBehaviour
{
    public GameObject[] To_active;
    public GameObject[] To_Disabled;

    public void Active_and_Disabled()
    {
        foreach (GameObject to_active in To_active)
        {
            to_active.SetActive(true);
        }
        foreach (GameObject to_disabled in To_Disabled)
        {
            to_disabled.SetActive(false);
        }
    }
}
