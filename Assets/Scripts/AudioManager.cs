using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject posSFX;
    public Slider getVolume;
    public Slider getVolumeBgr;
    public TextMeshProUGUI soundNameBgr;
    public static AudioManager Instance;
    [Header("Audio")]
    public List<AudioClip> listSoundBgrs = new List<AudioClip>();
    public AudioClip soundLevelUp;
    public AudioClip soundHit_1;
    public AudioClip soundHit_2;
    public AudioClip soundDead;
    public AudioClip soundSelect;
    public AudioClip spundFire;

    private int indexSoundBgr = 0;
    private AudioSource sourceBgr;

    [Header("Setting")]
    public float volume;
    public float volumeBgr;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        volume = 0.1f;
        volumeBgr = 0.2f;
        getVolume.value = volume;
        getVolumeBgr.value = volumeBgr;
        PlaySFXBgr();
    }

    private void Update()
    {
        if (getVolume == null) return;
        volume = getVolume.value;
    }

    public void ChangeBackgroundMusic()
    {
        if (sourceBgr == null) return;
        indexSoundBgr++;
        if (indexSoundBgr >= listSoundBgrs.Count)
        {
            indexSoundBgr = 0;
        }
        SetClipToSourceBgr();
    }
    private void PlaySFXBgr()
    {
        GameObject sfx = new GameObject();
        sfx.transform.position = posSFX.transform.position;
        sfx.name = "Background Music";
        sourceBgr = sfx.AddComponent<AudioSource>();
        SetClipToSourceBgr();
    }

    private void SetClipToSourceBgr()
    {
        sourceBgr.clip = listSoundBgrs[indexSoundBgr];
        soundNameBgr.text = listSoundBgrs[indexSoundBgr].name;
        sourceBgr.volume = volumeBgr;
        sourceBgr.Play();
        sourceBgr.loop = true;
    }

    public void SetBackgroundMusicVolume()
    {
        if (sourceBgr == null) return;
        volumeBgr = getVolumeBgr.value;
        sourceBgr.volume = volumeBgr;
    }

    public void PlaySFXLevelUp()
    {
        PlaySFX(soundLevelUp);
    }
    public void PlaySFXDead()
    {
        PlaySFX(soundDead);
    }
    public void PlaySFXSelect()
    {
        PlaySFX(soundSelect);
    }
    public void PlaySFXFire()
    {
        PlaySFX(spundFire);
    }
    public void PlaySFXHit()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            PlaySFX(soundHit_1);
        } else
        {
            PlaySFX(soundHit_2);
        }
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        if (GameManager.Instance.isPaused) return;

        GameObject sfx = new GameObject();
        sfx.transform.position = posSFX.transform.position;
        sfx.name = clip.name;
        AudioSource source = sfx.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();

        Destroy(sfx, clip.length);
    }


}
