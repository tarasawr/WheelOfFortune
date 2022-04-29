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
        Data data = SaveSystem.GetInstance().Data;

        int common = current + data.CommonCount;

        CommonText.text = common.KiloFormat();
        CurrentText.text = current.KiloFormat();

        data.CommonCount = common;
        data.IsFirstOpen = false;
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