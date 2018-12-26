using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


public class SteamVRControllerButtonEvents : MonoBehaviour {

	public UnityEvent TriggerClicked;
	public UnityEvent TrggerUnclicked;
	
	private SteamVR_TrackedController _controller;

	// Use this for initialization
	void Start () {
		
		_controller = GetComponent<SteamVR_TrackedController>();

		if (_controller == null) {
			Debug.Log ("not found steamvr tracked controller");
		}

		_controller.TriggerClicked += HandleTriggerClicked;
		_controller.TriggerUnclicked += HandleTriggerUnclicked;


	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void HandleTriggerClicked(object sender, ClickedEventArgs e){
		TriggerClicked.Invoke ();
	}

	private void HandleTriggerUnclicked(object sender, ClickedEventArgs e){
		TrggerUnclicked.Invoke ();
	}


		
}
