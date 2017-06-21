using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour {

    static GameMgr Inst;
    public static GameMgr Instance
    {
        get
        {
            return Inst;
        }
    }

   private void Awake()
    {
        Inst = this;
    }

    const string CameraRigTag   = "[CameraRig]";
    GameObject CameraRig;
    SteamVR_TrackedObject leftHand;//左手 (追踪器)
    SteamVR_TrackedObject rightHand;//右手
    SteamVR_Controller.Device Cur_device = null; //当前设备对象

    public SteamVR_Controller.Device cur_dev
    {
        get
        {
            return Cur_device;
        }
    }

    public Transform RightHandLinePos; //射线起点

    void InstDate()
    {
        CameraRig = GameObject.FindGameObjectWithTag(CameraRigTag);
        leftHand = CameraRig.transform.Find("Controller (left)").GetComponent<SteamVR_TrackedObject>();
        rightHand = CameraRig.transform.Find("Controller (right)").GetComponent<SteamVR_TrackedObject>();
        RightHandLinePos = rightHand.transform.Find("LinePos");
            //LinePos

    }

    //对外获取设备的方法
    public SteamVR_Controller.Device GetDevice(DEVICE device)
    {
        switch (device)
        {
            case DEVICE.LEFT:Cur_device = SteamVR_Controller.Input((int)leftHand.index);   break;

            case DEVICE.RIGHT: Cur_device = SteamVR_Controller.Input((int)rightHand.index); break;
        }
        return Cur_device;
    }
    public enum DEVICE
    {
        LEFT=1,
        RIGHT
    }

    CubeControler cubeCtr;
    RightHandCtr rightHandCtr;
     void AddCtrScr()
    {
        cubeCtr = transform.Find("CubeCtr").gameObject.AddComponent<CubeControler>();
        rightHandCtr = transform.Find("rightHandCtr").gameObject.AddComponent<RightHandCtr>();
    }

    void Start () {
        Invoke( "AddCtrScr" , 3f);
	}
	
	void Update () {
	
	}
}
