using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public void Load(string Scene_direction)
    {
        // Desuscripcion
        Lenguage.Off_Event();

        Static_Implements.Scene_direction = Scene_direction;

        // Comprobando : Game_Paused
        Pause_Is_True();

        SceneManager.LoadScene("Loading");
    }
    public void Load_Direct_Scene(string Scene_direction)
    {
        // Desuscripcion
        Lenguage.Off_Event();

        // Comprobando : Game_Paused
        Pause_Is_True();

        SceneManager.LoadScene(Scene_direction);
    }

    public void Pause_Is_True()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
