using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        SoundManager.Play("Menu");
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