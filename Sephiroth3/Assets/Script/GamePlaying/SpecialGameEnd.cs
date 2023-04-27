using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGameEnd : MonoBehaviour
{
    private bool SpaceExit;

    [SerializeField] public GameObject ChooseSummonerObj;

    private void Awake()
    {
        ChooseSummonerObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceExit && Input.GetKeyDown(KeyCode.Space))
        {
            map_time.is_map_time = true;
        }
    }

    public void RestEnd()
    {
        SpaceExit = true;
    }
}
