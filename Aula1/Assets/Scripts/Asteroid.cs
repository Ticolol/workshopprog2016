using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public GameObject explosion;
	public float vel = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, -vel * Time.deltaTime, 0);

		if(transform.position.y < -8f){
			Destroy(gameObject);
		}
	}

	public void Die(){
		GameObject obj = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy(obj, 0.4f);
		Destroy(gameObject);
	}
}
