using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionClass : MonoBehaviour
{
    //Objeto que almacena los datos del jugador
    public PlayerDataManager PlayerData;

    // Para saber si la pregunta ya fue elegida en este test
    public bool chosen;

    //Para saber si esta pregunta ya se respondio o no
    public bool answered;

    //Orden de la pregunta dentro del test
    public int questionOrder;
    public TMP_Text questionOrderDisplay;

    //Sprites para mostrar la respuesta correcta y las erroneas
    public Sprite correctAnswerSprt, wrongAnswerSprt;


    //Opciones de respuesta dentro de la pregunta
    public Button  correctAnswer;
    public Button[] wrongAnswer;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("PLAYER_MANAGER").GetComponent<PlayerDataManager>();
    }

    public void Set_QuestionAnswered(bool newBool)
    {
        answered = newBool;
    }

    public void Set_QuestionOrder(int newOrder)
    {
        questionOrder = newOrder;
        questionOrderDisplay.text = questionOrder.ToString() + ".";
    }

    public void ClickOnAnswer()
    {
        foreach (var answ in wrongAnswer)
        {
            answ.GetComponent<Image>().sprite = wrongAnswerSprt;
            answ.interactable = false;
        }

        correctAnswer.GetComponent<Image>().sprite = correctAnswerSprt;
        correctAnswer.interactable = false;

        answered = true;
    }

    public void Correct_AddToTestScore(int scoreToAdd)
    {
        PlayerData.TestScore += scoreToAdd;
    }
}
