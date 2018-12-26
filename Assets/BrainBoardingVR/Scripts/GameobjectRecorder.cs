
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor.Experimental.Animations;

public class GameobjectRecorder : MonoBehaviour {

	public AnimationClip clip;

	public bool record = false;

	private GameObjectRecorder _MyRecorder;

	// Use this for initialization
	void Start () {
		

		_MyRecorder = new GameObjectRecorder();
		_MyRecorder.root = gameObject;

		_MyRecorder.BindComponent<Transform>(gameObject, true);

		Debug.Log("record gameobject name: " + gameObject.name);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		if(clip == null)
			return;

		if(record){
			Debug.Log("start record");
			_MyRecorder.TakeSnapshot(Time.deltaTime);
		}else{
			if(_MyRecorder.isRecording){
				Debug.Log("end record");
				_MyRecorder.SaveToClip(clip);
				_MyRecorder.ResetRecording();
			}
		}

	}

	public void StartRecording(){
		record = true;
	}

	public void StopRecording(){
		record = false;
	}
}
