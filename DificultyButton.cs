using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager gameManager;

    void Start() 
    {
        _button=GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        gameManager=FindObjectOfType<GameManager>();
    }
    
    void SetDifficulty()
    {
        gameManager.StartGmae();
    }

}