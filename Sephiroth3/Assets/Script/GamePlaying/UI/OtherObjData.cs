using Project.PlayerHpData;
using UnityEngine;
using UnityEngine.UI;
namespace Project.AvatarData
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "otherObjData", order = 0)]
    
    [System.Serializable]
    public class OtherObjData : ScriptableObject
    {
        [SerializeField] public Sprite[] avatarImage;
        [SerializeField] public GameObject[] teachObj;
        [SerializeField] public HpData[] SummonerFettle;
    }
}