using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text PreviewText;
    
    public void Start()
    {
        SoundManager.Play("Menu");
        if (SaveSystem.GetInstance().Data.IsFirstOpen)
        {
            PreviewText.text = " You Are Welcome"+Environment.NewLine +"This is your first entry ";
        }
        else
        {
            PreviewText.text = " You old score " + SaveSystem.GetInstance().Data.CommonCount+" гривен";
        }
        
    }

    public void StartButton_OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnEnable()
    {
        SaveSystem.GetInstance().LoadData();
    }
}