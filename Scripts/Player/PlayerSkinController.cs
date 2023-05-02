using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    [SerializeField] private Transform parentTransform;

    private void Awake()
    {
        int skinNum =
            PlayerPrefs.GetInt(PlayerPrefsStrings.SkinNumber.Name, PlayerPrefsStrings.SkinNumber.DefaultValue);
        Instantiate(skins[skinNum], parentTransform);
    }
}
