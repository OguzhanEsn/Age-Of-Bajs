using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{        
    public float hız;
    float ilkHız;

    GameObject düşman;

    public float menzil;
   
    public bool yakın;
    public bool düşmanYakın;
    bool attacked = false;

    Stats stats;

    float _cd;

    GameObject düşmanBase;


    public LayerMask dostMask;

    public bool içiçe;

    Animator a;

    private void Start()
    {
        düşman = GameObject.FindGameObjectWithTag("Düşman");
        
        stats = gameObject.GetComponent<Stats>();
        _cd = stats.cd;
        stats.cd = 0;
        düşmanBase = GameObject.FindGameObjectWithTag("DüşmanBase");

        ilkHız = hız;
        
        a = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, Vector2.right, Color.red);
        if (!yakın && !içiçe)
        {
            transform.Translate(Vector2.right * hız * Time.deltaTime);
            a.SetBool("Idle", false);
            a.SetBool("Yürü", true);
        }
        else
        {
            a.SetBool("Idle", true);
            a.SetBool("Yürü", false);
        }

        if(düşmanYakın)
        {
            a.SetBool("Yürü", false);
            a.SetBool("Idle", true);
        }

        if (düşman != null)
        {
            if (Vector2.Distance(transform.position, düşman.transform.position) <= menzil && yakın == false)
            {
                hız = 0;
            }
        }
        else
            hız = ilkHız;

        if (Vector2.Distance(transform.position, düşmanBase.transform.position) <= menzil)
        {
            hız = 0;
        }
        else
            hız = ilkHız;

        RaycastHit2D dost = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), Vector2.right, 0.5f, dostMask);
        Debug.DrawRay(transform.position + new Vector3(0.6f, 0), Vector2.right, Color.red);
        if(dost.collider != null)
        {
            yakın = true;
            //Debug.Log("hit" + dost.collider.gameObject.name);
        }
        if (dost.collider == null)
        {
            yakın = false;
        }


        int mask = (1 << 8);
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * menzil, menzil, mask);
        if (hit.collider != null)
        {
            hız = 0;
            if (hit.collider.tag == "Düşman")
            {
                düşmanYakın = true;
                if (hit.collider.GetComponent<DüşmanStats>() != null)
                {
                    if (stats.cd <= 0 && attacked == false)
                    {
                        a.SetTrigger("Saldır");
                        hit.collider.GetComponent<DüşmanStats>().can -= stats.hasar;
                        attacked = true;
                        if (attacked)
                            Attacked();
                        //Debug.Log(hit.collider.name + "took" + stats.hasar + "damage, and now has" + hit.collider.GetComponent<DüşmanStats>().can);

                        if (hit.collider.GetComponent<DüşmanStats>().can <= 0)
                        {
                            Oyuncu.skor += 10;
                        }

                    }
                    else
                        stats.cd -= Time.deltaTime;
                }
                else
                    Find();
            }
                

            else if (hit.collider.tag == "DüşmanBase")
            {
                if (hit.collider.GetComponent<DüşmanBase>() != null)
                {
                    düşmanYakın = true;
                    if (stats.cd <= 0 && attacked == false)
                    {
                        a.SetTrigger("Saldır");
                        hit.collider.GetComponent<DüşmanBase>().can -= stats.hasar / 5;
                        attacked = true;
                        if (attacked)
                            Attacked();
                        //Debug.Log(hit.collider.name + "took" + stats.hasar + "damage, and now has" + hit.collider.GetComponent<DüşmanBase>().can);
                    }
                    else
                        stats.cd -= Time.deltaTime;
                }
            }
        }
        else
        {
            düşmanYakın = false;
            hız = ilkHız;
        }
            


    }


    void Attacked()
    {
        attacked = false;
        stats.cd = _cd;
    }

    DüşmanStats Find()
    {
        DüşmanStats düşman = GameObject.FindGameObjectWithTag("Düşman").GetComponent<DüşmanStats>();

        if(düşman != null)
            return düşman;
        else
            return null;
    }
}
