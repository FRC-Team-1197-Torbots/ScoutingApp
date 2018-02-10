using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptions : MonoBehaviour {
    public GameObject OptionsMenu;
    public void OnClick()
    {
        OptionsMenu.SetActive(false);
    }
}
