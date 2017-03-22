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
        GameObject player2 = Instantiate(Resources.Load("Prefabs/Player2") as GameObject);


        int yPos = 0;




		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			
	
			for(int xPos = 0; xPos < line.Length; xPos++){

		
				if(line[xPos] == 'x'){
              

                   GameObject cube = Instantiate(Resources.Load("Prefabs/SquareFloor")as GameObject);

                    //Make the parent transform levelHolder's transform, so it is
                    //easier to manage in the scene hiearchy
                    cube.transform.parent = levelHolder.transform;

					//Move the cube to the appropriate position on the screen according
					//to where it appeared in the file and the offsets
					cube.transform.position = new Vector3(
						xPos + offsetX, 
						yPos + offsetY, 
						0);
				} if (line[xPos] == 'P')
                { // we see a 'P'
                  //Move the player to that location
                    player1.transform.position = new Vector3(
                        xPos + offsetX,
                        yPos + offsetY,
                        0);
                }

                if (line[xPos] == 'O')
                { // we see a 'P'
                  //Move the player to that location
                    player2.transform.position = new Vector3(
                        xPos + offsetX,
                        yPos + offsetY,
                        0);
                }
            }

			//decrease the Y Position for each new line
			yPos--;
		}

		//Close the StreamReader
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
