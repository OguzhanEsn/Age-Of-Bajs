using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaUpgrades : MonoBehaviour
{
    GameObject bina;

    public float bekle = 2;
    Animator a;

    public float menzil;
    public int damage;

    bool attacked = false;

    void Start()
    {
        bekle = 2;
        a = gameObject.GetComponent<Animator>();
        bina = GameObject.FindGameObjectWithTag("OyuncuBase");
    }

    void Update()
    {

        int mask = (1 << 8);

        RaycastHit2D hit = Physics2D.Raycast(bina.transform.position + new Vector3(1, -1, 0), Vector2.right * menzil, menzil, mask);
        if (hit.collider != null)
        {   
            if (hit.collider.tag == "Düşman")
            {
                if (hit.collider.gameObject.GetComponent<DüşmanStats>() != null)
                {
                    a.SetBool("Saldır", true);
                    a.SetBool("Idle", false);
                    if (bekle <= 0)
                    {
                        if (attacked == false)
                        {
                            Debug.Log("aslkdjm");

                            hit.collider.GetComponent<DüşmanStats>().can -= damage;
                            attacked = true;
                            if (attacked)
                                Attacked();
                            Debug.Log(hit.collider.name + "took" + damage + "damage, and now has" + hit.collider.GetComponent<DüşmanStats>().can);

                            if (hit.collider.GetComponent<DüşmanStats>().can <= 0)
                            {
                                Oyuncu.skor += 10;
                            }

                        }

                    }
                    else
                    {
                        bekle -= Time.deltaTime;
                    }

                }
                else
                    Find();
            }
            else
            {
                a.SetBool("Saldır", false);
                a.SetBool("Idle", true);
            }
                
        }
        else
        {
            a.SetBool("Saldır", false);
            a.SetBool("Idle", true);
        }
            

        Debug.DrawRay(bina.transform.position + new Vector3(1,-1,0), Vector2.right * menzil, Color.red);
    }


    void Attacked()
    {
        attacked = false;
        bekle = 2;
    }

    DüşmanStats Find()
    {
        DüşmanStats düşman = GameObject.FindGameObjectWithTag("Düşman").GetComponent<DüşmanStats>();

        if (düşman != null)
            return düşman;
        else
            return null;
    }
}


