using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {


	public float timeSinceLastTrigger = 0f;

	private bool foundClearArea = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;

		if (!foundClearArea && timeSinceLastTrigger > 1f && Time.realtimeSinceStartup > 1f) {
			SendMessageUpwards ("OnFindClearArea");
			foundClearArea = true;
		}
	}

	public void OnTriggerStay(Collider collider){
		if (collider.tag != "Player") {
			timeSinceLastTrigger = 0f;
		}
	}
}
