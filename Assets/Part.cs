using UnityEngine;
using UnityEngine.UI;

public class Part : MonoBehaviour
{
    private int _value;
    public Text Display => GetComponent<Text>();

    public int Value
    {
        get { return _value; }
        set { Display.text = value.ToString(); }
    }
}