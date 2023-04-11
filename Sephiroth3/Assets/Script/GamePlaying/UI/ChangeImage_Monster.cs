using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage_Monster : MonoBehaviour
{
    [SerializeField] private int CheckNumber;
    [SerializeField] private Image MonsterImage;
    [SerializeField] private OtherObjData Avatar;
    // Start is called before the first frame update
    void Start()
    {
        MonsterImage = GetComponent<Image>();
        ChangeIMG();
    }

    private async void ChangeIMG()
    {
        await Task.Delay(150);
        if (LocationManager.instance.MonsterLocation[CheckNumber] != null)
        {
            MonsterImage.sprite = Avatar.avatarImage[LocationManager.instance.MonsterLocation[CheckNumber].MonsterNumber];
        }
    }
}
