using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //CameraEye
    Ray ray; //�g�u
    public float raylength = 3.0f; //�g�u�̤j����
    RaycastHit hit; //�Q�g�u���쪺����

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
            //����v���g��O�e�����������g�u

            if (Physics.Raycast(ray, out hit, raylength))
            // (�g�u,out �Q�g�u���쪺����,�g�u����)�Aout hit �N��O�G��"�Q�g�u���쪺����"�a��hit
            {
                hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
                //�V�Q�g�u���쪺����I�s�W��"HitByRaycast"����k�A���ݭn�Ǧ^��                   
            }
        }
    }
}
