using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions : MonoBehaviour {
    public GameObject OptionsMenu;
    public void OnClick()
    {
        OptionsMenu.SetActive(true);
    }
}
