using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public float startValue;
    public float maxValue;
    public float minValue;
    public Text text;
    public Image progressBar;
    private float _currentValue;

    void Start()
    {
        _currentValue = Mathf.Clamp(startValue, minValue, maxValue);
        updateUI();
    }

    void Update()
    {

    }

    public void subtract(float damage)
    {
        _currentValue = Mathf.Clamp(_currentValue - damage, minValue, maxValue);
        updateUI();
    }

    public void add(float addedHealth)
    {
        _currentValue = Mathf.Clamp(_currentValue + addedHealth, minValue, maxValue);
        updateUI();
    }

    public void setValue(float newHealth, bool shouldUpdateUI = true)
    {
        _currentValue = Mathf.Clamp(_currentValue, minValue, maxValue);
        if (shouldUpdateUI) updateUI();
    }

    private void updateUI()
    {
        text.text = _currentValue + "/" + maxValue;
        progressBar.fillAmount = _currentValue / maxValue;
    }
}
