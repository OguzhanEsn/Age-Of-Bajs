using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUpgradesUI : MonoBehaviour
{
    public Button swingShot;

    void Start()
    {
        swingShot.interactable = false;
    }

    void Update()
    {
        if (Oyuncu.para >= 150)
            if (!swingShot.IsInteractable())
                swingShot.interactable = true;
    }
}
