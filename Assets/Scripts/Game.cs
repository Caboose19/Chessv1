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

    private int pos = 0;
    private int pos1 = 1;
    private int pos2 = 2;
    private int pos3 = 3; 
    private int pos4 = 4;
    private int pos5 = 5;
    private int pos6 = 6;
    private int pos7 = 7;

    private ArrayList PostArray = new ArrayList();

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
        PostArray.Add(pos);
        PostArray.Add(pos1);
        PostArray.Add(pos2);
        PostArray.Add(pos3);
        PostArray.Add(pos4);
        PostArray.Add(pos5);
        PostArray.Add(pos6);
        PostArray.Add(pos7);
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

    public int randNum()
    {
        var rand = new System.Random();

        int index = (rand.Next(PostArray.Count));


        var temp = PostArray[index].ToString();

       // Debug.Log(temp);
        return int.Parse(temp);
    }
    public void SpecialGame()
    {

        #region Inital Random Work
        /* //rooks
        pos = Random.Range(0, 8);
        pos7 = Random.Range(0, 8);
        //Knights
        pos1 = Random.Range(0, 8);
        pos6 = Random.Range(0, 8);

        //Bishops
        pos2 = Random.Range(0, 8);
        if (pos2 % 2 == 0)
        {
            pos5 = Random.Range(0, 8);
        }

        //Queen
        pos3 = Random.Range(0, 8);

        //King
        if (pos > pos7)
        {
            pos4 = Random.Range(pos7, pos -1);
        }
        else
        {
            pos4 = Random.Range(pos, pos7 -1);
        }

        //Checks that pos doesn't overlap ever but still reamins as random so we have no overlap not the prettiest solution but workable
        //Bishops
        while (pos == pos2 || pos1 == pos2 || pos3 == pos2 || pos4 == pos2 || pos5 == pos2 || pos6 == pos2 || pos7 == pos2)
        {
            pos2 = Random.Range(0, 7);

            if (pos2 % 2 == 0)
            {
                if(pos5 %2 == 0)
                {
                    pos5 = Random.Range(0, 8);
                }
            }
            if (pos2 % 2 != 0)
            {
                if (pos5 % 2 != 0)
                {
                    pos5 = Random.Range(0, 8);
                }
            }
        }
        while (pos == pos5 || pos1 == pos5 || pos2 == pos5 || pos3 == pos5 || pos4 == pos5 || pos6 == pos5 || pos7 == pos5)
        {
            pos5 = Random.Range(0, 7);

            if (pos5 % 2 == 0)
            {
                if (pos2 % 2 == 0)
                {
                    pos2 = Random.Range(0, 8);
                }
            }
            if (pos5 % 2 != 0)
            {
                if (pos2 % 2 != 0)
                {
                    pos2 = Random.Range(0, 8);
                }
            }
        }


        //rooks
        while (pos == pos1 || pos2 == pos || pos3 == pos || pos4 == pos || pos5 == pos || pos6 == pos || pos7 == pos)
        {
            pos = Random.Range(0, 8);
            if (pos - 1 == pos7 || pos == pos7 - 1)
            {
                pos = Random.Range(0, 8);
            }
        }
        while (pos == pos7 || pos1 == pos7 || pos2 == pos7 || pos3 == pos7 || pos4 == pos7 || pos5 == pos7 || pos6 == pos7)
        {
            pos7 = Random.Range(0, 8);
            if (pos - 1 == pos7 || pos == pos7 - 1)
            {
                pos7 = Random.Range(0, 8);
            }
        }
        //king 
        if (pos > pos7)
        {
            while (pos4 >= pos && pos4 >= pos7)
            {          
                pos4 = Random.Range(pos7, pos - 1);
                
            }   
        }
        else if (pos7 > pos)
        {
            while (pos4 >= pos && pos4 >= pos7)
            {
                pos4 = Random.Range(pos, pos7 - 1);
                   
            }    
        }

        //Non important placement 
        while (pos == pos3 || pos1 == pos3 || pos2 == pos3 || pos4 == pos3 || pos5 == pos3 || pos6 == pos3 || pos7 == pos3)
        {
            pos3 = Random.Range(0, 8);
        }
        while (pos == pos6 || pos1 == pos6 || pos2 == pos6 || pos3 == pos6 || pos4 == pos6 || pos5 == pos6 || pos7 == pos6)
        {
            pos6 = Random.Range(0, 8);
        }
        while (pos == pos1 || pos2 == pos1 || pos3 == pos1 || pos4 == pos1 || pos5 == pos1 || pos6 == pos1 || pos7 == pos1)
        {
            pos1 = Random.Range(0, 8);
        }*/
        #endregion  Inital Random work 
        //Rooks pos, pos7
        pos = randNum();
        pos7 = randNum();

        while (pos == pos7-1 ||  pos7 == pos-1 || pos == pos7)
        {
            pos = randNum();
            pos7 = randNum();
        }
        PostArray.Remove(pos);
        PostArray.Remove(pos7);

        //King pos4
        pos4 = randNum();

        if (pos > pos7)
        {
            while (pos4 >= pos || pos4 <= pos7)
            {
                pos4 = randNum();
            }
        }
        else if (pos7 > pos)
        { 
            while (pos4 >= pos7 || pos4 <= pos)
            {
                pos4 = randNum();
            }
        }
        PostArray.Remove(pos4);


        //Bishop pos2,pos5
        pos2 = randNum();
        pos5 = randNum();

        while(pos2 % 2 == 0 && pos5 % 2 == 0 || pos2 % 2 != 0 && pos5 % 2 != 0)
        {
            pos2 = randNum();
            pos5 = randNum();
        }
        //remove at idex
        PostArray.Remove(pos2);
        PostArray.Remove(pos5);
        //Others pos1, pos3, pos6, 
        pos1 = randNum();
        PostArray.Remove(pos1);
        pos3 = randNum();
        PostArray.Remove(pos3);
        pos6 = randNum();
        PostArray.Remove(pos6);
        string test = pos + " " + pos1 + " " + pos2 + " " + pos3 + " " + pos4 + " " + pos5 + " " + pos6 + " " + pos7;

        /* return test;*/

        Debug.Log(test);

        //Place pos on the board using random x coord
        #region Place Pieces
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
        #endregion
        for (int i = 0; i < playerBlack.Length - 8; i++)
        {
            string placeTest = playerBlack[i].name + " " + playerBlack[i].transform.position.x + " " + playerWhite[i].name + " " + playerWhite[i].transform.position.x;

            Debug.Log(placeTest);
        }
    }

    public void NormalGame()
    {

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

        string test = pos + " " + pos1 + " " + pos2 + " " + pos3 + " " + pos4 + " " + pos5 + " " + pos6 + " " + pos7 + ":Non Random";


        /* return test;*/

        Debug.Log(test);

        for (int i = 0; i < playerBlack.Length - 8; i++)
        {
            string placeTest = playerBlack[i].name + " " + playerBlack[i].transform.position.x + " " + playerWhite[i].name + " " + playerWhite[i].transform.position.x;

            Debug.Log(placeTest);
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
