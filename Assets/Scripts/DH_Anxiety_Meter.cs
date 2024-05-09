using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anxietymeter : MonoBehaviour
{
    public double TempAnxiety = 0;
    public double AnxietyLevel = 0;
    public double Plus = 0;
    public double TempPlus=0;
    public bool Paranoid= false;
    public bool Vibin = false;
    public int FinalCountdown = 3000;
    public double Chill = 1;
    public Transform spawnPoint;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (AnxietyLevel > 90)
        {
            FinalCountdown --;
            if (Plus>0)
            {
                TempPlus=TempPlus+Plus;
            }
            
        }

            if ((AnxietyLevel>65))
        {
            Paranoid = true;
        }
        else
        {
            Paranoid=false;
        }
        if (Plus>0)
        {
            Chill = Chill*0.8;
            double Panic = Plus*0.5;

            AnxietyLevel = AnxietyLevel + Panic;

            Plus = Plus - 0.4;
            TempAnxiety = TempAnxiety + TempPlus;
            TempPlus = TempPlus/3;
            if (TempPlus < 1)
            {
                TempPlus = 0;
            }
        }
        else
        {
            if (Vibin)
            {
                Chill = Chill+ 0.0015;
            }
            double CalmDown =(Chill/(500+(250-(50*Chill))));
            if (TempAnxiety>0)
            {
                TempAnxiety = TempAnxiety - CalmDown*10;
            }
            else
            {
                AnxietyLevel = AnxietyLevel - CalmDown;
                Chill = Chill + 0.001;
            }
        }

 
        if (Plus<0)
        {
            Plus = 0;
        }
        if (Vibin)
        {
            if (Chill > 10)
            {
                Chill = 10;
            }
        }
        else
        {
            if (Chill > 5)
            {
                Chill = 5;
            }
        }
        
        if (TempPlus<0)
        {
            TempPlus = 0;
        }
        if (AnxietyLevel < 0)
        {
            AnxietyLevel = 0;
        }
        if (TempAnxiety < 0)
        {
            TempAnxiety = 0;
        }
        if (Chill<1)
        {
            Chill = 1;
        }
        if (Plus > 5)
        {
            if (AnxietyLevel >= 100)
            {
                TempPlus = Plus;
            }
            else
            {
                TempPlus = Plus - 5;
                Plus = 5;
            }
        }
        if (TempPlus>15)
        {
            TempPlus = 15;
        }
        if (TempAnxiety>100)
        {
            TempAnxiety = 100;
        }
        if (AnxietyLevel>100)
        {
            AnxietyLevel= 100;
        }

        if (FinalCountdown==0)
        {
            AnxietyLevel = 0;
            TempAnxiety= 0;
            FinalCountdown = 5000;
            player.position = spawnPoint.position;
            Debug.Log("Calm down. Keep it together. You can do this.");
        }
        if (AnxietyLevel<65 && Chill>4)
        {
            FinalCountdown++;
        }
        if (FinalCountdown>3000)
        {
            FinalCountdown = 3000;
        }
    }


    public void Spook (double fearlevel, double Adrenaline)
    {
        Plus = Plus + fearlevel;
        TempPlus= TempPlus + Adrenaline;
    }

    public void Listen (bool areyou)
    {
        Vibin = areyou;
    }
}
