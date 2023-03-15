using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAssigendDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] disPlayIcon;

    public void OnAssigned()
    {
        disPlayIcon[0].SetActive(true);
    }

    public void ExitAssigned()
    {
        disPlayIcon[0].SetActive(false);
    }

    public void OnChangeIcon()
    {
        disPlayIcon[0] = disPlayIcon[2];
        disPlayIcon[1] = disPlayIcon[3];
    }
}
