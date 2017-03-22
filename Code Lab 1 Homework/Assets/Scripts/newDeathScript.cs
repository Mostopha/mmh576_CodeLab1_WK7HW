using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newDeathScript : MonoBehaviour {

    private const string PREF_HIGH_SCORE_1 = "highScore1Pref";
    private const string PREF_HIGH_SCORE_2 = "highScore2Pref";

    public GameObject player1ScoreObject;
    public GameObject player2ScoreObject;

    public GameObject highScoreTxt1Object;
    public GameObject highScoreTxt2Object;

    public Scene nextInLine;

    private Text txt1;
    private Text txt2;
    private Text highScoreTxt1;
    private Text highScoreTxt2;

    private static int player1Score;
    public int Player1Score
    {
        get{
        
         return player1Score;
        }

        set
        {
            if (player1Score > HighScore1)
            {
                HighScore1 = player1Score;
            }
        }

    }
    private static int player2Score;
    public int Player2Score
    {
        get
        {

            return player2Score;
        }

        set
        {
            if (player2Score > HighScore2)
            {
                HighScore2 = player2Score;
            }
        }

    }

    public static newDeathScript instance;

    private int highScore1;
    public int HighScore1
    {
        get {
            highScore1 = PlayerPrefs.GetInt(PREF_HIGH_SCORE_1);
            return highScore1;

        }

        set
        {
            highScore1 = player1Score;

            PlayerPrefs.SetInt(PREF_HIGH_SCORE_1, highScore1);
            

        }
    }

    private int highScore2;
    public int HighScore2
    {
        get
        {
            highScore2 = PlayerPrefs.GetInt(PREF_HIGH_SCORE_2);
            return highScore2;

        }

        set
        {
            highScore2 = player2Score;

            PlayerPrefs.SetInt(PREF_HIGH_SCORE_2, highScore2);


        }
    }


    // Use this for initialization
    void Start () {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        txt1 = player1ScoreObject.GetComponent<Text>();
        txt2 = player2ScoreObject.GetComponent<Text>();

        highScoreTxt1 = highScoreTxt1Object.GetComponent<Text>();
        highScoreTxt2 = highScoreTxt2Object.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {



        txt1.text = "P1 " + player1Score;
        txt2.text = "P2 " + player2Score;


        highScoreTxt1.text = "P1 High " + highScore1;
        highScoreTxt2.text = "P2 High " + highScore2;


    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            player2Score+=10;
            Destroy(collider.gameObject);

            LevelLoader.levelNum++;
            SceneManager.LoadScene("VacationHomework2");
        }

        else if(collider.gameObject.tag == "Player2")
        {
            player1Score+=10;
            Destroy(collider.gameObject);

            LevelLoader.levelNum++;
            SceneManager.LoadScene("VacationHomework2");
        }
       
    }

}
