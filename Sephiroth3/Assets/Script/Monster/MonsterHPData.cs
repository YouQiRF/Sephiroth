using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.MonsterData
{
    [CreateAssetMenu(fileName = "FILENAME",menuName = "EnemyData_HP",order = 0)]
    
    [System.Serializable]
    public class MonsterHPData : ScriptableObject
    {
        [SerializeField] public int EnemyMaxHP;
        [SerializeField] public int EnemyNowHP;
        [SerializeField] public int AttackCD;
        [SerializeField] public int AttackCDMax;
    }
}


