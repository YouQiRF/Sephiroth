using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignedDisplay : MonoBehaviour
{
    //[SerializeField] public bool IsSpecial;
    [SerializeField] public Image[] SpecialIcon;
    [SerializeField] public int ShowNumber;
    [SerializeField] public int BackNumber;

    private void Start()
    {
        Seticon();
    }

    public void Seticon()
    {
        if (SpecialIcon.Length > 0)
        {
            for (int i = 0; i < SpecialIcon.Length; i++)
            {
                SpecialIcon[i].color = new Color(255, 255, 255, 0);
            }
            SpecialIcon[BackNumber].color = new Color(255, 255, 255, 1);
        }
    }
}
