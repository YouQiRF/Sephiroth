using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_OwlMinHeal : TurntableGeneric
{
    
    [SerializeField] private int MinNumber;
    public override void OnPointed()
    {
        var HealTarget = FindObjectOfType<LocationManager>();
        var IsDouble = FindObjectOfType<OwlFettle>();
        float HealNumber = IsDouble.DoubleReady == true ? 4 : 2;
        GetCompareNumber();
        HealTarget.PlayerLocation[MinNumber]._hpData.NowHP += HealNumber;
        HealTarget.PlayerLocation[MinNumber].GetHealEffect();
    }
    
    private void GetCompareNumber()
    {
        var HpGetTest = FindObjectOfType<LocationManager>();
        float CompareA, CompareB, CompareC;
        if (HpGetTest.PlayerLocation[0] == null)
        {
            CompareA = 99;
        }
        else
        {
            CompareA = HpGetTest.PlayerLocation[0]._hpData.NowHP;
        }
        
        if (HpGetTest.PlayerLocation[1] == null)
        {
            CompareB = 99;
        }
        else
        {
            CompareB = HpGetTest.PlayerLocation[1]._hpData.NowHP;
        }
        
        if (HpGetTest.PlayerLocation[2] == null)
        {
            CompareC = 99;
        }
        else
        {
            CompareC = HpGetTest.PlayerLocation[2]._hpData.NowHP;
        }
        OnCompareNumber(CompareA,CompareB,CompareC);
    }

    private void OnCompareNumber(float NumberA,float NumberB,float NumberC)
    {
        if (NumberA < NumberB && NumberA < NumberC)
        {
            MinNumber = 0;
        }
        
        if (NumberB < NumberA && NumberB < NumberC)
        {
            MinNumber = 1;
        }
        
        if (NumberC < NumberB && NumberC < NumberA)
        {
            MinNumber = 2;
        }
    }
}
