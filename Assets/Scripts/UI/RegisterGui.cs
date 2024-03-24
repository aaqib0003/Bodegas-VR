using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterGui : MonoBehaviour
{
    public TMP_InputField docNumInputField;
    public Button submitBtn;

    [Header("Pantalla de confirmacion")]
    public TMP_Text docNumConfirm;
    public GameObject confirmationScreen;

    [Header("Player data")]
    public PlayerDataManager PlayerData;

    public void EnableSubmitBtn()
    {
        if (docNumInputField.text == null || docNumInputField.text == "")
        {
            submitBtn.interactable = false;
        }
        else
        {
            submitBtn.interactable = true;
        }
    }

    public void AddChar(string charToAdd)
    {
        docNumInputField.text += charToAdd;
    }

    public void DeleteLastChar()
    {
        docNumInputField.text = docNumInputField.text.Substring(0, docNumInputField.text.Length - 1);
    }

    public void ClearField()
    {
        docNumInputField.text = null;
    }

    public void ConfirmationScreen()
    {
        docNumConfirm.text = docNumInputField.text;
        confirmationScreen.SetActive(true);
    }

    public void SubmitDocNum()
    {
        PlayerData.Set_PlayerDocNum(docNumInputField.text);
    }
}
