using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Reference from Unity IDE
    public GameObject chesspiece;

    public GameObject board;
    public GameObject btn1;
    public GameObject btn2;

    //Matrices needed, positions of each of the GameObjects
    //Also separate arrays for the players in order to easily keep track of them all
    //Keep in mind that the same objects are going to be in "positions" and "playerBlack"/"playerWhite"
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];


    //current turn
    private string currentPlayer = "white";

    //Game Ending
    private bool gameOver = false;

    //Unity calls this right when the game starts, there are a few built in functions
    //that Unity can call for you
    public void Start()
    {
        board.SetActive(false);
        btn1.SetActive(true);
        btn2.SetActive(true);

    }
    //starts normal game
    public void OnClickNormal()
    {
        board.SetActive(true);
        btn1.SetActive(false);
        btn2.SetActive(false);
        NormalGame();
    }

    //Starts Chess 960

    public void OnClick960()
    {
        board.SetActive(true);
        btn1.SetActive(false);
        btn2.SetActive(false);
        SpecialGame();
    }

    public void SpecialGame()
    {
        int pos = Random.Range(0, 8);
        int pos1 = Random.Range(0, 8);
        int pos2 = Random.Range(0, 8);
        int pos3 = Random.Range(0, 8);
        int pos4 = Random.Range(0, 8);
        int pos5 = Random.Range(0, 8);
        int pos6 = Random.Range(0, 8);
        int pos7 = Random.Range(0, 8);
        //Checks that pos doesn't overlap ever but still reamins as random so we have no overlap not the prettiest solution but workable
        /*
                while (pos == pos1 || pos == pos2 || pos == pos3 || pos == pos4 || pos == pos5 || pos == pos6 || pos == pos7)
                {
                    pos = Random.Range(0, 7);
                }*/
        while (pos == pos1 || pos2 == pos1 || pos3 == pos1 || pos4 == pos1 || pos5 == pos1 || pos6 == pos1 || pos7 == pos1)
        {
            pos1 = Random.Range(0, 7);
        }
        while (pos == pos2 || pos1 == pos2 || pos3 == pos2 || pos4 == pos2 || pos5 == pos2 || pos6 == pos2 || pos7 == pos2)
        {
            pos2 = Random.Range(0, 7);
        }
        while (pos == pos3 || pos1 == pos3 || pos2 == pos3 || pos4 == pos3 || pos5 == pos3 || pos6 == pos3 || pos7 == pos3)
        {
            pos3 = Random.Range(0, 7);
        }
        while (pos == pos4 || pos1 == pos4 || pos2 == pos4 || pos3 == pos4 || pos5 == pos4 || pos6 == pos4 || pos7 == pos4)
        {
            pos4 = Random.Range(0, 7);
        }
        while (pos == pos5 || pos1 == pos5 || pos2 == pos5 || pos3 == pos5 || pos5 == pos4 || pos6 == pos5 || pos7 == pos5)
        {
            pos5 = Random.Range(0, 7);
        }
        while (pos == pos6 || pos1 == pos6 || pos2 == pos6 || pos3 == pos6 || pos4 == pos6 || pos5 == pos6 || pos7 == pos6)
        {
            pos6 = Random.Range(0, 7);
        }
        while (pos == pos7 || pos1 == pos7 || pos2 == pos7 || pos3 == pos7 || pos4 == pos7 || pos5 == pos7 || pos6 == pos7)
        {
            pos7 = Random.Range(0, 7);
        }

        //Place pos on the board using random x coord

        playerWhite = new GameObject[] { Create("white_rook", pos, 0), Create("white_knight", pos1, 0),
            Create("white_bishop", pos2, 0), Create("white_queen", pos3, 0), Create("white_king", pos4, 0),
            Create("white_bishop", pos5, 0), Create("white_knight", pos6, 0), Create("white_rook", pos7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
            Create("white_pawn", 3, 1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1) };
        playerBlack = new GameObject[] { Create("black_rook", pos, 7), Create("black_knight",pos1,7),
            Create("black_bishop",pos2,7), Create("black_queen",pos3,7), Create("black_king",pos4,7),
            Create("black_bishop",pos5,7), Create("black_knight",pos6,7), Create("black_rook",pos7,7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
            Create("black_pawn", 3, 6), Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6) };

        //Set all piece positions on the positions board
        for (int i = 0; i < playerWhite.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public void NormalGame()
    {

        playerWhite = new GameObject[] { Create("white_rook", 0, 0), Create("white_knight", 1, 0),
            Create("white_bishop", 2, 0), Create("white_queen", 3, 0), Create("white_king", 4, 0),
            Create("white_bishop", 5, 0), Create("white_knight", 6, 0), Create("white_rook", 7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
            Create("white_pawn", 3, 1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1) };
        playerBlack = new GameObject[] { Create("black_rook", 0, 7), Create("black_knight",1,7),
            Create("black_bishop",2,7), Create("black_queen",3,7), Create("black_king",4,7),
            Create("black_bishop",5,7), Create("black_knight",6,7), Create("black_rook",7,7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
            Create("black_pawn", 3, 6), Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6) };

        //Set all piece positions on the positions board
        for (int i = 0; i < playerWhite.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>(); //We have access to the GameObject, we need the script
        cm.name = name; //This is a built in variable that Unity has, so we did not have to declare it before
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate(); //It has everything set up so it can now Activate()
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();
        //Overwrites either empty space or whatever was there
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            //Using UnityEngine.SceneManagement is needed here
            SceneManager.LoadScene("Game"); //Restarts the game by loading the scene over again
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        //Using UnityEngine.UI is needed here
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";

        GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
