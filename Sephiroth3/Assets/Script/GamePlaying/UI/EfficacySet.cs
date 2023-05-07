using System.Collections;
using System.Collections.Generic;
using Project.AvatarData;
using UnityEngine;
using UnityEngine.UI;

public class EfficacySet : MonoBehaviour
{
    [SerializeField] public OtherObjData EfficacyImg;
    [SerializeField] private bool IsSummonerA;
    // Start is called before the first frame update
    void Start()
    {
        if (IsSummonerA)
        {
            this.GetComponent<Image>().sprite = EfficacyImg.avatarImage[PlayerPrefs.GetInt("SummonerA")];
        }
        else
        {
            this.GetComponent<Image>().sprite = EfficacyImg.avatarImage[PlayerPrefs.GetInt("SummonerB")];
        }
    }
}
