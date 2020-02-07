using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{

    private bool players = false; //false if one player, true if two
    public BC chooseOne, chooseTwo;
    public Button start;

    private int[] controls = { 0, 1 };
    public BC[,] buttons = new BC[2,4];

    // Start is called before the first frame update
    void Start()
    {


        chooseOne.listen(set1P);
        chooseTwo.listen(set2P);
        start.onClick.AddListener(begin);

        /*
        wasd1.listen(setW1);
        ijkl1.listen(setI1);
        arrow1.listen(setA1);
        mouse1.listen(setM1);

        wasd2.listen(setW2);
        ijkl2.listen(setI2);
        arrow2.listen(setA2);
        mouse2.listen(setM2);
        // */
    }

    // Update is called once per frame
    void Update()
    {
        if(!players)
        {
            chooseOne.select();
            chooseTwo.unselect();

            /*
            wasd2.disable();
            ijkl2.disable();
            arrow2.disable();
            mouse2.disable();
            // */
        }
        else
        {
            chooseOne.unselect();
            chooseTwo.select();

            /*
            wasd2.enable();
            ijkl2.enable();
            arrow2.enable();
            mouse2.enable();
            // */
        }

        for(int player = 0; player < 2; player++)
        {
            for(int number = 0; number < 4; number++)
            {
                if (controls[player] == number)
                {
                    buttons[player, number].select();
                    buttons[1 - player, number].disable();
                }
                else
                {
                    buttons[player, number].unselect();
                    buttons[1 - player, number].enable();
                }
            }
        }
    }

    //private int controlsOne = 0, controlsTwo = 1;
    //public BC wasd1, ijkl1, arrow1, mouse1;
    //public BC wasd2, ijkl2, arrow2, mouse2;

    void set1P()
    {
        players = false;
    }
    void set2P()
    {
        players = true;
    }

    /*
    //disgusting little button methods
    

    void setW1()
    {
        controlsOne = 0;
    }
    void setI1()
    {
        controlsOne = 1;
    }
    void setA1()
    {
        controlsOne = 2;
    }
    void setM1()
    {
        controlsOne = 3;
    }

    void setW2()
    {
        controlsTwo = 0;
    }
    void setI2()
    {
        controlsTwo = 1;
    }
    void setA2()
    {
        controlsTwo = 2;
    }
    void setM2()
    {
        controlsTwo = 3;
    }
    // */

    public void begin()
    {
        if(!players)
        {
            Overlord.changeStage(1, controls[0], controls[1]);
        }
        else
        {
            Overlord.changeStage(2, controls[0], controls[1]);
        }
    }

    public void setPC(int p, int n)
    {
        controls[p] = n;
    }
}
