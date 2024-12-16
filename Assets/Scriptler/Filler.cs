using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Filler : MonoBehaviour
{
    Image resim;

    float kalanZaman;

    void Start()
    {

    }

    private void OnEnable()
    {
        kalanZaman = KarakterStats.stats._bekle;
        resim = gameObject.GetComponent<Image>();
        resim.color = Color.green;
        resim.fillAmount = KarakterStats.stats._bekle;
    }

    void Update()
    {
        if(Oyuncu.para >= KarakterStats.stats._ücret)
        {
            if (kalanZaman > 0)
            {
                kalanZaman -= Time.deltaTime;
                resim.fillAmount = kalanZaman / KarakterStats.stats._bekle;
            }
        }

    }
}
