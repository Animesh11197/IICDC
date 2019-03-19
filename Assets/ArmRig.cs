using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRig : MonoBehaviour {

	public GameObject platform, arm;
	float hz, vt;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		hz = Input.GetAxis ("Horizontal_arrow");
		vt = Input.GetAxis ("Vertical_arrow");

		platform.transform.Rotate (Vector3.up * hz*Time.deltaTime*360);
		arm.transform.Rotate (Vector3.right*vt*Time.deltaTime*360);
	}
}
