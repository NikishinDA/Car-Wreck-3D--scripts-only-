using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAmbianceManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] roadRenderers;
    [SerializeField] private Material[] roadMaterials;

    private void Awake()
    {
        int level = PlayerPrefs.GetInt(PlayerPrefsStrings.Level.Name, PlayerPrefsStrings.Level.DefaultValue);
        foreach (var roadRenderer in roadRenderers)
        {
            Material[] mats = roadRenderer.materials;
            mats[2] = roadMaterials[level % roadMaterials.Length];
            roadRenderer.materials = mats;
        }
    }
}
