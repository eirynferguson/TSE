using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DH_PlayMusic : MonoBehaviour
{

    int time;
    public int rewindtime;
    bool checkmark;
    bool ison;

    public AudioSource song;
    GameObject Listener;
    private void OnMouseDown()
    {
        if (time ==0)
        {
            StartCoroutine(SongEnd());
        }
    }

    IEnumerator SongEnd()
    {
        ison = true;
        song.enabled = true;
        yield return new WaitForSecondsRealtime(song.clip.length);
        song.enabled = false;
        time = rewindtime;
        ison = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkmark = false;
        Listener = GameObject.FindGameObjectWithTag("Player");
        time = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (time>0)
        {
            time--;
        }
        if (ison)
        {
            Listener.GetComponent<anxietymeter>().Vibin = true;
            checkmark =false;
        }
        else
        {
            if (!checkmark)
            {
                Listener.GetComponent<anxietymeter>().Vibin = false;
            }
        }
    }
}
