using UnityEngine;
using System.Collections;

public class padalControl : MonoBehaviour {

    public GameObject handle_node, padal_node;

	void Start () {
	    
	}
	

	void Update () {
        this.transform.forward = padal_node.transform.position - handle_node.transform.position;
        this.transform.position = padal_node.transform.position + padal_node.transform.position - handle_node.transform.position;

    }
}
