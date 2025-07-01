using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBtn : MonoBehaviour
{
    public GameObject VolumePanel;
    public void enterPanel()
    {
        VolumePanel.SetActive(true);
    }
    public void exitPanel()
    {
        VolumePanel.SetActive(false);
    }
}
