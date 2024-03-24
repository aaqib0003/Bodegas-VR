using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*Para llevar el control de que niveles ya completo el jugador*/
    public void LevelCompleted(string PlayerPrefName)
    {
        if (!PlayerPrefs.HasKey(PlayerPrefName))
        {
            PlayerPrefs.SetInt(PlayerPrefName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(PlayerPrefName, PlayerPrefs.GetInt(PlayerPrefName) + 1);
        }
    }
}
