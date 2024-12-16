using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListeDüşman : MonoBehaviour
{

    int index = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Düşman")
        {
            objeler.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Düşman")
        {
            objeler.Remove(collision.gameObject);
        }
    }

    List<GameObject> objeler = new List<GameObject>()
    {

    };

    private void Update()
    {
        Debug.Log(objeler.Count);

        if (objeler.Count > 0 && objeler[objeler.Count - index].GetComponent<AIHareket>().yakın)
        {
            if (objeler[objeler.Count - index].GetComponent<AIHareket>() != null)
            {
                objeler[objeler.Count - index].GetComponent<AIHareket>().içiçe = true;
            }
        }

        if (objeler.Count > 0)
        {
            if (!objeler[0].GetComponent<AIHareket>().yakın)
            {
                objeler[0].GetComponent<AIHareket>().içiçe = false;
            }
        }

    }
}
