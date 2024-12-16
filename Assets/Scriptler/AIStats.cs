using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats : MonoBehaviour
{
    public int hasar;
    public int can;
    public float cd;


    public static Stats _stats = null;

    Hareket _hit;

    private void Start()
    {
        _hit = gameObject.GetComponent<Hareket>();
    }
}
