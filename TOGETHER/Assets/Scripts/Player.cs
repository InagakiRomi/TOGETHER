using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Move
    public float mouseSensitivity = 2.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private float verticalRotation = 0f;
    private CharacterController characterController;

    //CameraEye
    Ray ray; //射線
    public float raylength = 3.0f; //射線最大長度
    RaycastHit hit; //被射線打到的物件

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        MouseRay();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Win");
        }
    }

    void MovePlayer()
    {
        // 控制視角旋轉
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // 限制仰角

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // 控制玩家移動
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 move = transform.TransformDirection(moveDirection);

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        characterController.Move(move * currentSpeed * Time.deltaTime);
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
