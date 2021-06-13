using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DialogScript : MonoBehaviour
{

    [SerializeField]
    private int levelNumber = 0;

    public int textNumber = 0;
    [SerializeField]
    private bool inDialog = false;

    [SerializeField]
    private GameObject Manager;


    [SerializeField]
    private GameObject ratNameg0;
    [SerializeField]
    private GameObject ratNameg1;
    [SerializeField]
    private GameObject ratDialog0;
    [SerializeField]
    private GameObject ratDialog1;
    [SerializeField]
    private GameObject ratDialog2;
    [SerializeField]
    private GameObject ratDialog3;

    [Space]

    [SerializeField]
    private GameObject bhNameg0;
    [SerializeField]
    private GameObject bhNameg1;
    [SerializeField]
    private GameObject bhDialog0;
    [SerializeField]
    private GameObject bhDialog1;
    [SerializeField]
    private GameObject bhDialog2;
    [SerializeField]
    private GameObject bhDialog3;

    [Space]

    [SerializeField]
    private GameObject frogNameg0;
    [SerializeField]
    private GameObject frogNameg1;
    [SerializeField]
    private GameObject frogDialog0;
    [SerializeField]
    private GameObject frogDialog1;
    [SerializeField]
    private GameObject frogDialog2;
    [SerializeField]
    private GameObject frogDialog3;

    [Space]

    [SerializeField]
    private GameObject knNameg0;
    [SerializeField]
    private GameObject knNameg1;
    [SerializeField]
    private GameObject knNameg2;
    [SerializeField]
    private GameObject knDialog0;
    [SerializeField]
    private GameObject knDialog1;
    [SerializeField]
    private GameObject knDialog2;
    [SerializeField]
    private GameObject knDialog3;
    [SerializeField]
    private GameObject knDialog4;


    private void Start()
    {
        levelNumber = 0;
        textNumber = 0;
    }

    public bool getInDialog ()
    {
        return inDialog;
    }

    public void setInDialog(bool Bol)
    {
        inDialog = Bol;
    }

    // Update is called once per frame
    void Update()
    {


        
        if(Input.GetMouseButtonDown(0) && inDialog)
        {

            //ratman
            if (levelNumber == 0 && textNumber == 0)
            {
                textNumber++;
                ratNameg0.SetActive(false);
                ratDialog0.SetActive(false);
                ratNameg1.SetActive(true);
                ratDialog1.SetActive(true);
            } 
            else if (levelNumber == 0 && textNumber == 1)
            {
                textNumber++;
                ratDialog1.SetActive(false);
                ratDialog2.SetActive(true);
            }
            else if (levelNumber == 0 && textNumber == 2)
            {
                ratNameg1.SetActive(false);
                ratDialog2.SetActive(false);
                //give player controll
                inDialog = false;
            }
            else if (levelNumber == 0 && textNumber == 3)
            {
                ratNameg1.SetActive(false);
                ratDialog3.SetActive(false);
                levelNumber = 1;
                textNumber = 0;
                startTalking();
            } else


            //beholder
            if (levelNumber == 1 && textNumber == 0)
            {
                textNumber++;
                bhNameg0.SetActive(false);
                bhDialog0.SetActive(false);
                bhNameg1.SetActive(true);
                bhDialog1.SetActive(true);
            }
            else if (levelNumber == 1 && textNumber == 1)
            {
                textNumber++;
                bhDialog1.SetActive(false);
                bhDialog2.SetActive(true);
            }
            else if (levelNumber == 1
                && textNumber == 2)
            {
                bhNameg1.SetActive(false);
                bhDialog2.SetActive(false);
                //give player controll
                inDialog = false;
            }
            else if (levelNumber == 1 && textNumber == 3)
            {
                bhNameg1.SetActive(false);
                bhDialog3.SetActive(false);
                levelNumber = 2;
                textNumber = 0;
                startTalking();
            }
            else


            //Frog
            if (levelNumber == 2 && textNumber == 0)
            {
                textNumber++;
                frogNameg0.SetActive(false);
                frogDialog0.SetActive(false);
                frogNameg1.SetActive(true);
                frogDialog1.SetActive(true);
            }
            else if (levelNumber == 2 && textNumber == 1)
            {
                textNumber++;
                frogDialog1.SetActive(false);
                frogDialog2.SetActive(true);
            }
            else if (levelNumber == 2 && textNumber == 2)
            {
                frogNameg1.SetActive(false);
                frogDialog2.SetActive(false);
                //give player controll
                inDialog = false;
            }
            else if (levelNumber == 2 && textNumber == 3)
            {
                frogNameg1.SetActive(false);
                frogDialog3.SetActive(false);
                levelNumber = 3;
                textNumber = 0;
                startTalking();
            }
            else


            //Knight
            if (levelNumber == 3 && textNumber == 0)
            {
                textNumber++;
                knNameg0.SetActive(false);
                knDialog0.SetActive(false);

                knNameg1.SetActive(true);
                knDialog1.SetActive(true);
            }
            else if (levelNumber == 3 && textNumber == 1)
            {
                textNumber++;
                knNameg1.SetActive(false);
                knDialog1.SetActive(false);

                knNameg2.SetActive(true);
                knDialog2.SetActive(true);
            }
            else if (levelNumber == 3 && textNumber == 2)
            {
                textNumber++;
                knNameg2.SetActive(false);
                knDialog2.SetActive(false);

                knDialog3.SetActive(true);
                knNameg1.SetActive(true);
            }
            else if (levelNumber == 3 && textNumber == 3)
            {
                textNumber++;
                knDialog3.SetActive(false);
                knNameg1.SetActive(false);

                knDialog4.SetActive(true);
                knNameg1.SetActive(true);
            }
            else if (levelNumber == 3 && textNumber == 4)
            {
                knNameg1.SetActive(false);
                knDialog4.SetActive(false);
                //give player controll
                inDialog = false;
            }
            else if (levelNumber == 3 && textNumber == 5)
            {
                knNameg1.SetActive(false);
                knDialog4.SetActive(false);
                levelNumber = 3;
                textNumber = 0;
            } 
        }
    }

    public void startTalking()
    {
        if (levelNumber == 0)
        {
            ratNameg0.SetActive(true);
            ratDialog0.SetActive(true);
            inDialog = true;
        }
        else if (levelNumber == 1)
        {
            bhNameg0.SetActive(true);
            bhDialog0.SetActive(true);
        }
        else if (levelNumber == 2)
        {
            frogNameg0.SetActive(true);
            frogDialog0.SetActive(true);
        }
        else if (levelNumber == 3)
        {
            knNameg0.SetActive(true);
            knDialog0.SetActive(true);
        }
    }

    public void dayComplete()
    {
        if(levelNumber == 0)
        {

            ratNameg1.SetActive(true);
            ratDialog3.SetActive(true);
            textNumber = 3;
            inDialog = true;
        }
        if(levelNumber == 1)
        {
            bhNameg1.SetActive(true);
            bhDialog3.SetActive(true);
            textNumber = 3;
            inDialog = true;
        }
        if (levelNumber == 2)
        {
            bhNameg1.SetActive(true);
            bhDialog3.SetActive(true);
            textNumber = 3;
            inDialog = true;
        }
        if (levelNumber == 3)
        {
            bhNameg1.SetActive(true);
            bhDialog3.SetActive(true);
            textNumber = 5;
        }
    }
}
