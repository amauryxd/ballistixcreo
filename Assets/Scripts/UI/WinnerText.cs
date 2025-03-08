using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerText : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    void OnEnable()
    {
        GameManager.wichOneWin += ChangeTextFirst;
    }
    void OnDisable()
    {
        GameManager.wichOneWin -= ChangeTextFirst;
    }

    void ActivateCanva(){
        GetComponent<Canvas>().enabled = true;
    }
    void ChangeTextFirst(int plyNum){
        plyNum++;
        winnerText.text = "El ganador es el jugador "+plyNum;
        ActivateCanva();
    }
}
