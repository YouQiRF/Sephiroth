﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TurntableManager : MonoBehaviour
{
    [Header("物件")]
    [SerializeField] public int SummonState;
    [SerializeField] private float EndPoint;
    [SerializeField] public GameObject[] Summoner;
    [SerializeField] public GameObject[] SummonerTurntable;
    [SerializeField] public GameObject turntable_outerring;
    //[SerializeField] public GameObject[] SummonerTurntable;
    [Header("Offset")]
    [SerializeField] private Vector3 SummonerOffset;
    [SerializeField] private Vector3 TurntableOffset;
    // Start is called before the first frame update
    void Start()
    {
        OnPlayerSummon(0);
        PlayerPrefs.SetInt("NowSummonA",1);
        PlayerPrefs.SetInt("NowSummonB",2);
        SummonerTurntable[0].SetActive(false);
        SummonerTurntable[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            EndPoint -= 25.5f;
        }
        RotatingOuterRing();
    }

    public void SimonCheck()
    {
        
    }

    public void OnPlayerSummon(int ChoseState)
    {
        SummonState = ChoseState;
        int NowSummon = (SummonState == 1) ? PlayerPrefs.GetInt("NowSummonA") : (SummonState == 2) ? PlayerPrefs.GetInt("NowSummonB") : 0;
        Destroy(GameObject.FindWithTag("Summoner"));
        //Destroy(GameObject.FindWithTag("SummonerTurntable"));
        Instantiate(Summoner[NowSummon], this.transform.position - SummonerOffset, new Quaternion(0,0,0,0));
        //Instantiate(SummonerTurntable[NowSummon], this.transform.position, this.transform.rotation);
    }

    private void RotatingOuterRing()
    {
        turntable_outerring.transform.rotation = Quaternion.Lerp(turntable_outerring.transform.rotation, quaternion.Euler(0,0,EndPoint), 0.2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position -SummonerOffset,0.3f);
    }

    /*
    var NowSummoner = GameObject.FindWithTag("Summoner");
    var NowSummonerSkill = GameObject.FindWithTag("SummonerTurntable");
    */
}
