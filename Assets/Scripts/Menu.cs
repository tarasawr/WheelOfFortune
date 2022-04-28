using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        SoundManager.Play("menu");
    }

    public void StartButton_OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnEnable() { SaveSystem.Load(); }
}