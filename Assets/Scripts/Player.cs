using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; // the parent of the spawn points
	public GameObject landingAreaPrefab;

	private bool reSpawn = false;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;

	// Use this for initialization
	void Start () {
		spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lastRespawnToggle != reSpawn) {
			Respawn ();
			reSpawn = false;
		}else {
			lastRespawnToggle = reSpawn;
		}
			
	}

	private void Respawn(){
		int i = Random.Range (1, spawnPoints.Length);
		transform.position = spawnPoints [i].transform.position;
	}

	void OnFindClearArea(){
		Invoke ("DropFlare", 3f);
	}

	void DropFlare (){
		Vector3 flarePos = new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z);
		Instantiate (landingAreaPrefab, flarePos, transform.rotation);
	}
}

