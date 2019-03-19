using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

using System.Threading;

public class CameraRig : MonoBehaviour {
	private WebSocket ws;
	float time=0;
	public GameObject pole, platform; //pole = vertical axis, platoform = horizontal axis
	float  hz, vt;

	// Use this for initialization
	void Start () {
		ws = new WebSocket("ws://localhost:10000/");
		time = System.DateTime.Now.Millisecond;

		ws.OnOpen += OnOpenHandler;
		//ws.OnMessage += OnMessageHandler;
		ws.OnClose += OnCloseHandler;

		ws.ConnectAsync(); 
	}
	private void OnOpenHandler(object sender, System.EventArgs e) {
		Debug.Log("WebSocket connected!");
		//Thread.Sleep(3000);
		ws.SendAsync("connected!", OnSendComplete);
	}
	private void OnCloseHandler(object sender, CloseEventArgs e) {
		Debug.Log("WebSocket closed with reason: " + e.Reason);
	}

	private void OnSendComplete(bool success) {
		//Debug.Log("Message sent successfully? " + success);
	}

	// Update is called once per frame
	void Update () {
		hz = Input.GetAxis ("Horizontal");
		vt = Input.GetAxis ("Vertical");

		pole.transform.Rotate (Vector3.up * hz*Time.deltaTime*360);

		platform.transform.Rotate (Vector3.right*-vt*Time.deltaTime*360);
		int x= Mathf.RoundToInt(platform.transform.rotation.eulerAngles.x);
		int y = Mathf.RoundToInt(pole.transform.rotation.eulerAngles.y);
		string s= (x+","+y);
		//Debug.Log(pole.transform.rotation);
		Debug.Log(s);
		ws.SendAsync(s,OnSendComplete);
	}
}
