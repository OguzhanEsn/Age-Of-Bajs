using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Oyuncu : MonoBehaviour
{
    public TextMeshProUGUI paraText;
    public TextMeshProUGUI skorText;

    public static int para = 0;
    public static int skor;

    public GameObject buton;

    private void Start()
    {
        buton.SetActive(false);

        StartCoroutine("Ekle");
        StartCoroutine("SkorEkle");
    }

    void Update()
    {
        paraText.text = "Para: " + para.ToString();

        skorText.text = "Skor: " + skor.ToString();

        if (skor >= 100)
            if (!buton.activeSelf)
                buton.SetActive(true);
    }

    IEnumerator SkorEkle()
    {
        skor += 50;
        yield return new WaitForSeconds(2f);
        StartCoroutine("SkorEkle");
    }

    IEnumerator Ekle()
    {
        para += 1;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("Ekle");
    }
}
