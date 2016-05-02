using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float vel = 6f;
	public GameObject bullet;
	public float coolDown = 1f;
	public GameObject explosao;

	GameController gameController;
	Transform spawnBullet;
	float nextBullet;
	
	void Start () {
		gameController = GameObject.Find("(!)GameController")
											.GetComponent<GameController>();
		spawnBullet = transform.Find("SpawnBullet");
		nextBullet = 0;
	}
	
	
	void Update () {
		//Mover nave lateralmente
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(vel * Time.deltaTime,0,0);
		}else if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(-vel * Time.deltaTime,0,0);
		}

		//Aplicar limites de tela a nave
		Vector3 pos;
		if(transform.position.x > 2.84f){
			//transform.position.x = 2.84f;
			pos = transform.position;
			pos.x = 2.84f;
			transform.position = pos;
		}
		if(transform.position.x < -2.84f){
			pos = transform.position;
			pos.x = -2.84f;		
			transform.position = pos;
		}

		//Atirar
		if(Input.GetKey(KeyCode.Space) && nextBullet <= Time.time){
			Instantiate(bullet, spawnBullet.position, Quaternion.identity);
			nextBullet = Time.time + coolDown;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Asteroid"){
			col.gameObject.GetComponent<Asteroid>().Die();
			gameController.PlayerDied();
			GameObject obj = Instantiate(explosao, transform.position, 
								Quaternion.identity) as GameObject;
			Destroy(obj,2f);
			Destroy(gameObject);
		}
	}

}
