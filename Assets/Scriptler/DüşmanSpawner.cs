using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DüşmanSpawner : MonoBehaviour
{

    public GameObject düşman;

    public Transform pos;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        GameObject go = Instantiate(düşman, pos.position, pos.rotation);
        yield return new WaitForSeconds(10);
        StartCoroutine("Spawn");
    }

}
