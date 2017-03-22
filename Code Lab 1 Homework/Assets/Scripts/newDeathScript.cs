using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newDeathScript : MonoBehaviour {

    public GameObject player1Score;
    public GameObject player2Score;

    public GameObject highScoreTxt1Object;
    public GameObject highScoreTxt2Object;

    private Text txt1;
    private Text txt2;
    private Text highScoreTxt1;
    private Text highScoreTxt2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        txt1 = player1Score.GetComponent<Text>();
        txt2 = player2Score.GetComponent<Text>();

        highScoreTxt1 = highScoreTxt1Object.GetComponent<Text>();
        highScoreTxt2 = highScoreTxt2Object.GetComponent<Text>();




    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            
        }

        Destroy(collider.gameObject);
    }

}
