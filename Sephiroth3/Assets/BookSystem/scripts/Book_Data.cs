using UnityEngine;
using UnityEngine.UI;
namespace Project.Book_Data
{
    [CreateAssetMenu(fileName = "Book_Data", menuName = "Booker_Data", order = 2)]
    [System.Serializable]
    public class Book_Data : ScriptableObject
    {
        //[SerializeField] public Sprite image;
        [SerializeField] public Sprite[] image;
    }

}
