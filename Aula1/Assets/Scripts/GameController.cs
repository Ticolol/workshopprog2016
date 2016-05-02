using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text scoreText;
	public Text gameOverText;

	int score;


	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Reset game
		if(Input.GetKey(KeyCode.R)){
			Application.LoadLevel("Game");
		}

		//Debug.Log(score);
		scoreText.text = "Score: " + score;
	}

	public void SumScore(){
		score+=10;
	}

	public void PlayerDied(){
		gameOverText.gameObject.SetActive(true);
	}
}
