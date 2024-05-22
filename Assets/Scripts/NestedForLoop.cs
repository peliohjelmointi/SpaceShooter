using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestedForLoop : MonoBehaviour
{
    int x = 14;

    private void Awake()
    {
        //NestedForLoopExample();
        ForeachExample();
    }


    void ForeachExample()
    {     
     int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
     
        foreach (int luku in intArray)
        {
            if(luku!=5)
                Debug.Log(luku);
            if (luku > 7)
            {
                break; //poistuu foreach-loopista
                //usein näkee return; -lauseen jos joku ehto toteutuu
            }
        }
    }

    void NestedForLoopExample()
    {
        if (x >= 18)  //jos ei käytä { niin ajetaan vain 1 sisempi rivi!
            Debug.Log("Täysi-ikäinen");
        Debug.Log("JES JES"); //Tämä ajetaan, koska
                              //ei ole if:n sisällä!

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Debug.Log($"X={x}, Y={y}"); //tai:
                //Debug.Log("X=" + x.ToString() + ", Y=" + y.ToString());
            }
        }
    }
 

}
