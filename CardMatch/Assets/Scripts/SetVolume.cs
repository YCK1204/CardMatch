using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            // �����̴��� ���� ���� ����
            masterSlider.value = AudioManager.Instance.GetMasterVolume();
            bgmSlider.value = AudioManager.Instance.GetBgmVolume();
            sfxSlider.value = AudioManager.Instance.GetSfxVolume();

            // �����̴��� ������ ������ AudioManager�� �� ����
            masterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
            bgmSlider.onValueChanged.AddListener(AudioManager.Instance.SetBgmVolume);
            sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
        }
    }
}
