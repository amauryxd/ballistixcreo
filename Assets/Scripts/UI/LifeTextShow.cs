using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeTextShow : MonoBehaviour
{
    public TextMeshProUGUI[] textLifePlys;
    void OnEnable()
    {
        GameManager.lifeChange += ActualizarVida;
    }

    void OnDisable()
    {
        GameManager.lifeChange -= ActualizarVida;
    }
    void Start()
    {
        for(int indexText = 0; indexText < textLifePlys.Length; indexText++){
            textLifePlys[indexText].text = GameManager.Instance.vidaPlys[indexText].ToString();
        }
    }

     void ActualizarVida(int wichPly){
        textLifePlys[wichPly-1].text = GameManager.Instance.vidaPlys[wichPly-1].ToString();
    }
}
