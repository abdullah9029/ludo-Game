using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
public GameObject[] players;
public Transform[] startingPoints;
public Transform[] endingPoints;
public Transform[] pathPoints;
public int diceValue;
public int currentPlayerIndex;
public bool isGameOver;

void Start()
{
    currentPlayerIndex = 0;
    isGameOver = false;
    InitializePlayers();
}

void Update()
{
    if (!isGameOver)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
    }
}

void InitializePlayers()
{
    for (int i = 0; i < players.Length; i++)
    {
        players[i].transform.position = startingPoints[i].position;
    }
}

void RollDice()
{
    diceValue = Random.Range(1, 7);
    MovePlayer();
}

void MovePlayer()
{
    GameObject currentPlayer = players[currentPlayerIndex];
    int stepsToMove = diceValue;

    for (int i = 0; i < stepsToMove; i++)
    {
        int currentPathIndex = System.Array.IndexOf(pathPoints, currentPlayer.transform.position);
        if (currentPathIndex + 1 < pathPoints.Length)
        {
            currentPlayer.transform.position = pathPoints[currentPathIndex + 1].position;
        }
        else
        {
            currentPlayer.transform.position = endingPoints[currentPlayerIndex].position;
            isGameOver = true;
            break;
        }
    }

    currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
}
}
