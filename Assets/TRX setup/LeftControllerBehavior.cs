using UnityEngine;
using System.Collections;

public class LeftControllerBehavior : MonoBehaviour {

	public float distance_short ;
	public float distance_medium ;

	private bool collide;
	private Vector3 sphere_pos;
	public LineArcSystem rubberbandLine;
	public static LeftControllerBehavior InstanceLeft; 

	int stage = 0;
	public int Leftmoveornot = 0;

	// Use this for initialization
	void Start()
	{
        InstanceLeft = this;
	}

	// Update is called once per frame
	void Update()
	{
		linechange();

		if (collide)
		{
			if (Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) < distance_short)
			{
				rubberbandLine.CreateLine(sphere_pos, transform.position, Color.green);
				stage = 1;
			}
			else if (Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) > distance_short && Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) < distance_medium)
			{
				rubberbandLine.CreateLine(sphere_pos, transform.position, Color.blue);
				stage = 2;
			}
			else if (Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) > distance_medium)
			{
				rubberbandLine.CreateLine(sphere_pos, transform.position, Color.red);
			}
			//rubberbandLine.CreateLine(sphere_pos, transform.position, Color.red);
		}


	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Sphere"))
		{
			sphere_pos = other.gameObject.transform.position;
			collide = true;
		}
	}

	public void linechange() {
		if (Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) < distance_short)
		{
            Leftmoveornot = 0;
			stage = 1;
		}
		else if (Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) > distance_short && Mathf.Abs(Vector3.Distance(sphere_pos, transform.position)) < distance_medium && stage==1)
		{
            Leftmoveornot = 1;
			stage = 2;
		}
	}
}
