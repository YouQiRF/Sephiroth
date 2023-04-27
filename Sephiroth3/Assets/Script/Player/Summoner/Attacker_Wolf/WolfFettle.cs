using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfFettle :FettleGeneric
{
    public override void OnStart()
    {
        base.OnStart();
        _hpData.ArmorValue = 3;
    }
}
