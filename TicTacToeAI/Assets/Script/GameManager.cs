using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Button> AllButtons = new List<Button>();


    public int CheckifVictory(int Index)
    {
        bool IsVictory = false;
        //Left to Right
        if (AllButtons[0].GetComponent<TicTac>().Index == Index && AllButtons[1].GetComponent<TicTac>().Index == Index && AllButtons[2].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        if (AllButtons[3].GetComponent<TicTac>().Index == Index && AllButtons[4].GetComponent<TicTac>().Index == Index && AllButtons[5].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        if (AllButtons[6].GetComponent<TicTac>().Index == Index && AllButtons[7].GetComponent<TicTac>().Index == Index && AllButtons[8].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        //Top to Bot
        if (AllButtons[0].GetComponent<TicTac>().Index == Index && AllButtons[3].GetComponent<TicTac>().Index == Index && AllButtons[6].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        if (AllButtons[1].GetComponent<TicTac>().Index == Index && AllButtons[4].GetComponent<TicTac>().Index == Index && AllButtons[7].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        if (AllButtons[2].GetComponent<TicTac>().Index == Index && AllButtons[5].GetComponent<TicTac>().Index == Index && AllButtons[8].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        //non - Vertical/Horizontal
        if (AllButtons[0].GetComponent<TicTac>().Index == Index && AllButtons[4].GetComponent<TicTac>().Index == Index && AllButtons[8].GetComponent<TicTac>().Index == Index)
            IsVictory = true;
        if (AllButtons[2].GetComponent<TicTac>().Index == Index && AllButtons[4].GetComponent<TicTac>().Index == Index && AllButtons[6].GetComponent<TicTac>().Index == Index)
            IsVictory = true;



        if (IsVictory)
        {
            if (Index == 1)
            {
                return 10;
            }
            if (Index == 2)
            {
                return -10;
            }
        }
        
            return 0;
    }

}
