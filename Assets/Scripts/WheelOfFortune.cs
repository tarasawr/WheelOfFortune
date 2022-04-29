﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WheelOfFortune : MonoBehaviour
{
    public Button Spin;
    public GameObject CircleGo;

    public List<Part> PartsList;
    public List<AnimationCurve> AnimCurves;

    private float _anglePart;
    private bool _isSpin;
    private int[] _partValues = {10, 100, 1000, 10000};

    void Start()
    {
        InitWheel();
    }

    private void InitWheel()
    {
        _isSpin = false;
        Spin.interactable = true;

        _anglePart = 360f / PartsList.Count;

        for (int i = 0; i < PartsList.Count; i++)
        {
            Part p = PartsList[i];
            p.Value = _partValues[Random.Range(0, _partValues.Length)];
            p.Angle = _anglePart * i;
        }

        CircleGo.transform.eulerAngles = Vector3.zero;
    }

    public void StartSpin()
    {
        if (!_isSpin)
        {
            SoundManager.StopAllSounds();
            SoundManager.Play("spin");
            StartCoroutine(Spining());
        }
    }

    private IEnumerator Spining()
    {
        _isSpin = true;
        Spin.interactable = !_isSpin;

        int randomTime = Random.Range(1, 4);

        //maxAngle - коеф. скорости
        float maxAngle = 360 * randomTime + (PartsList.Count * _anglePart);
        float timer = 0.0f;
        float startAngle = CircleGo.transform.eulerAngles.z;

        maxAngle = maxAngle - startAngle;
        int indexAnimCurv = Random.Range(0, AnimCurves.Count);

        while (timer < 5 * randomTime)
        {
            float angle = maxAngle * AnimCurves[indexAnimCurv].Evaluate(timer / (randomTime * 5));
            CircleGo.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        // относительно угла вычисляем ближайший Part
        float angleStop = CircleGo.transform.eulerAngles.z;
        Part part = PartsList.OrderBy(v => Math.Abs(v.Angle - angleStop)).First();
        Debug.Log(part.Value);

        _isSpin = false;
        Spin.interactable = true;
        SoundManager.StopAllSounds();
    }
}