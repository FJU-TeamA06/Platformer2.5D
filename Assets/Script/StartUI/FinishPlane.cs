using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fusion;
using Fusion.Sockets;

public class FinishPlane : MonoBehaviour
{
    private Vector3 spawnPosition = Vector3.zero;
    public GameObject finishPanel;
    //public Vector3 teleportDestination; // 設定要傳送到的目標位置
    public BasicSpawner basicSpawner;
    public NetworkCharacterControllerPrototype networkCharacterController;

    void Awake()
    {
        basicSpawner = FindObjectOfType<BasicSpawner>(); // 取得 BasicSpawner 的實例
    }

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        finishPanel.SetActive(false);
    }

    public void FinishClick()
    {
        Vector3 spawnPosition = basicSpawner.GetSpawnPosition(basicSpawner.levelIndex, basicSpawner.playerNumber);
        finishPanel.SetActive(true);
        if (basicSpawner.levelIndex == 3)
        {
            StartCoroutine(DeactivateAfterDelay(3.0f)); // 啟動協程等待5秒後關閉面板
        }
        else
        {
            //StartCoroutine(DeactivateAfterDelay(3.0f)); // 啟動協程等待5秒後關閉面板
        }

    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的秒數

        finishPanel.SetActive(false); // 關閉面板

        /*basicSpawner.levelIndex = 3;
        Vector3 spawnPosition = basicSpawner.GetSpawnPosition(basicSpawner.levelIndex, basicSpawner.playerNumber);
        
        // 檢查是否設定了傳送目標位置
        if (spawnPosition != Vector3.zero) // 檢查是否成功獲取重生位置
        {
            networkCharacterController.transform.position = spawnPosition;
            
        }*/
        /*if (teleportDestination != null)
        {
            // 獲取所有擁有"Player"標籤的物體
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                // 將玩家傳送到指定位置
                player.transform.position = teleportDestination.position;
            }
        }*/
    }
}
