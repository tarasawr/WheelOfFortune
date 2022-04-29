using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WheelOfFortune : MonoBehaviour
{
    public Text CommonCount;
    public Text Count;
    public Button Spin;
    public GameObject CircleGo;

    public List<int> prize;
    public List<Part> PartsList;
    public List<AnimationCurve> AnimCurves;

    public int _PlayerMultiplier;

    private float _anglePart;
    private bool _isSpin;
    private int[] _partValues = {10, 100, 1000, 10000};

    void Start()
    {
        //Count.text = SaveSystem.GetInstance().Data.Count.ToString();
        //CommonCount.text = SaveSystem.GetInstance().Data.CommonCount.ToString();
        InitWheel();
    }

    private void InitWheel()
    {
        _isSpin = false;
        Spin.interactable = true;
        
        _anglePart = 360f / PartsList.Count;
        
        foreach (Part part in PartsList) 
            part.Value = _partValues[Random.Range(0, _partValues.Length)];
        
        CircleGo.transform.eulerAngles = Vector3.zero;
    }

    public void StartSpin()
    {
        Count.text = "0";
        CommonCount.text = "0";
        
        if (!_isSpin) StartCoroutine(Spining());
    }

    private IEnumerator Spining()
    {
        _isSpin = true;
        Spin.interactable = !_isSpin;

        int randomTime = Random.Range(1, 4);
        
        float maxAngle = 360 * randomTime + (PartsList.Count * _anglePart);
        float timer = 0.0f;
        float startAngle = CircleGo.transform.eulerAngles.z;

        maxAngle = maxAngle - startAngle;
        int indexAnimCurv = Random.Range(0, AnimCurves.Count);
        
        while (timer < 5 * randomTime)
        {
            float angle = maxAngle * AnimCurves[indexAnimCurv].Evaluate(timer / (randomTime * 5));
            Debug.Log(angle);
            CircleGo.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }
        
        //Debug.Log("Prize: " + prize[itemNumber]);

        _isSpin = false;
        Spin.interactable = true;
    }


    private void OnApplicationQuit()
    {
        //SaveSystem.GetInstance().Save();
    }
}