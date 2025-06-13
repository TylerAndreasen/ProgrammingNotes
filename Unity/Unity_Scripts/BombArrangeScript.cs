using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How do I use random numbers in C#?
//How do I dynamically apply images to the various cells in the grid?
//And what is the most effecient/practical way to do so? Potentially Tiling, though I know like 0 about it.

public class BombArrangeScript : MonoBehaviour
{

    public int[][] grid;

    public RowScript row0;
    
    // Start is called before the first frame update
    void Start()
    {
        row0 = UntiyEngine.getComponent("Row0Tag");
        grid = new int[10][]; 
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = new int[10] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        };

        int[] locales = new int[10] {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        bool madeTen = false;
        int position = 0;
        
        while(!madeTen)
        {
            int test = Random.Range(0,100);
            if (contains(locales, test))
            {
                continue;
            } else
            {
                locales[position] = test;
                position++;
            }
            if (position == 10)
            {
                madeTen = !madeTen;
                break;
            }
        }

        foreach (int num in locales)
        {
            int col = num % 10, row = num / 10;

        }

        row0.getCell(2).setDisplay(grid[0][0]); 
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static bool contains(int[] bank, int key)
    {
        foreach (int item in bank)
        {
            if (item == key)
            {
                return true;
            }
        }
        return false;
    }
}
