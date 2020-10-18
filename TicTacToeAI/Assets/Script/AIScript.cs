using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIScript : MonoBehaviour
{

    public GameManager GameManager;
    public void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
    }


    public void AITurn(List<Button> Board)
    {
        int bestMove = 1000;
        int BestButtonIndex = 0;
        for (int i = 0; i < Board.Count; i++)
        {
           if (Board[i].GetComponent<TicTac>().Clickable)
            {
                Board[i].GetComponent<TicTac>().Index = 2;
                Board[i].GetComponent<TicTac>().Clickable = false;
                int MoveValue = Minimax(Board, 0, true);
                Board[i].GetComponent<TicTac>().Index = 0;
                Board[i].GetComponent<TicTac>().Clickable = true;

                if (MoveValue < bestMove)
                {
                    BestButtonIndex = i;
                    bestMove = MoveValue;
                }

            }
        }
        
        Board[BestButtonIndex].GetComponent<Button>().onClick.Invoke();

    }
    bool canPlay(List<Button> Board)
    {
        for (int i = 0; i < Board.Count; i++)
        {
            if (Board[i].GetComponent<TicTac>().Clickable)
                return true;
        }
        return false;
    }

    public int Minimax(List<Button> Board, int depth, bool minimax)
    {

        int score = GameManager.CheckifVictory(1);
        if (score == 0)
        {
            score = GameManager.CheckifVictory(2);
        }

        if (score != 0)
        {
            return score;
        }
        if (canPlay(Board) == false)
            return 0;

        if (minimax)
        {
            int best = -1000;

            for (int i = 0; i < Board.Count; i++)
            {

                if (Board[i].GetComponent<TicTac>().Clickable)
                {
                    Board[i].GetComponent<TicTac>().Index = 1;
                    Board[i].GetComponent<TicTac>().Clickable = false;

                    int Tempbest = Mathf.Max(best, Minimax(Board, depth + 1, !minimax));
                    best = Mathf.Max(best, Tempbest);
                    Board[i].GetComponent<TicTac>().Index = 0;
                     Board[i].GetComponent<TicTac>().Clickable = true;
                    
                }

            }

            return best;
        }
        else
        {
            int best = 1000;
            for (int i = 0; i < Board.Count; i++)
            {

                if (Board[i].GetComponent<TicTac>().Clickable)
                {
                    Board[i].GetComponent<TicTac>().Index = 2;
                    Board[i].GetComponent<TicTac>().Clickable = false;

                    int tempbest = Mathf.Min(best, Minimax(Board, depth + 1, !minimax));
                    best = Mathf.Min(best, tempbest);
                    Board[i].GetComponent<TicTac>().Index = 0;
                     Board[i].GetComponent<TicTac>().Clickable = true;
                   

                }

            }

            return best;
        }
    }




}
