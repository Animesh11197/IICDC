using UnityEngine;
using WebSocketSharp;

using System.Threading;

public class iicdc : MonoBehaviour {
	private WebSocket ws;
	//System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

	//changePosition cp;
	float time=0;
	float timenew=0;
	float delay=0;
	void Start() {
		ws = new WebSocket("ws://localhost:10000/");
		time = System.DateTime.Now.Millisecond;

		ws.OnOpen += OnOpenHandler;
		//ws.OnMessage += OnMessageHandler;
		ws.OnClose += OnCloseHandler;

		ws.ConnectAsync();        
	}
	void Update()
	{
		ws.SendAsync("123,231,60",OnSendComplete);
	}
	private void OnOpenHandler(object sender, System.EventArgs e) {
		Debug.Log("WebSocket connected!");
		//Thread.Sleep(3000);
		ws.SendAsync("connected!", OnSendComplete);
	}

	/*private void OnMessageHandler(object sender, MessageEventArgs e) {
		Debug.Log("WebSocket server said: " + delay);
		timenew = System.DateTime.Now.Millisecond;
		delay = timenew - time;
		time = System.DateTime.Now.Millisecond;
		string[] vec3 = e.Data.Split (','); 
	 	x = float.Parse (vec3 [0]) / 1000;
		y = float.Parse (vec3 [1]) / 1000;
		Debug.Log(x);
		//float x = float.Parse (e.Data);
		//cp.changepostion (x);
		//Thread.Sleep(3000);
		//ws.CloseAsync();
	} */

	private void OnCloseHandler(object sender, CloseEventArgs e) {
		Debug.Log("WebSocket closed with reason: " + e.Reason);
	}

	private void OnSendComplete(bool success) {
		Debug.Log("Message sent successfully? " + success);
	}

}