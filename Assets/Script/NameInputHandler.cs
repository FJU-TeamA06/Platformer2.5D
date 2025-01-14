﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using Fusion.Sockets;

public class NameInputHandler : MonoBehaviour
{
    public InputField nameInputField;
    public Button okButton;
    private string playerName = "";
    public BasicSpawner basicSpawner;
    public GameMode gameMode;
    public GameObject sessionInput;
    public GameObject loadingOverlay;
    public GameObject levelSelectionPanel; // 添加一个新的游戏对象，用于显示关卡选择界面
    public GameObject nameInputPanel; // 添加一个新的游戏对象，用于表示名字输入面板

    void Start()
    {
        okButton.onClick.AddListener(OnOkButtonClick);
        nameInputField.text=PlayerPrefs.GetString("PlayerName");
    }

    void OnOkButtonClick()
    {
        playerName = nameInputField.text;
        Debug.Log("玩家名字: " + playerName);
        PlayerPrefs.SetString("PlayerName", nameInputField.text);
        sessionInput.SetActive(true); 
        nameInputPanel.SetActive(false); // 隐藏名字输入面板
        // 将下面这行代码移动到新的方法中，当用户选择关卡后才开始游戏
        // basicSpawner.StartGame(basicSpawner.gameMode);
    }

    // 创建一个新方法，在用户选择关卡后开始游戏
    public void StartGameAfterLevelSelection(int selectedLevel,int PlayerNum)
    {
        // 在这里设置关卡信息，您可以根据需要进行修改
        basicSpawner.StartGame(basicSpawner.gameMode, selectedLevel,PlayerNum);
        loadingOverlay.SetActive(true);
        Destroy(gameObject);
    }
}
