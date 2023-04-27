using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using UnityEngine;
using UnityEngine.UI;

public class ChooseManager : MonoBehaviour
{
    [SerializeField] private Image summonerImage;
    [SerializeField] private OtherObjData Avatar;

    [SerializeField] private int ChooseNumber;
    // Start is called before the first frame update
    void Start()
    {
        summonerImage = GetComponent<Image>();
        GitNumber();
        ChangeIMG();
    }

    private void GitNumber()
    {
        for (int i = 0; i < 5; i--)
        {
            ChooseNumber = Random.Range(1, Avatar.avatarImage.Length);
            if (ChooseNumber == PlayerPrefs.GetInt("SummonerA")){}
            else{if(ChooseNumber == PlayerPrefs.GetInt("SummonerB")){}else{i = 10;}}
        }
    }

    private async void ChangeIMG()
    {
        await Task.Delay(150);
        summonerImage.sprite = Avatar.avatarImage[ChooseNumber];
        Avatar.SummonerFettle[ChooseNumber].NowHP = Avatar.SummonerFettle[ChooseNumber].MaxHP;
    }

    public void ChangeSummonerA()
    {
        PlayerPrefs.SetInt("SummonerA",ChooseNumber);
        map_time.is_map_time = true;
    }
    
    public void ChangeSummonerB()
    {
        PlayerPrefs.SetInt("SummonerB",ChooseNumber);
        map_time.is_map_time = true;
    }

    public void ExitChangeSummoner()
    {
        map_time.is_map_time = true;
    }
}
