using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterStats : MonoBehaviour
{

    public int _ücret;

    public int _bekle;

    public static KarakterStats stats = null;

    //public GameObject[] objeler;

    private void Awake()
    {
        if(stats == null)
        {
            stats = GameObject.FindGameObjectWithTag("KS").GetComponent<KarakterStats>();
        }

    }

    public void SetPrice(int _price)
    {
         _ücret = _price;
    }
    public void SetTimer(int _timer)
    {
         _bekle = _timer;       
    }
}
