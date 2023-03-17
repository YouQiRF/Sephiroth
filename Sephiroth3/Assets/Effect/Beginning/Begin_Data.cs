using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Project.Begin_Data
{
    [CreateAssetMenu(fileName = "BeginAN", menuName = "Begin_Data", order = 0)]
    [System.Serializable]
    public class HpData : Begin_AN
    {
        [SerializeField] public GameObject[] Picturt;
        [SerializeField] public float[] Showtime;
       
    }
}



