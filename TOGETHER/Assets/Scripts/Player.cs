using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //CameraEye
    Ray ray; //射線
    public float raylength = 3.0f; //射線最大長度
    RaycastHit hit; //被射線打到的物件

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MouseRay();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Win");
        }
    }

    void MouseRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            //由攝影機射到是畫面正中央的射線

            if (Physics.Raycast(ray, out hit, raylength))
            // (射線,out 被射線打到的物件,射線長度)，out hit 意思是：把"被射線打到的物件"帶給hit
            {
                hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
                //向被射線打到的物件呼叫名為"HitByRaycast"的方法，不需要傳回覆                   
            }
        }
    }
}
