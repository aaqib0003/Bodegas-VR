
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swiitch : MonoBehaviour
{
   
    public GameObject[] background;
    public int index;

    void Start()
    {
        index = 0;
    }
    
    public void DisplayCurrent(int current)
    {
        foreach (var item in background)
        {
            item.gameObject.SetActive(false);
        }

        background[current].gameObject.SetActive(true);
    }

    public void BtnNext()
    {
        index++;
        if (index >= background.Length)
            index = 0;
        DisplayCurrent(index);
    }

    public void BtnPrev()
    {
        index--;
        if (index < 0)
            index = background.Length - 1;
        DisplayCurrent(index);
    }   
}