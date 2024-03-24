using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class FinalScoreGui : MonoBehaviour
{
    //Pantalla de puntaje final en el examen.
    public GameObject testCompletedGui;

    //Texto que muestra el puntaje final
    public TMP_Text finalScoreDisplay;

    //Objeto que almacena los datos del jugador
    public PlayerDataManager PlayerData;
    public PlayerTestScore CurrentPlayerTestScore;

    //Ruta donde se guarda el archivo
    private string SavePath;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("PLAYER_MANAGER").GetComponent<PlayerDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Click en finalizar examen
    public void FinishTest()
    {
        finalScoreDisplay.text = PlayerData.TestScore.ToString();
        testCompletedGui.SetActive(true);

        //Para guardar datos del jugador
        //1. Crear ruta donde se guarda el archivo
        string playerDoc = PlayerData.PlayerDocNum.ToString();
        SavePath = Application.persistentDataPath + "/" + playerDoc + "_" + System.DateTime.Now.ToString("dd'-'MM'-'yyyy'_'HH'h'mm'm'") + ".json";

        //2. Convertir Player Data Manager (GameObject) a Player Test Score (Struct)
        PlayerTestScore CurrentPlayerTestScore = new PlayerTestScore();
        CurrentPlayerTestScore.Date = System.DateTime.Now.ToString();
        CurrentPlayerTestScore.DocNum = PlayerData.PlayerDocNum.ToString();
        CurrentPlayerTestScore.TestScore = PlayerData.TestScore.ToString();

        //3. Guardar a archivo
        Debug.Log("Guardando archivo en " + SavePath);
        SavePlayerScore(CurrentPlayerTestScore);

    }

    //Guardar puntaje del jugador en un archivo json
    public void SavePlayerScore(PlayerTestScore newPlayerTestScore)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(newPlayerTestScore, true);
            stream.Write(json);
        }
    }

    //Salir
    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
