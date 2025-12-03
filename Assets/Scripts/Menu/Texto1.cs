using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class Texto1 : MonoBehaviour
{
    string frase = @"En una sala de terapia tranquila, Aria se sienta frente a la terapeuta etérea. Tras años silenciando su voz interior, su mente está fragmentada y un enemigo invisible domina sus emociones. En este primer encuentro, la terapeuta la guía para comenzar a recuperar su identidad y sanar";
    public  TextMeshProUGUI texto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(reloj());
    }   

    IEnumerator reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.04f);
        }
        
    }
}
