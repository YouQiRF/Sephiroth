using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_sound : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("設定音效物件")]
    [SerializeField] public AudioSource Sound_Audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sound_Audio.volume = SetAudioVal.Sound_Val;
    }
}
