using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarDecline : MonoBehaviour
{
    public float IntervalInSeconds;
    private UIBar _energyBar;

    void Start()
    {
        _energyBar = GameObject.Find("EnergyBar").GetComponent<UIBar>();
        StartCoroutine(RRemoveEnergy());
    }

    void Update()
    {

    }

    private IEnumerator RRemoveEnergy()
    {
        yield return new WaitForSeconds(IntervalInSeconds);

        while (true)
        {
            _energyBar.subtract(1f);
            yield return new WaitForSeconds(IntervalInSeconds);
        }
    }
}
