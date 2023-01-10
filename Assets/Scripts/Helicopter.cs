using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private GameObject landingArea;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (called) {
			float dist = Vector3.Distance (landingArea.transform.position, transform.position);

			if (dist > 500f) {
				transform.Translate (Vector3.forward * Time.deltaTime * 500f);
			} else if (dist > 0.001f && dist <= 500f) {
				transform.position = Vector3.Lerp (transform.position, landingArea.transform.position, Time.deltaTime);
			} else {
				print ("done");
				called = false;
			}

		}
	}

	void OnDispatchHelicopter(){
		landingArea = GameObject.FindGameObjectWithTag ("Landing Area");
		Vector3 relative = transform.InverseTransformPoint (landingArea.transform.position);
		float angle = Mathf.Atan2 (relative.x, relative.z) * Mathf.Rad2Deg;

		transform.Rotate (0, angle, 0);
		called = true;
	}
}
