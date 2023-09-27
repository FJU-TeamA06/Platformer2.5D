using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class FirstCamera : MonoBehaviour
{
    private Vector3 offset;
    public float sensitivity = 1.0f; // ��������F�ӫ�
    public Transform playerBody; // �Ω���ਤ�⨭�骺�ܴ�
    //public Transform player; // ���a��Transform

    private float rotationX = 0;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // ��w�ƹ���Ш�C��������
        //offset = transform.position - playerBody.transform.position;
        //transform.localRotation = Quaternion.identity;
        //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        // �����O�_����ƹ��k��]�z�i�H��令��L����^
        if (Input.GetMouseButton(1))
        {
            
            // ����ƹ���J
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // �ھڷƹ���J��������ṳ��
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -30f, 30f); // ����W�U���઺����
            transform.localRotation = Quaternion.Euler(rotationX, 90, 0); // �W�U����
            playerBody.Rotate(Vector3.up * mouseX); // ���k����
        }
    }
  
}