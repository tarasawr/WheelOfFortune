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
    public List<AnimationCurve> AnimCurves;
    
    public int _PlayerInitialWin;
    public int _PlayerMultiplier;

    private float _anglePerItem = 20;
    private bool _isSpin;

    void Start()
    {
        Count.text = SaveSystem.Data.Count.ToString();
        CommonCount.text = SaveSystem.Data.CommonCount.ToString();
        
        _isSpin = false;
        Spin.interactable = true;
    }

    public void StartSpin()
    {
        if (!_isSpin) StartCoroutine(Spining());
    }

    private IEnumerator Spining()
    {
        Count.text = "0";
        CommonCount.text = "0";
        _isSpin = true;
        Spin.interactable = !_isSpin;

        int randomTime = Random.Range(1, 4);
        int itemNumber = 0;

        for (int i = 0; i < prize.Count; i++)
            if (prize[i] == _PlayerMultiplier)
                itemNumber = i;


        float maxAngle = 360 * randomTime + (itemNumber * _anglePerItem);
        float timer = 0.0f;
        float startAngle = CircleGo.transform.eulerAngles.z;

        maxAngle = maxAngle - startAngle;
        int animationCurveNumber = Random.Range(0, AnimCurves.Count);

        while (timer < 5 * randomTime)
        {
            float angle = maxAngle * AnimCurves[animationCurveNumber].Evaluate(timer / (randomTime * 5));
            CircleGo.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        CircleGo.transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);

        CommonCount.text = _PlayerMultiplier.ToString();
        Debug.Log("Prize: " + prize[itemNumber]);
        
        _isSpin = false;
        Spin.interactable = true;
        StartCoroutine(IncValue());
    }
    

    private IEnumerator IncValue()
    {
        yield return new WaitForSeconds(1);
        int prize = _PlayerInitialWin * _PlayerMultiplier;
        float cuvalue = 0;
        float duration = 3; //2 seconds
        float speed = prize / (30 * duration);
        float incvalue = speed; // * Time.deltaTime;
        while (cuvalue + incvalue < prize)
        {
            yield return null;
            cuvalue += incvalue;
            Count.text = cuvalue.ToString();
        }

        cuvalue = prize;
        Count.text = cuvalue.ToString();
    }

    private void OnApplicationQuit()
    {
        SaveSystem.Save();
    }
}