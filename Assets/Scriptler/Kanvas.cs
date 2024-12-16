using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Kanvas : MonoBehaviour
{
    TextMeshProUGUI para;
    TextMeshProUGUI skor;

    Button buton;

    private void OnEnable()
    {
        para = gameObject.transform.Find("Para").GetComponent<TextMeshProUGUI>();
        skor = gameObject.transform.Find("Skor").GetComponent<TextMeshProUGUI>();
        buton = gameObject.transform.Find("Button").GetComponent<Button>();
    }

    private void Update()
    {
        para.text = "Para: " + Oyuncu.para.ToString();
        skor.text = "Skor: " + Oyuncu.skor.ToString();
    }
}
