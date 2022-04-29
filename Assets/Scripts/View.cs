using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
   public Text CommonText;
   public Text CurrentText;


   private void Start()
   {
      //Init Saver
      //CommonText.text = SaveSystem.GetInstance().Data
      //CurrentText.text = data.Currrent.ToString();
   }

   public void RefreshData(Data data)
   {
      CommonText.text = data.CommonCount.ToString();
      CurrentText.text = data.Currrent.ToString();
   }

   private void OnApplicationQuit()
   {
      //Save data
   }

   private void OnApplicationPause(bool pauseStatus)
   {
      
   }

   private void OnApplicationFocus(bool hasFocus)
   {
      
   }
}
