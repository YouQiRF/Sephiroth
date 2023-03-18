using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioVal : MonoBehaviour
{
    public static float Sound_Val = 1;
    public Scrollbar bar;
    void Start()
    {
        bar.value= Sound_Val;
    }
    void Update()
    {
        Sound_Val = bar.value;
    }
}
