using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSkinController : MonoBehaviour
{
    [SerializeField] private Image pbBackground;
    [SerializeField] private Image pbImage;
    [SerializeField] private Sprite[] skinsBackgrounds;
    [SerializeField] private Sprite[] skinsSprites;
    private int _skinNumber;
    [SerializeField] private float progressPerLevel;
    [SerializeField] private Text percentsText;

    private void Awake()
    {
        _skinNumber = PlayerPrefs.GetInt(PlayerPrefsStrings.SkinNumber.Name, PlayerPrefsStrings.SkinNumber.DefaultValue);
        pbBackground.sprite = skinsBackgrounds[_skinNumber];
        pbImage.sprite = skinsSprites[_skinNumber];
    }

    private void Start()
    {
        StartCoroutine(SkinProgress(1f, 3f));
    }

    private  IEnumerator SkinProgress(float waitTime, float time)
    {        

        float weaponProgress = PlayerPrefs.GetFloat(PlayerPrefsStrings.SkinProgress.Name,
            PlayerPrefsStrings.SkinProgress.DefaultValue);
        float endProgress = weaponProgress + progressPerLevel;
        if (endProgress >= 1)
        {
            endProgress = 1;
            PlayerPrefs.SetFloat(PlayerPrefsStrings.SkinProgress.Name, 0);
            _skinNumber++;
            _skinNumber %= skinsSprites.Length;
            PlayerPrefs.SetInt(PlayerPrefsStrings.SkinNumber.Name, _skinNumber);
        }
        else
        {
            PlayerPrefs.SetFloat(PlayerPrefsStrings.SkinProgress.Name, endProgress);
        }

        pbImage.fillAmount = weaponProgress;
        percentsText.text = (weaponProgress * 100).ToString("N0") + "%";
        yield return new WaitForSeconds(waitTime);
        float progress;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            progress = Mathf.Lerp(weaponProgress, endProgress, t / time);
            pbImage.fillAmount = progress;
            percentsText.text = (progress * 100).ToString("N0") + "%";
            yield return null;
        }
    }
}
