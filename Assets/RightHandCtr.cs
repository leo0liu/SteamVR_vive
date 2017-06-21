using UnityEngine;
using System.Collections;

public class RightHandCtr : MonoBehaviour {

    SteamVR_Controller.Device rightDevice;

    LineRenderer Line; //射线
    GameObject bullet; //子弹
    float speed = 10000; //速度

	void Start () {
        rightDevice = GameMgr.Instance.GetDevice(GameMgr.DEVICE.RIGHT);
        Line = transform.Find("line").GetComponent<LineRenderer>();
        bullet = transform.Find("bullet").gameObject;

	}
	
	void Update () {
        Ray ray = new Ray(GameMgr.Instance.RightHandLinePos.position,GameMgr.Instance.RightHandLinePos.forward);
        Line.SetPosition(0,ray.origin);  //绘制的起点 是射线的起点
        Line.SetPosition(1,ray.direction*100); //射线方向的*100

        //射击
        if (rightDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Vector3 dir = ray.direction;//获取射线方向
            dir = dir.normalized;//归一化
            GameObject tempBullet = Instantiate(bullet,GameMgr.Instance.RightHandLinePos.position,Quaternion.identity)as GameObject;
            tempBullet.GetComponent<Rigidbody>().AddForce(dir*speed);
            Destroy(tempBullet,3f);

        }


	}
}
