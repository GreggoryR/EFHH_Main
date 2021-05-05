using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManagerSnapshots : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixerSnapshot master;
    [SerializeField] AudioMixerSnapshot basement;
    [SerializeField] AudioMixerSnapshot ending;
    [SerializeField] AudioMixerSnapshot intro;
    public enum AudioSetting { intro, master, basement, ending};
    [SerializeField] public AudioSetting audioMixerSetting;

    private void Start()
    {
        switch (audioMixerSetting)
        {
            case AudioSetting.master:
                master.TransitionTo(0.1f);
                break;
            case AudioSetting.basement:
                basement.TransitionTo(0.1f);
                break;
            case AudioSetting.ending:
                ending.TransitionTo(0.1f);
                break;
            case AudioSetting.intro:
                intro.TransitionTo(0.1f);
                break;
            default:
                break;
        }
       
    }
}
