using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using Fusion.Sockets;

public class FinishPlane : MonoBehaviour
{
    public GameObject finishPanel;
    //public Vector3 teleportDestination; // �]�w�n�ǰe�쪺�ؼЦ�m
    public BasicSpawner basicSpawner;
    //public NetworkCharacterControllerPrototype networkCharacterController;

    void Awake()
    {
        basicSpawner = FindObjectOfType<BasicSpawner>(); // ���o BasicSpawner �����
    }

    void Start()
    {

    }

    public void FinishClick()
    {
        finishPanel.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(3.0f)); // �Ұʨ�{����5����������O
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�����

        finishPanel.SetActive(false); // �������O

        /*basicSpawner.levelIndex = 3;
        Vector3 spawnPosition = basicSpawner.GetSpawnPosition(basicSpawner.levelIndex, basicSpawner.playerNumber);
        
        // �ˬd�O�_�]�w�F�ǰe�ؼЦ�m
        if (spawnPosition != Vector3.zero) // �ˬd�O�_���\������ͦ�m
        {
            networkCharacterController.transform.position = spawnPosition;
            
        }*/
        /*if (teleportDestination != null)
        {
            // ����Ҧ��֦�"Player"���Ҫ�����
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                // �N���a�ǰe����w��m
                player.transform.position = teleportDestination.position;
            }
        }*/
    }
}
