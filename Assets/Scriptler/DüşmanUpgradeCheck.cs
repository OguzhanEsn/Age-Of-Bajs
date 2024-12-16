using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DüşmanUpgradeCheck : MonoBehaviour
{
    public static int upgradeIndex = 0;

    public GameObject[] upgrades;

    public static List<int> ücretler = new List<int>()
    {
        120,
        200,
    };

    void Update()
    {
        if (upgrades[upgradeIndex] != null)
        {
            if (AISpawner.saveForUpgrade && Düşman.para >= ücretler[upgradeIndex])
                if (!upgrades[upgradeIndex].activeSelf)
                {
                    upgrades[upgradeIndex].SetActive(true);
                    NextUpgrade();
                }
        }
        else
            return;
    }


    public void NextUpgrade()
    {
        AISpawner.saveForUpgrade = false;
        Düşman.para -= ücretler[upgradeIndex];
        upgradeIndex++;
    }
}
