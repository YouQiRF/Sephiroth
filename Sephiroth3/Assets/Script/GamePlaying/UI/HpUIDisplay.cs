using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIDisplay : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isSummonerA;
    [SerializeField] private string summonerName;
    [SerializeField] private FettleGeneric checkHP;
    [SerializeField] private float offset;
    // Start is called before the first frame update
    void Start()
    {
        if (isSummonerA)
        {
            summonerName = "TheSummonerA";
        }
        else
        {
            summonerName = "TheSummonerB";
        }

        if (!isPlayer)
        {
            checkHP = GameObject.Find(summonerName).GetComponent<FettleGeneric>();
        }
        else
        {
            checkHP = GameObject.Find("PlayerManager").GetComponent<FettleGeneric>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
           /* this.transform.position = Vector3.Lerp(transform.position,
                new Vector3(this.transform.position.x, offset, this.transform.position.z), 0.05f);*/
        }
        else
        {
            if (checkHP._hpData.NowHP <= 0)
            {
                this.transform.position = Vector3.Lerp(transform.position,
                    new Vector3(this.transform.position.x, 750, this.transform.position.z), 0.02f);
            }
            else
            {
               /* this.transform.position = Vector3.Lerp(transform.position,
                    new Vector3(this.transform.position.x, offset, this.transform.position.z), 0.05f);*/
            }
        }
    }
}
