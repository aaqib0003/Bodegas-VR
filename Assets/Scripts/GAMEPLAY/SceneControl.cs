using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KetosGames.SceneTransition;

public class SceneControl : MonoBehaviour
{
    public void LoadSceneAsync(string sceneName)
    {
        SceneLoader.LoadScene(sceneName);
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    //Salir
    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
