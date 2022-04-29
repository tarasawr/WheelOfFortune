using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Text CommonText;
    public Text CurrentText;


    private void Start()
    {
        CommonText.text = SaveSystem.GetInstance().Data.CommonCount.KiloFormat();
    }

    public void RefreshData(int current)
    {
        int common = current + SaveSystem.GetInstance().Data.CommonCount;

        CommonText.text = common.KiloFormat();
        CurrentText.text = current.KiloFormat();

        SaveSystem.GetInstance().Data.CommonCount = common;
    }

    private void OnApplicationQuit()
    {
        SaveSystem.GetInstance().SaveData();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        SaveSystem.GetInstance().SaveData();
    }
}