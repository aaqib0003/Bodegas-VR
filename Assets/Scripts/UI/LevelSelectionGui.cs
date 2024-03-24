using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KetosGames.SceneTransition;

public class LevelSelectionGui : MonoBehaviour
{
    public GameObject WarningCD, WarningEvaluacion;

    public void CrossDockingCheck(string SceneName)
    {
        if (PlayerPrefs.GetInt("BODEGA_COMPLETED") > 0)
        {
            SceneLoader.LoadScene(SceneName);
        }
        else if (!PlayerPrefs.HasKey("BODEGA_COMPLETED") || PlayerPrefs.GetInt("BODEGA_COMPLETED") <= 0)
        {
            WarningCD.SetActive(true);
        }
    }

    public void EvaluacionCheck(string SceneName)
    {
        if (PlayerPrefs.GetInt("BODEGA_COMPLETED") > 0 && PlayerPrefs.GetInt("CROSS_COMPLETED") > 0)
        {
            SceneLoader.LoadScene(SceneName);
        } else
        {
            WarningEvaluacion.SetActive(true);
        }
    }
}
