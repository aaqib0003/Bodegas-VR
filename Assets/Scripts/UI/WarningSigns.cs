using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningSigns : MonoBehaviour
{
    public GameObject ShortInfoPanel;

    public void ToggleInfoPanel()
    {
        ShortInfoPanel.SetActive(!ShortInfoPanel.activeSelf);
    }
}
