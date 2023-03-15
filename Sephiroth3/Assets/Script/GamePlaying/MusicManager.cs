using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Instance
    static public MusicManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] public AudioSource DefenseAudio;
    [SerializeField] public AudioSource HealAudio;
    [SerializeField] public AudioSource AttackAudio;

    public void PlayDefense()
    {
        DefenseAudio.Play();
    }

    public void PlayHeal()
    {
        HealAudio.Play();
    }

    public void PlayHit()
    {
        AttackAudio.Play();
    }
}
