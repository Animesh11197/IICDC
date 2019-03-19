using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour {

	float hz, vt;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hz = Input.GetAxis ("Horizontal_alt");
		vt = Input.GetAxis ("Vertical_alt");

		gameObject.transform.Rotate (Vector3.up*hz*Time.deltaTime*360);
		gameObject.transform.Translate (Vector3.forward*vt*Time.deltaTime*speed);
	}
}
