using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class TurntableManager : MonoBehaviour
{
    [Header("物件")]
    [SerializeField] public int SummonState;
    [SerializeField] private float EndPoint;
    [SerializeField] public GameObject[] Summoner;
    [SerializeField] public GameObject[] SummonerTurntable;
    [SerializeField] public GameObject outerring;
    [SerializeField] public GameObject touterringUI;
    //[SerializeField] public GameObject[] SummonerTurntable;
    [Header("Offset")]
    [SerializeField] private Vector3 SummonerOffset;
    [SerializeField] private Vector3 TurntableOffset;
    // Start is called before the first frame update
    void Start()
    {
        OnPlayerSummon(0);
        FindSummoner();
    }

    // Update is called once per frame
    void Update()
    {
        RotatingOuterRing();
    }

    private void FindSummoner()
    {
        SummonerTurntable[0] = GameObject.Find("Turntable_SummonerA");
        SummonerTurntable[1] = GameObject.Find("Turntable_SummonerB");
        SummonerTurntable[0].SetActive(false);
        SummonerTurntable[1].SetActive(false);
    }

    public void SimonCheck()
    {
        
    }

    public void ChangeAngle()
    {
        EndPoint -= 25.5f;
    }

    public void OnPlayerSummon(int ChoseState)
    {
        SummonState = ChoseState;
        int NowSummon = (SummonState == 1) ? PlayerPrefs.GetInt("NowSummonA") : (SummonState == 2) ? PlayerPrefs.GetInt("NowSummonB") : 0;
        Destroy(GameObject.FindWithTag("Summoner"));
        //Destroy(GameObject.FindWithTag("SummonerTurntable"));
        Instantiate(Summoner[NowSummon], this.transform.position - SummonerOffset, new Quaternion(0,0,0,0));
        //Instantiate(SummonerTurntable[NowSummon], this.transform.position, this.transform.rotation);
    }

    private void RotatingOuterRing()
    {
        outerring.transform.rotation = Quaternion.Lerp(outerring.transform.rotation, quaternion.Euler(0,0,EndPoint), 0.09f);
        touterringUI.transform.rotation = Quaternion.Lerp(touterringUI.transform.rotation, quaternion.Euler(0,0,EndPoint), 0.09f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position -SummonerOffset,0.3f);
    }

    /*
    var NowSummoner = GameObject.FindWithTag("Summoner");
    var NowSummonerSkill = GameObject.FindWithTag("SummonerTurntable");
    */
}
