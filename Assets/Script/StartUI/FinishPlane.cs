using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using Fusion.Sockets;

public class FinishPlane : MonoBehaviour
{
    public GameObject finishPanel;
    public Transform teleportDestination; // �]�w�n�ǰe�쪺�ؼЦ�m

    void Start()
    {

    }

    public void FinishClick()
    {
        finishPanel.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(5.0f)); // �Ұʨ�{����5����������O
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�����

        finishPanel.SetActive(false); // �������O

        // �ˬd�O�_�]�w�F�ǰe�ؼЦ�m
        if (teleportDestination != null)
        {
            // ����Ҧ��֦�"Player"���Ҫ�����
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                // �N���a�ǰe����w��m
                player.transform.position = teleportDestination.position;
            }
        }
    }
}
