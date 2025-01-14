using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class FirstCamera : MonoBehaviour
{
    private Vector3 offset;
    private NetworkRunner networkRunner;
    public Transform target;
    public float sensitivity = 1.0f; // 控制視角靈敏度
    public Transform playerBody; // 用於旋轉角色身體的變換
    //public Transform player; // 玩家的Transform
    private IEnumerator FindPlayer()
    {
        while (target == null)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                NetworkObject networkObject = player.GetComponent<NetworkObject>();

                if (networkObject != null && networkObject.InputAuthority == networkRunner.LocalPlayer)
                {
                    target = player.transform;
                    break;
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private float rotationX = 0;
    private float rotationY = 0;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "FPS") // 指定場景的名稱
        {
            Cursor.lockState = CursorLockMode.Locked; 
            networkRunner = FindObjectOfType<NetworkRunner>();
            StartCoroutine(FindPlayer());
            // 鎖定滑鼠游標到遊戲視窗內
            //offset = transform.position - playerBody.transform.position;
            //transform.localRotation = Quaternion.identity;
            //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            // 在其他場景中禁用這些功能
            // 例如：playerObject.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        // 偵測是否按住滑鼠右鍵（您可以更改成其他按鍵）
        //if (Input.GetMouseButton(1))
        //{
            if (target == null)
            {
                return;
            }

            // 獲取滑鼠輸入
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // 根據滑鼠輸入旋轉視角攝像機
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -30f, 30f); // 限制上下旋轉的角度
            rotationY -=mouseX;
            transform.localRotation = Quaternion.Euler(rotationX, 1, 0); // 上下旋轉
            playerBody.Rotate(Vector3.up * mouseX*1); // 左右旋轉
        //}
    }
  
}