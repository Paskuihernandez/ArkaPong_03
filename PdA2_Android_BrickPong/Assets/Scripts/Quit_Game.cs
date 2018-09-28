using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Skip : MonoBehaviour {

    public void doquit()
    {
        Debug.Log("Has quitado el juego");
        Application.Quit();
    }
    }
