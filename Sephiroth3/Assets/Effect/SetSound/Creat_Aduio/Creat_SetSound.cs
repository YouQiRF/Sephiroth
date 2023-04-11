using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_SetSound : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("設定生成")]
    [SerializeField] public GameObject SetBGM;
    static bool is_set = true;
    void Start()
    {
        if (is_set)
        {
            Instantiate(SetBGM);
            is_set = false;
        }

    }
}
