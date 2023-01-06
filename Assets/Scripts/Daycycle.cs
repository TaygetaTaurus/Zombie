using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycycle : MonoBehaviour {

	[Tooltip("Количество минут в секунду")]
	public float minutesPerSecond = 60;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float angleThisFrame = Time.deltaTime/360 * minutesPerSecond;
		transform.RotateAround (transform.position, Vector3.forward, angleThisFrame);
	}
}
