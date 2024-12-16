using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QueueDisplay : MonoBehaviour
{
    public TextMeshProUGUI yazı;

    Spawner sp;

    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    private void Update()
    {
        yazı.text = "Queue: " + sp.sıra.Count;
    }

}

