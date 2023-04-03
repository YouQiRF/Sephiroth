using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage_Summoner : MonoBehaviour
{
    [SerializeField] private bool isSummonerA;
    [SerializeField] private Image summonerImage;
    [SerializeField] private AvatarData Avatar;
    // Start is called before the first frame update
    void Start()
    {
        summonerImage = GetComponent<Image>();
        ChangeIMG();
    }

    private async void ChangeIMG()
    {
        await Task.Delay(150);
        if (isSummonerA)
        {
            summonerImage.sprite = Avatar.avatarImage[GameObject.Find("TheSummonerA").GetComponent<SummonerManager>().thisNumber];
        }
        else
        {
            summonerImage.sprite = Avatar.avatarImage[GameObject.Find("TheSummonerB").GetComponent<SummonerManager>().thisNumber];
        }
    }
}
