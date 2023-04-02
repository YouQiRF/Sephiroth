using UnityEngine;
using UnityEngine.UI;
namespace Project.AvatarData
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "AvatarrData", order = 0)]
    
    [System.Serializable]
    public class AvatarData : ScriptableObject
    {
        [SerializeField] public Sprite[] avatarImage;
    }
}