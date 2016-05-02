using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float vel = 9;

	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("(!)GameController")
											.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, vel * Time.deltaTime, 0);

		if(transform.position.y > 8f){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Asteroid"){
			col.gameObject.GetComponent<Asteroid>().Die();
			gameController.SumScore();
			Destroy(gameObject);
		}
	}


}
