using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour {

	public void changepostion(float x)
	{
		this.gameObject.transform.position = new Vector3 (x, 0, 0);
	}

}
