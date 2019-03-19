using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

using System.Threading;

public class Main2 : MonoBehaviour {
    string s1;
	private WebSocket ws;
    public Text txt;
    void Start() {
        s1="tutu";
		ws = new WebSocket("ws://localhost:10000/");
        txt= gameObject.GetComponent<Text>();
        txt.text="hi there";
        ws.OnOpen += OnOpenHandler;
        ws.OnMessage += OnMessageHandler;
        ws.OnClose += OnCloseHandler;

        ws.Connect();        
    }
    public void ButtonPress()
    {   s1=txt.text;
        ws.SendAsync(s1, OnSendComplete);
        Debug.Log(s1);
    }
    private void OnOpenHandler(object sender, System.EventArgs e) {
        Debug.Log("WebSocket connected!");
        Thread.Sleep(3000);
        ws.SendAsync("hi there", OnSendComplete);
    }

    private void OnMessageHandler(object sender, MessageEventArgs e) {
        Debug.Log("WebSocket server said: " + e.Data);
		float x = float.Parse (e.Data);
        //Thread.Sleep(3000);
        //ws.CloseAsync();
    }

    private void OnCloseHandler(object sender, CloseEventArgs e) {
        Debug.Log("WebSocket closed with reason: " + e.Reason);
    }

    private void OnSendComplete(bool success) {
        Debug.Log("Message sent successfully? " + success);
    }
}
