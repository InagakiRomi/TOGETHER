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
    Ray ray; //�g�u
    public float raylength = 3.0f; //�g�u�̤j����
    RaycastHit hit; //�Q�g�u���쪺����

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
        // �����������
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // �������

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // ����a����
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
