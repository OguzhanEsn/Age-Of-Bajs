using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int hasar;
    public int can;
    public float cd;


    private void Update()
    {
        if (gameObject != null)
        {
            if (can <= 0)
                Destroy(gameObject);
        }
    }
}
