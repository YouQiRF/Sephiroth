using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SummonerManager : MonoBehaviour
{
    [SerializeField] public FettleGeneric _summonerFettle;
    [SerializeField] public float nowRound;

    // Start is called before the first frame update
    private void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    private void Update()
    {
        OnTick();
    }

    public virtual void OnTick()
    {
        
    }

    public virtual void OnStart()
    {
        
    }

    public virtual void OnSummoner()
    {
        
    }

    public void GetNowRound()
    {
        var roundNumber = FindObjectOfType<PointerManager>();
        nowRound = roundNumber.NowRound;
    }


}
