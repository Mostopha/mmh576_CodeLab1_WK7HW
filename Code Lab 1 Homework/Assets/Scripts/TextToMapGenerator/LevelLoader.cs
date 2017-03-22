using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	
	public float offsetX = 0;
	public float offsetY = 0;

	public string[] fileNames;

	public static int levelNum = 0;

	// Use this for initialization
	void Start () {

	
		string fileName = fileNames[levelNum];
        
		string filePath = Application.dataPath + "/" + fileName;

		
		StreamReader sr = new StreamReader(filePath);

	
		GameObject levelHolder = new GameObject("Level Holder");
        GameObject player1 = Instantiate(Resources.Load("Prefabs/Player1") as GameObject);
        player1.tag = "Player1";

        GameObject player2 = Instantiate(Resources.Load("Prefabs/Player2") as GameObject);
        player2.tag = "Player2";

        GameObject enemy = Instantiate(Resources.Load("Prefabs/Obstacle") as GameObject);

        enemy.layer = LayerMask.NameToLayer("Ghost");


        int yPos = 0;




		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			
	
			for(int xPos = 0; xPos < line.Length; xPos++){

		
				if(line[xPos] == 'x'){
              

                   GameObject cube = Instantiate(Resources.Load("Prefabs/SquareFloor")as GameObject);
                    cube.tag = "Ground";


                    cube.transform.parent = levelHolder.transform;

				
					cube.transform.position = new Vector3(
						xPos + offsetX, 
						yPos + offsetY, 
						0);
				} if (line[xPos] == 'P')
                { 
                    player1.transform.position = new Vector3(
                        xPos + offsetX,
                        yPos + offsetY,
                        0);
                }

                if (line[xPos] == 'O')
                { 
                    player2.transform.position = new Vector3(
                        xPos + offsetX,
                        yPos + offsetY,
                        0);
                }

                if (line[xPos] == 'E')
                { 
                    enemy.transform.position = new Vector3(
                        xPos + offsetX,
                        yPos + offsetY,
                        0);
                }
            }

	
			yPos--;
		}

		
		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.P)){
			levelNum++;
			SceneManager.LoadScene("VacationHomework2");
		}
	}
}
