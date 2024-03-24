using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluacionManager : MonoBehaviour
{
    //Numero de preguntas en el test
    public int questionAmount;

    //Banco de preguntas
    public GameObject[] questions;

    //Preguntas elegidas
    public GameObject[] chosenQuestions;

    //Punto de spawn de las preguntas
    public Transform questionSpawnPoint;

    //Boton Completar examen
    public GameObject finishTestBtn;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTest();
    }

    // Update is called once per frame
    void Update()
    {
        //Enable finish test button
        if (!finishTestBtn.activeInHierarchy)
        {
            finishTestBtn.SetActive(TestCompleted());
        }
    }

    //1. Generar test de 5 preguntas aleatorias
    public void GenerateTest()
    {
        //Elegir 5 preguntas
        for (int q = 0; q < questionAmount; q++)
        {
            int randIndex = Random.Range(0, questions.Length);
            if (!questions[randIndex].GetComponent<QuestionClass>().chosen)
            {
                questions[randIndex].GetComponent<QuestionClass>().chosen = true;
                chosenQuestions[q] = Instantiate(questions[randIndex], questionSpawnPoint);                
            } 
            
            else if (questions[randIndex].GetComponent<QuestionClass>().chosen)
            {
                int p = 0;

                while (questions[p].GetComponent<QuestionClass>().chosen)
                {
                    p++;
                    if (p >= questions.Length)
                    {
                        return;
                    }
                }

                questions[p].GetComponent<QuestionClass>().chosen = true;
                chosenQuestions[q] = Instantiate(questions[p], questionSpawnPoint);
            }

            chosenQuestions[q].GetComponent<QuestionClass>().Set_QuestionOrder(q + 1);
            chosenQuestions[q].SetActive(false); 
        }
    }

    //2. Hacer visible la primera pregunta
    public void EnableFirstQuestion()
    {
        chosenQuestions[0].SetActive(true);
    }

    public void NextQuestion()
    {
        int activeQuestionIndex = 0;

        for (int i = 0; i < chosenQuestions.Length; i++)
        {
            if (chosenQuestions[i].gameObject.activeInHierarchy)
            {
                activeQuestionIndex = i;
                break;
            }
        }

        chosenQuestions[activeQuestionIndex].SetActive(false);

        if ((activeQuestionIndex + 1) >= chosenQuestions.Length)
        {
            chosenQuestions[0].SetActive(true);
        }
        else if ((activeQuestionIndex + 1) < chosenQuestions.Length)
        {
            chosenQuestions[activeQuestionIndex + 1].SetActive(true);
        }
    }

    //3. Revisar si ya se contestaron la 5 preguntas
    public bool TestCompleted()
    {
        foreach (var question in chosenQuestions)
        {
            if (!question.GetComponent<QuestionClass>().answered)
            {
                return false;
            }
        }

        return true;
    }
}
