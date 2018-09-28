using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour {

    public void Quit()
    {
        Debug.Log("Has salido del juego");
        Application.Quit();
    }
    }
