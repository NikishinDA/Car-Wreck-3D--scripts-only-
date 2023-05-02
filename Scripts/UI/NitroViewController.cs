using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroViewController : MonoBehaviour
{
    [SerializeField] private PlayerPropertiesManager propertiesManager;
    [SerializeField] private Image fill;
    
    [SerializeField] private float changeSpeed = 10f;
    private void Update()
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, propertiesManager.NitroAll, changeSpeed * Time.unscaledDeltaTime);
    }
}
