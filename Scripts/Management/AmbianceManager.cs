using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceManager : MonoBehaviour
{
    [SerializeField] private Material[] skyboxMaterials;

    private void Awake()
    {
        int level = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue);
        RenderSettings.skybox = skyboxMaterials[level / 3 % skyboxMaterials.Length];
    }
}
