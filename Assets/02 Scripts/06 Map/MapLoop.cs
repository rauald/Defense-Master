using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapLoop : MonoBehaviour
{
    private int[,] number = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

    private int centerNumber;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            MapRight(6);
        }
    }

    public void MapRight(int _idx)
    {
        /*
        centerNumber = number[0,1];
        int _max;

        for (int i = 0; i < number.Length; i++)
        {
            for (int j = 0; j < number.GetLength(1); j++)
            {
                if (centerNumber == number[i, j])
                {
                    _max = j;
                    break;
                }
            }
        }

        centerNumber = _idx - 1;
        */
    }
}