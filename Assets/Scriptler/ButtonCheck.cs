using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    Button tuş;

    public GameObject resim;

    private void Start()
    {
        tuş = gameObject.GetComponent<Button>();
    }

    public void ClickCheck()
    {
        if (Oyuncu.para >= KarakterStats.stats._ücret)
            SetActive();
    }

    public void SetActive()
    {
        resim.SetActive(true);
    }

}
