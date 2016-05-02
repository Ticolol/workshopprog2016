using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject asteroid;
	public float coolDown = 2;

	float nextSpawn;

	// Use this for initialization
	void Start () {
		nextSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(nextSpawn <= Time.time){
			Vector3 pos = new Vector3(Random.Range(-2.74f,2.74f), 8f, 0f);
			Instantiate(asteroid, pos, Quaternion.identity);
			nextSpawn = Time.time + coolDown;
		}
	}
}
