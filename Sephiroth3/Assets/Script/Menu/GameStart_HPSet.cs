using System.Collections;
using System.Collections.Generic;
using Project.PlayerHpData;
using UnityEngine;

public class GameStart_HPSet : MonoBehaviour
{
    [SerializeField] private HpData[] _hpData;
    // Start is called before the first frame update
    public void OnStartSet()
    {
        for (int i = 0; i < _hpData.Length; i++)
        {
            _hpData[i].NowHP = _hpData[i].MaxHP;
            //Debug.Log(i);
        }
    }
}
