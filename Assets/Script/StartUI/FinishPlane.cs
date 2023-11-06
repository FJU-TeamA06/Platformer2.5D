using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fusion;
using Fusion.Sockets;

public class FinishPlane : MonoBehaviour
{

    public GameObject finishPanel;

    void Awake()
    {
        
    }

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        finishPanel.SetActive(false);
    }
    public void Finish3Click() //FPS
    {
        finishPanel.SetActive(true);
    }

    public void FinishClick() //level 1 & 2
    {
        finishPanel.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(3.0f)); // �Ұʨ�{����5����������O
    }


    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�����

        finishPanel.SetActive(false); // �������O

    }
}
