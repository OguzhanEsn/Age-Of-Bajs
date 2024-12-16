using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListe : MonoBehaviour
{

    int index = 1;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            objeler.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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

        if(objeler.Count > 0 && objeler[objeler.Count - index].GetComponent<Hareket>().yakın)
        {
            if (objeler[objeler.Count - index].GetComponent<Hareket>() != null)
            {
                objeler[objeler.Count - index].GetComponent<Hareket>().içiçe = true;
            }
        }

        if(objeler.Count > 0)
        {
            if(!objeler[0].GetComponent<Hareket>().yakın)
            {
                objeler[0].GetComponent<Hareket>().içiçe = false;
            }
        }

    }
}
