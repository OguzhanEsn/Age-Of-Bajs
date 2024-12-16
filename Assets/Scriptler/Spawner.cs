using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform _pos;

    public bool isSpawning;

    public bool sırada;

    public int sıraIndex = 0;


    private void Update()
    {
       // Debug.Log(sırada);
       // Debug.Log(isSpawning);
       // Debug.Log(sıra.Count);
    }

    IEnumerator Spawn(int _ücret, int _zaman, GameObject _obje)
    {

        if (Oyuncu.para >= _ücret && !isSpawning && !sırada)
        {
            Oyuncu.para -= _ücret;
            isSpawning = true;
            yield return new WaitForSeconds(_zaman);
            GameObject go = Instantiate(_obje, _pos);
            isSpawning = false;
        }
        else if (Oyuncu.para >= _ücret && isSpawning)
        {
            AddtotheQueue(_obje);
            Oyuncu.para -= _ücret;           
        }

        if (!isSpawning && sıra.Count > 0)
        {
            Debug.Log("Spawning from queue");
            isSpawning = true;
            yield return new WaitForSeconds(_zaman);
            GameObject go = Instantiate(sıra[sıraIndex], _pos);
            sıra.Remove(sıra[sıraIndex]);
            isSpawning = false;

            Yarat(_obje);
        }

        if (sıra.Count <= 0)
            sırada = false;


    }

    [HideInInspector]
    public List<GameObject> sıra = new List<GameObject>()
    {

    };



    public void AddtotheQueue(GameObject go)
    {
        sıra.Add(go);
        if (sıra.Count > 0 )
        {
            sırada = true;
        }
        else
        {
            sırada = false;
        }
            
    }

    public void Yarat(GameObject _go)
    {
        StartCoroutine(Spawn(KarakterStats.stats._ücret, KarakterStats.stats._bekle, _go));
        Debug.Log(KarakterStats.stats._ücret);
    }
}
