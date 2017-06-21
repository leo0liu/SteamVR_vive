using UnityEngine;
using System.Collections;

public class VR : MonoBehaviour {

    SteamVR_TrackedObject trackobj;  //追踪器对象
    SteamVR_Controller.Device device;//设备对象

	void Start () {
        //实例化追踪器对象
        trackobj = transform.GetComponent<SteamVR_TrackedObject>();

        //实例化设备对象
        device = SteamVR_Controller.Input((int)trackobj.index);
	}
	
	void Update () {

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("按下了扳机!");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Axis0))
        {
            Debug.Log("按下了AXIS0!");                                                 
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Axis1))
        {
            Debug.Log("按下了AXIS1!");
        }
    }
}
