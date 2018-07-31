using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 音频管理，内部以一个字典作为核心
/// </summary>
public class AudioManagement : MonoBehaviour{
    public List<AudioClip> audioSources = new List<AudioClip>();
    private Dictionary<string, AudioSource> audios = new Dictionary<string, AudioSource>();

    public Dictionary<string, AudioSource> Audios {
        get {
            return audios;
        }

        set {
            audios = value;
        }
    }

    private void Awake() {
        foreach (AudioClip audioClip in audioSources) {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.playOnAwake = false;
            audios.Add(audioClip.name,audioSource);
        }
    }
}

