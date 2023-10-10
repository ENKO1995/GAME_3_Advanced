using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    Vector3 offset;
    public Color Low;
    public Color High;
   

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }


    public void SetBattery (float _currentBattery, float _maxBattery)
    {
        slider.gameObject.SetActive(_currentBattery < _maxBattery);
        slider.value = _currentBattery;
        slider.maxValue = _maxBattery;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
        
    }
}
