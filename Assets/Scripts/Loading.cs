﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(Static_Implements.Scene_direction);
	}
}
