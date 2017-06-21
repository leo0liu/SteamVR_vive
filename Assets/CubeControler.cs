using UnityEngine;
using System.Collections;
using UnityEditor;


//处理具体的某个与左手相关的功能模块   (这里是扣动扳机生成墙体)
public class CubeControler : MonoBehaviour {

    SteamVR_Controller.Device leftHandDevice; //左手设备
    GameObject target;//砖块预制体
    int height = 6;
    int width =6;

	void Start () {

        leftHandDevice = GameMgr.Instance.GetDevice(GameMgr.DEVICE.LEFT);
        target = transform.Find("cube").gameObject;

	}
	
	void Update () {

        if (leftHandDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("扣动了扳机!");
            for (int i=0;i<width;i++)
            {
                for (int j=0;j<height;j++)
                {
                    Vector3 pos = new Vector3(i,j,0);
                    Instantiate(target,pos,Quaternion.identity);
                }
            }
        }

	}
}
