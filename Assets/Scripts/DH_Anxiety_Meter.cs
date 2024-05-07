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
    public int FinalCountdown = 15000;
    public double Chill = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (AnxietyLevel >= 100)
        {
            FinalCountdown = FinalCountdown - 1;
            TempAnxiety = TempAnxiety + TempPlus;
            TempPlus = 0;
            
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
            Chill = Chill*0.65;
            double Panic = Plus*0.5;

            AnxietyLevel = AnxietyLevel + Panic;

            Plus = Plus - 0.4;
            TempAnxiety = TempAnxiety + TempPlus;
            TempPlus = TempPlus - 0.4;
        }
        else
        {
            if (Vibin)
            {
                Chill = Chill+ 0.0008;
            }
            double CalmDown =(Chill/(500+(250-(50*Chill))));
            if (TempAnxiety>0)
            {
                TempAnxiety = TempAnxiety - CalmDown*10;
            }
            else
            {
                AnxietyLevel = AnxietyLevel - CalmDown;
                Chill = Chill + 0.0008;
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

        if (FinalCountdown<0)
        {
            AnxietyLevel = 0;
            FinalCountdown = 10000;
            Debug.Log("Anxiety was maxed out. this is a placeholder for a reset to bathroom");
        }
        if (AnxietyLevel<65 && Chill>4)
        {
            FinalCountdown++;
        }
        if (FinalCountdown>10000)
        {
            FinalCountdown = 10000;
        }
    }


    public void Spook (double fearlevel)
    {
        Plus = Plus + fearlevel;
    }
}
