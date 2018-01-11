using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTele : MonoBehaviour {

    public GameObject AutoPanel;
    public GameObject TelePanel;

    public void OnClick()
    {
        AutoPanel.SetActive(false);
        TelePanel.SetActive(true);
    }
}
