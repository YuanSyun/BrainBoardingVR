using UnityEngine;
using System.Collections;

public class win : MonoBehaviour {

    public GameObject boat;
    public GameObject canvas;
    private UIcontrol UIscript;
    private bool winornot=false;
	void Start () {
        UIscript = canvas.GetComponent<UIcontrol>();
	}
	
	void Update () {
        float distance = Vector3.Distance(this.transform.position, boat.transform.position);
        //Debug.Log("distance: " + distance);

        if (distance < 1.2f && winornot==false)
        {
            winornot = true;
            UIscript.win = true;
        }

        if (UIscript.UI_panel[1].activeInHierarchy)
        {
            winornot = false;
        }
	}
}
