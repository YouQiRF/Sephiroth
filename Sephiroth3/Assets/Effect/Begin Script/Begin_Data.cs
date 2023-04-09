using UnityEngine;
namespace Project.Begin_Data
{
    [CreateAssetMenu(fileName = "Begin", menuName = "Begin_setting", order = 1)]

    [System.Serializable]
    public class Begin_Data : ScriptableObject
    {
        [SerializeField] public GameObject[] Picturt ;
        [SerializeField] public float[] Showtime;
        [SerializeField] public int Load_scenes_nul;
    }
}



