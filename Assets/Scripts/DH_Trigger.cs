using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DH_Trigger : MonoBehaviour
{
    public AudioSource SFX;
    int cooldown =0;
    public int uses=1;
    int usesleft;
    public int useresettime;
    int usecooldown=0;
    public bool infinite = true;
    public bool repeat = false;
    bool contact = false;
    bool used = false;
    public int cooldownbase;
    public double Anx;
    public double TempAnx;
    GameObject SpookEm;
    void OnTriggerEnter(Collider Checker)
    {
        if (Checker.name == "Player")
        {
            contact = true;
        }
    }
    private void OnTriggerExit(Collider Checker2)
    {
        if (Checker2.name=="Player")
        {
            contact = false;
            used = false;
        }
    }

    IEnumerator soundend()
    {
        yield return new WaitForSecondsRealtime(SFX.clip.length);
        SFX.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpookEm = GameObject.FindGameObjectWithTag("Player");
        usesleft = uses;
        usecooldown = useresettime;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown> 0)
        {
            cooldown--;
        }
        else
        {
            if (contact)
            {
                if (infinite ||usesleft>0)
                {
                    if (repeat)
                    {
                        SpookEm.GetComponent<anxietymeter>().Spook(Anx, TempAnx);
                        cooldown = cooldownbase;
                        
                        SFX.enabled = true;
                        StartCoroutine(soundend());
                    }
                    else
                    {
                        if (!used)
                        {
                            SpookEm.GetComponent<anxietymeter>().Spook(Anx, TempAnx);
                            cooldown = cooldownbase;
                            used = true;
                            SFX.enabled = true;
                            StartCoroutine(soundend());

                        }

                    }
                    if (!infinite)
                    {
                        usesleft = usesleft - 1;
                    }
                }
                else
                {
                    if (useresettime != 0)
                    {
                        if (usecooldown != 0)
                        {
                            usecooldown--;
                        }
                        else
                        {
                            usesleft = uses;
                            usecooldown = useresettime;
                        }
                    }
                }
            }
        }
    }
}
