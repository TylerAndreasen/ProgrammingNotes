using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour
{
    public CellDataScript[] cells = new CellDataScript[2];

    public CellDataScript getCell(int index)
    {
        if (index < cells.Length & index > -1)
        {
            return cells[index];
        } 
        else
        {
            return null;
        }
    }
    
}