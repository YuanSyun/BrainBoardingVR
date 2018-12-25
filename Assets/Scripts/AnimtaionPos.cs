using UnityEngine;
using System.Collections;

public class AnimtaionPos : MonoBehaviour {

    public GameObject[] animation;
    public GameObject camera;
    public float distance = 1f;
    public float height = 0.02f;

    void Start () {
        for(int i=0; i < animation.Length; i++)
        {
            animation[i].transform.position = camera.transform.position + camera.transform.forward * distance+camera.transform.up * height;
        }
    }
	
	void Update () {
        for (int i = 0; i < animation.Length; i++)
        {
            animation[i].transform.position = camera.transform.position + camera.transform.forward * distance + camera.transform.up * height;
        }
    }
}
