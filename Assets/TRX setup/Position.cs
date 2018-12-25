using UnityEngine;
using System.Collections;



public class Position : MonoBehaviour
{

    uint lt = 0;
    int rt = 0;



    public GameObject lighthouse;


    private SteamVR_Controller.Device rtController { get { return SteamVR_Controller.Input((int)rt); } }

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    public void OnEnable()
    {
        //SteamVR_Utils.Event.Listen("device_connected", OnDeviceConnected);
    }
    public void OnDisable()
    {
        //SteamVR_Utils.Event.Remove("device_connected", OnDeviceConnected);
    }

    private void OnDeviceConnected(params object[] args)
    {
        var i = (int)args[0];
        bool connected = (bool)args[1];
        var vr = SteamVR.instance;
        if (connected)
        {
            if (vr.hmd.GetTrackedDeviceClass((uint)i) == Valve.VR.ETrackedDeviceClass.Controller)
            {
                if (rt == 0)
                {
                    rt = (int)i;
                    Debug.Log("rt = " + rt);
                }
            }
        }


    }


    // Use this for initialization
    void Start()
    {
        Debug.Log("Controller is " + rtController.index.ToString());
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        


    }

    void Update()
    {
        if (lighthouse.GetComponent<SteamVR_TrackedObject>().isValid)
        {
            Vector3 pos = lighthouse.GetComponent<SteamVR_TrackedObject>().transform.InverseTransformPoint(trackedObj.transform.position);
            print(pos.ToString("F3"));
        }
    }

    }