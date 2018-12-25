using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour {
    // Control Variables
    public bool pickupWater = false, pickupIce = false, pickupTRX = false;
    public bool win=false;
    //public GameObject SerialScriptObj;
    //private SerialReadNew SerialScript;
    public GameObject player;
    private PlayerControl playerControlScript;
    // all UI panel
    public GameObject[] UI_panel;
    // ranking
    public Text ranking;
    private int totalPlayer = 0;
    private int loser = 0;
    private float[] score;
    // during game
    public GameObject[] tools;
    public GameObject[] areas;
    private int areamode = 0;
    public int watertotal = 3, icetotal = 2, TRXtotal = 2;
    private int waterleft, iceleft, TRXleft;
    public Text time;
    private float startTime=0f, totalTime = 0f;
    // animations
    public ParticleSystem water_animate, ice_animate, TRX_animate, start_animate;

    void Start () {
        waterleft = watertotal;
        iceleft = icetotal;
        TRXleft = TRXtotal;
        score = new float[5];

        //SerialScript = SerialScriptObj.GetComponent<SerialReadNew>();
        playerControlScript = player.GetComponent<PlayerControl>();
    }
	
	void Update () {

        // read serial port
        //if (SerialScript.control != -1)
        //{
        //    if (SerialScript.control == 0)
        //    { // ice
        //        pickupIce = true;
        //        SerialScript.control = -1;
        //    }
        //    else if (SerialScript.control == 1) // water
        //    {
        //        pickupWater = true;
        //        SerialScript.control = -1;
        //    }
        //}

        if (UI_panel[2].activeInHierarchy)
        {
            pickUpTools();
            updateTime();
            WinOrNot();
            setArea();
        }
    }
    
    void pickUpTools()
    {
        if (pickupWater && waterleft > 0)
        {
            tools[--waterleft].SetActive(false);
            water_animate.Play();
            pickupWater = false;
        }

        if (pickupIce && iceleft > 0)
        {
            tools[--iceleft + watertotal].SetActive(false);
            ice_animate.Play();
            pickupIce = false;
        }

        if (pickupTRX && TRXleft > 0)
        {
            tools[--TRXleft + watertotal + icetotal].SetActive(false);
            TRX_animate.Play();
            pickupTRX = false;
        }
    }

    void updateTime()
    {
        if(totalTime == 0f)
            time.text = (Time.time - startTime).ToString("F2");
    }

    void WinOrNot()
    {
        if (win)
        {
            win = !win;
            totalTime = Time.time - startTime;
            setRanking();
            // play particle system
            // ...

            // switch UI
            UI_panel[2].SetActive(false);
            UI_panel[1].SetActive(true);

        }
    }

    void setRanking()
    {
        if (totalPlayer < 5)
        {
            score[totalPlayer++] = totalTime;
        }
        else
        {
            score[loser] = totalTime;
        }

        // sort the score and print
        string allScore = "";
        float currentMin = 1000f, min=0f;
        int currentPlayer = 0;
        for(int j=0; j< totalPlayer; j++)
        {
            for (int i = 0; i < totalPlayer; i++)
            {
                if (score[i] < currentMin && score[i] > min)
                {
                    currentMin = score[i];
                    currentPlayer = i;
                }
            }
            min = currentMin;
            currentMin = 1000f;
            allScore += "Player " + (currentPlayer + 1) + "   " + min.ToString("F2") + "\n";
        }
        ranking.text = allScore;
        loser = currentPlayer;
    }

    void setArea()
    {
        
        // set areamode
        float dis = Vector3.Distance(playerControlScript.reversArea.transform.position, player.transform.position);
        float dis2 = Vector3.Distance(playerControlScript.rockArea.transform.position, player.transform.position);
        if (dis <= playerControlScript.reverseRange)
        {
            areamode = 2;
        }
        else if (dis2 <= playerControlScript.rockArea.transform.localScale.x*0.5f)
        {
            areamode = 1;
        }
        else
        {
            areamode = 0;
        }

        // display areamode UI
        if (areamode == 0) // 一般
        {
            areas[0].SetActive(true);
            areas[1].SetActive(false);
            areas[2].SetActive(false);
        }
        else if (areamode == 1) // 暗礁
        {
            areas[0].SetActive(false);
            areas[1].SetActive(true);
            areas[2].SetActive(false);
        }
        else if (areamode == 2) // 逆流
        {
            areas[0].SetActive(false);
            areas[1].SetActive(false);
            areas[2].SetActive(true);
        }


    }

    // onclick button action
    public void onStartClick()
    {
        UI_panel[0].SetActive(false);
        UI_panel[1].SetActive(false);
        UI_panel[2].SetActive(true);

        //start_animate.Play();

        // initialize variables
        waterleft = watertotal;
        iceleft = icetotal;
        TRXleft = TRXtotal;
        startTime = Time.time;
        totalTime = 0f;
        for (int i = 0; i < 7; i++)
        {
            tools[i].SetActive(true);
        }
    }
}
