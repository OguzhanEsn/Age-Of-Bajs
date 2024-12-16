using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHareket : MonoBehaviour
{
    public float hız;
    float ilkHız;

    GameObject oyuncu;

    public float menzil;

    public bool yakın;
    public bool düşmanYakın;
    bool attacked = false;

    DüşmanStats stats;

    float _cd;

    GameObject düşmanBase;

    public bool içiçe;

    public LayerMask dostMask;

    private void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player");

        stats = gameObject.GetComponent<DüşmanStats>();
        _cd = stats.cd;

        düşmanBase = GameObject.FindGameObjectWithTag("OyuncuBase");

        ilkHız = hız;

    }

    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, Vector2.right, Color.red);
        if (!yakın)
            transform.Translate(Vector2.left * hız * Time.deltaTime);

        if (oyuncu != null)
        {
            if (Vector2.Distance(transform.position, oyuncu.transform.position) <= menzil && yakın == false)
            {
                hız = 0;
            }
        }
        else
            hız = ilkHız;

        if (Vector2.Distance(transform.position, düşmanBase.transform.position) <= menzil && yakın == false)
        {
            hız = 0;
        }
        else
            hız = ilkHız;

        RaycastHit2D dost = Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0, 0), Vector2.left, 0.5f, dostMask);
        Debug.DrawRay(transform.position + new Vector3(-0.6f, 0), Vector2.left, Color.red);
        if (dost.collider != null)
        {
            yakın = true;
            Debug.Log("hit" + dost.collider.gameObject.name);
        }
        if (dost.collider == null)
        {
            yakın = false;
        }
        
        int mask = (1 << 9);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * menzil, menzil, mask);
        if (hit.collider != null)
        {
            hız = 0;
            if (hit.collider.tag == "Player")
            {
                düşmanYakın = true;
                if (hit.collider.GetComponent<Stats>() != null)
                {
                    if (stats.cd <= 0 && attacked == false)
                    {
                        hit.collider.GetComponent<Stats>().can -= stats.hasar;
                        attacked = true;
                        if (attacked)
                            Attacked();
                        Debug.Log(hit.collider.name + "took" + stats.hasar + "damage, and now has" + hit.collider.GetComponent<Stats>().can);

                        if (hit.collider.GetComponent<Stats>().can <= 0)
                        {
                            Düşman.skor += 10;
                        }   

                    }
                    else
                        stats.cd -= Time.deltaTime;
                }
                else
                    Find();
            }

            else if (hit.collider.tag == "OyuncuBase")
            {
                if (hit.collider.GetComponent<OyuncuBase>() != null)
                {
                    if (stats.cd <= 0 && attacked == false)
                    {
                        hit.collider.GetComponent<OyuncuBase>().can -= stats.hasar / 5;
                        attacked = true;
                        if (attacked)
                            Attacked();
                        Debug.Log(hit.collider.name + "took" + stats.hasar + "damage, and now has" + hit.collider.GetComponent<OyuncuBase>().can);
                    }
                    else
                        stats.cd -= Time.deltaTime;
                }
            }
        }
        else
            hız = ilkHız;

    }


    void Attacked()
    {
        attacked = false;
        stats.cd = _cd;
    }

    Oyuncu Find()
    {
        Oyuncu oyuncu = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();

        if (oyuncu != null)
            return oyuncu;
        else
            return null;
    }
}
