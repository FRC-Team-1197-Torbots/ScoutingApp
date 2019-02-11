using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class FirstTimeConfig : MonoBehaviour
{
    public GameObject ObjPanel;
    public GameObject VibrateUI;
    public GameObject VibrateUI1;
    public GameObject VibrateUI2;
    public GameObject VibrateUI3;
    public GameObject VibrateUI4;
    public GameObject VibrateUI5;

    bool playerIndexSet = false;
    PlayerIndex playerIndex0 = (PlayerIndex)0;
    PlayerIndex playerIndex1 = (PlayerIndex)1;
    PlayerIndex playerIndex2 = (PlayerIndex)2;
    PlayerIndex playerIndex3 = (PlayerIndex)3;
    PlayerIndex playerIndex4 = (PlayerIndex)4;
    PlayerIndex playerIndex5 = (PlayerIndex)5;
    GamePadState state;
    GamePadState prevState;

    public void OpenPanel()
    {
        ObjPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        ObjPanel.SetActive(false);
    }

    public void FullDiagnostic()
    {
        StartCoroutine(FullVibrate(1));
    }

    public void Vibrate(int Num)
    {
        Debug.Log("Controller #" + Num + " Shall Now Vibrate");
        StartCoroutine(SingleVibrate(Num));
    } 
    public IEnumerator SingleVibrate(int Num)
    {
        if (Num == 1) {      VibrateUI.SetActive(true);  GamePad.SetVibration(playerIndex0, 1, 1); }
        else if (Num == 2) { VibrateUI1.SetActive(true); GamePad.SetVibration(playerIndex1, 1, 1); }
        else if (Num == 3) { VibrateUI2.SetActive(true); GamePad.SetVibration(playerIndex2, 1, 1); }
        else if (Num == 4) { VibrateUI3.SetActive(true); GamePad.SetVibration(playerIndex3, 1, 1); }
        else if (Num == 5) { VibrateUI4.SetActive(true); GamePad.SetVibration(playerIndex4, 1, 1); }
        else if (Num == 6) { VibrateUI5.SetActive(true); GamePad.SetVibration(playerIndex5, 1, 1); }
        yield return new WaitForSeconds(4);
        if (Num == 1) {      VibrateUI.SetActive(false);  GamePad.SetVibration(playerIndex0, 0, 0); }
        else if (Num == 2) { VibrateUI1.SetActive(false); GamePad.SetVibration(playerIndex1, 0, 0); }
        else if (Num == 3) { VibrateUI2.SetActive(false); GamePad.SetVibration(playerIndex2, 0, 0); }
        else if (Num == 4) { VibrateUI3.SetActive(false); GamePad.SetVibration(playerIndex3, 0, 0); }
        else if (Num == 5) { VibrateUI4.SetActive(false); GamePad.SetVibration(playerIndex4, 0, 0); }
        else if (Num == 6) { VibrateUI5.SetActive(false); GamePad.SetVibration(playerIndex5, 0, 0); }
    }


    public IEnumerator FullVibrate(int Num)
    {
        Debug.Log("Controller #" + Num + " Shall Now Vibrate");
        if (Num == 1) {      VibrateUI.SetActive(true);  GamePad.SetVibration(playerIndex0, 1, 1); }
        else if (Num == 2) { VibrateUI1.SetActive(true); GamePad.SetVibration(playerIndex1, 1, 1); }
        else if (Num == 3) { VibrateUI2.SetActive(true); GamePad.SetVibration(playerIndex2, 1, 1); }
        else if (Num == 4) { VibrateUI3.SetActive(true); GamePad.SetVibration(playerIndex3, 1, 1); }
        else if (Num == 5) { VibrateUI4.SetActive(true); GamePad.SetVibration(playerIndex4, 1, 1); }
        else if (Num == 6) { VibrateUI5.SetActive(true); GamePad.SetVibration(playerIndex5, 1, 1); }
        yield return new WaitForSeconds(4);
        if (Num == 1) {      VibrateUI.SetActive(false);  GamePad.SetVibration(playerIndex0, 0, 0); }
        else if (Num == 2) { VibrateUI1.SetActive(false); GamePad.SetVibration(playerIndex1, 0, 0); }
        else if (Num == 3) { VibrateUI2.SetActive(false); GamePad.SetVibration(playerIndex2, 0, 0); }
        else if (Num == 4) { VibrateUI3.SetActive(false); GamePad.SetVibration(playerIndex3, 0, 0); }
        else if (Num == 5) { VibrateUI4.SetActive(false); GamePad.SetVibration(playerIndex4, 0, 0); }
        else if (Num == 6) { VibrateUI5.SetActive(false); GamePad.SetVibration(playerIndex5, 0, 0); }
        if (Num < 6)
        {
            StartCoroutine(FullVibrate(Num + 1));
        }   
    }
}
