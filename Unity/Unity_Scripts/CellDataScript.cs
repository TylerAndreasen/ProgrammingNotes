using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDataScript : MonoBehaviour
{

    public int display = -1;
    public bool isBomb = false;

    public char getValue()
    {
        if (isBomb)
        {
            return 'b';
        }
        if (display < 1 | display < 8)
        {
            return ' ';
        } else 
        {
            return (char)(display+48); // Add 48 to move the numeric value to the proper unicode character to display as a number
        }
    }  

    public void setIsBomb()
    {
        isBomb = true;
    }

    public void setDisplay(int passIn)
    {
        display = passIn;
        Debug.Log("#Debug# CellDataScript.setDisplay() ran with int arg "+passIn+" #");
    }

    public bool getIsBomb()
    {
        return isBomb;
    }
}
