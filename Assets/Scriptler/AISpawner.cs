using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public int firstThreshold = 20;
    public int secondThreshold = 40;
    public int thirdThreshold = 60;

    public int beyazFiyat = 20;
    public int yeşilFiyat = 40;
    public int kırmızıFiyat = 60;

    public int beyazBekle = 2;
    public int yeşilBekle = 3;
    public int kırmızıBekle = 4;

    public bool isSpawning = false;

    public Transform _pos;

    public GameObject beyaz;
    public GameObject yeşil;
    public GameObject kırmızı;

    public bool shouldCall = true;

    public static bool saveForUpgrade;


    void Update()
    {
        if ((Düşman.para == firstThreshold || Düşman.para == secondThreshold || Düşman.para >= thirdThreshold) && !isSpawning && saveForUpgrade == false)
            ReturnValues();

    }

    void ReturnValues()
    {
        if (Düşman.para >= firstThreshold && Düşman.para < secondThreshold)
        {
            shouldCall = true;
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                Spawn(beyazFiyat, beyazBekle, beyaz);
                shouldCall = false;
            }
            else
                shouldCall = false;
        }
        else if (Düşman.para >= secondThreshold && Düşman.para < thirdThreshold)
        {
            shouldCall = true;
            int rand = Random.Range(1, 4);
            if (rand == 1)
            {
                Spawn(yeşilFiyat, yeşilBekle, yeşil);
                shouldCall = false;
            }
            else if (rand == 2)
            {
                Spawn(beyazFiyat, beyazBekle, beyaz);
                shouldCall = false;
            }
            else
                shouldCall = false;
        }
        else if (Düşman.para >= thirdThreshold)
        {
            shouldCall = true;
            int rand = Random.Range(1, 6);
            if (rand == 1)
            {
                Spawn(kırmızıFiyat, kırmızıBekle, kırmızı);
                shouldCall = false;
            }
            else if (rand == 2)
            {
                Spawn(yeşilFiyat, yeşilBekle, yeşil);
                shouldCall = false;
            }
            else if (rand == 3)
            {
                Spawn(beyazFiyat, beyazBekle, beyaz);
                shouldCall = false;
            }
            else if (rand == 4)
            {
                Spawn(kırmızıFiyat, kırmızıBekle, kırmızı);
                shouldCall = false;
            }
            /* else if (rand == 5)
            {
                Spawn(beyazFiyat, beyazBekle, beyaz);
                shouldCall = false;
            }
            else if (rand == 6)
            {
                Spawn(kırmızıFiyat, kırmızıBekle, kırmızı);
                shouldCall = false;
            }
            */
            else
            {
                //  saveForUpgrade = true;
                shouldCall = false; 
            }
                
        }
        if(Düşman.para >= DüşmanUpgradeCheck.ücretler[DüşmanUpgradeCheck.upgradeIndex] && DüşmanUpgradeCheck.upgradeIndex <= DüşmanUpgradeCheck.ücretler.Count)
        {
            saveForUpgrade = true;
        }
    } 

    IEnumerator SpawnEnemy(int _ücret, float _zaman, GameObject _go)
    {
        if(!isSpawning && shouldCall && !saveForUpgrade)
        {
            Düşman.para -= _ücret;
            isSpawning = true;
            yield return new WaitForSeconds(_zaman);
            GameObject go = Instantiate(_go, _pos);
            go.transform.parent = null;
            isSpawning = false;
        }       
    }

    public void Spawn(int _ücret, float _zaman, GameObject _go)
    {
        isSpawning = false; 
        StartCoroutine(SpawnEnemy(_ücret, _zaman, _go));
        isSpawning = true;
    }
}
