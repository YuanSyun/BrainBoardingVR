using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float reversethrust = 30f;
    public float thrust = 100f;
    public int hadmove = 0;
    public GameObject boat;
    public GameObject PlayerSpawnPoint;
    public GameObject reversArea;
    public float reverseRange = 3f;
    public GameObject rockArea;
    float rotation = 0.0f;

    public GameObject gamestartObj;
    private UIcontrol gamestartScript;

    //public static PlayerControl Instance2;
    // Use this for initialization
    void Start () {
        //Instance2 = this;
        gamestartScript = gamestartObj.GetComponent<UIcontrol>();
    }
	
	// Update is called once per frame
	void Update () {

        if (gamestartScript.UI_panel[2].activeInHierarchy)
        {
            // sync boat rotation & position
            boat.transform.position = this.transform.position;
            boat.transform.rotation = this.transform.rotation;
            boat.transform.Rotate(new Vector3(0, 1, 0), -90);
            boat.transform.Rotate(new Vector3(1, 0, 0), 270);

            gameObject.GetComponent<Rigidbody>().AddForce(this.transform.right * -1 * thrust);

            reverse();


            //print(LeftControllerBehavior.InstanceLeft.Leftmoveornot);
            //print(RightControllerBehavior.InstanceRight.Rightmoveornot);

            //gameObject.GetComponent<Rigidbody>().AddForce(this.transform.right*-1*thrust);

            //if (LeftControllerBehavior.InstanceLeft.Leftmoveornot == 1 && RightControllerBehavior.InstanceRight.Rightmoveornot == 1)
            //{
            //    gameObject.GetComponent<Rigidbody>().AddForce(this.transform.right * -1 * thrust);

            //}
            //else if (LeftControllerBehavior.InstanceLeft.Leftmoveornot == 1 && RightControllerBehavior.InstanceRight.Rightmoveornot == 0)
            //{
            //    transform.Rotate(new Vector3(0.0f, rotation - 0.03f, 0.0f));

            //}
            //else if (LeftControllerBehavior.InstanceLeft.Leftmoveornot == 0 && RightControllerBehavior.InstanceRight.Rightmoveornot == 1)
            //{
            //    transform.Rotate(new Vector3(0.0f, rotation + 0.03f, 0.0f));

            //}
        }
        else if(gamestartScript.UI_panel[0].activeInHierarchy || gamestartScript.UI_panel[1].activeInHierarchy)
        {
            this.transform.position = PlayerSpawnPoint.transform.position;
            this.transform.rotation = PlayerSpawnPoint.transform.rotation;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
        }
     
    }

    void reverse()
    {
        reversArea.transform.localScale = new Vector3(reverseRange*2, reverseRange * 2, reverseRange * 2);

        float distance = Vector3.Distance(boat.transform.position, reversArea.transform.position);
        if(distance <= reverseRange)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(this.transform.right  * reversethrust);
        }
    }

}
