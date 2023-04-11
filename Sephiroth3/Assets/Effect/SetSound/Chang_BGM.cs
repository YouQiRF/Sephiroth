using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chang_BGM : MonoBehaviour
{
    [Header("BGM編號")]
    [SerializeField] public int BGM_Num;
    // Start is called before the first frame update
    void Start()
    {
        chang(BGM_Num);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void chang(int a)
    {
        SetAudio.audioNum = a;
        if (Map_System.Boss_map)
        {
            SetAudio.audioNum = 2;
        }
        SetAudio.play_BGM = true;
    }
}
