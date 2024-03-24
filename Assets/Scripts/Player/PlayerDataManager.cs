using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public string PlayerDocNum;

    public int TestScore;

    public void Set_PlayerDocNum(string newDocNum)
    {
        PlayerDocNum = newDocNum;
    }
}
