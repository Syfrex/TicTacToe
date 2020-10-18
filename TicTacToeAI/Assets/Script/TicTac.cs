using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTac : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject RestartButton;
    public Button Player;
    public bool Clickable = true;
    public int Index = 0;
    public Text Current;
    public Text WinText;
    public string[] SetCurrentTurn = { "X", "O" };
    static private bool PlayerTurn = true;
    bool AiTurnTime = true;


    public int Value;
    public int Row;
    public int Col;

    
    public void OnClickediClick()
    {
        if (Clickable)
        {
            if (PlayerTurn)
            {
                Current.text = "X";
                PlayerTurn = false;
                Index = 1;
            }
            else
            {
                Current.text = "O";
                PlayerTurn = true;
                Index = 2;
            }

        }
        if (gameManager.GetComponent<GameManager>().CheckifVictory(Index) != 0)
        {
            if (Index == 1)
                WinText.text = "VICTORY TO:X";
            else
                WinText.text = "VICTORY TO:O";

            RestartButton.SetActive(true);
            PlayerTurn = true;
        }

        Clickable = false;

        if (!PlayerTurn)
        {
            gameManager.gameObject.GetComponent<AIScript>().AITurn(gameManager.AllButtons);
        }

    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
     
    }
    public void AiTurn()
    {
        gameManager.gameObject.GetComponent<AIScript>().AITurn(gameManager.AllButtons);

    }
}
