using System;
using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    #region Instance
    static public LocationManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    [SerializeField] public FettleGeneric[] PlayerLocation;
    [SerializeField] public int[] PlayerNowLocation;
    [SerializeField] public MonsterGeneric[] MonsterLocation;
    [SerializeField] private Transform P1, P2, P3, DeadPos;

    
    // Start is called before the first frame update
    void Start()
    {
        StartSet();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChangeLocation();
        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            EventBus.Post(new RoundStartDetected());
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            EventBus.Post(new RoundOverDetected());
        }
        */
    }

    public void OnChangeLocation()
    {
        //var PlayerLocation = this.PlayerLocation
        PlayerLocation[3] = PlayerLocation[PlayerNowLocation[0]];
        PlayerLocation[4] = PlayerLocation[PlayerNowLocation[1]];
        PlayerLocation[PlayerNowLocation[0]] = PlayerLocation[4];
        PlayerLocation[PlayerNowLocation[1]] = PlayerLocation[3];
    }

    public void PlayerOnAttackDetected(float DamageNumber)
    {
        int NowStrikeLocation;
        if (PlayerLocation[0] != null)
        {
            NowStrikeLocation = 0;
        }
        else
        {
            if (PlayerLocation[1] != null)
            {
                NowStrikeLocation = 1;
            }
            else
            {
                NowStrikeLocation = 2;
            }
        }
        PlayerLocation[NowStrikeLocation].OnHit(DamageNumber);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        MusicManager.instance.PlayHit();
    }

    public void EnemyOnAttackDetected(float DamageNumber)
    {
        int NowStrikeLocation;
        if (MonsterLocation[0] != null)
        {
            NowStrikeLocation = 0;
        }
        else
        {
            if (MonsterLocation[1] != null)
            {
                NowStrikeLocation = 1;
            }
            else
            {
                NowStrikeLocation = 2;
            }
        }
        MonsterLocation[NowStrikeLocation].OnGitHit(DamageNumber);
        MonsterLocation[NowStrikeLocation].GetHitEffect();
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        MusicManager.instance.PlayHit();
    }
    
    public void OtherAttackDetected(float DamageNumber,int AttackNumber)
    {
        MonsterLocation[AttackNumber].OnGitHit(DamageNumber);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_M,Creat_Effect_Player.instance.Buff_Hit_pos[0]);
        MusicManager.instance.PlayHit();
    }

    private void StartSet()
    {
        PlayerLocation[1] = GameObject.Find("PlayerManager").GetComponent<FettleGeneric>();
        PlayerLocation[1].StatyLocation = 1;
    }

    public void CheckSurvivalEnemy()
    {
        if (MonsterLocation[0] == null && MonsterLocation[1] == null && MonsterLocation[2] == null)
        {
            EventBus.Post(new RoundOverDetected());
        }
    }

    private void DisplayChangeLocation()
    {
        if (PlayerLocation[0] != null){PlayerLocation[0].transform.position = Vector3.Lerp(PlayerLocation[0].transform.position, P1.position, 0.05f);}
        if (PlayerLocation[1] != null){PlayerLocation[1].transform.position = Vector3.Lerp(PlayerLocation[1].transform.position, P2.position, 0.05f);}
        if (PlayerLocation[2] != null){PlayerLocation[2].transform.position = Vector3.Lerp(PlayerLocation[2].transform.position, P3.position, 0.05f);}
        if (PlayerLocation[5] != null){PlayerLocation[5].transform.position = Vector3.Lerp(PlayerLocation[5].transform.position, DeadPos.position, 0.03f);}
        if (PlayerLocation[6] != null){PlayerLocation[6].transform.position = Vector3.Lerp(PlayerLocation[6].transform.position, DeadPos.position, 0.03f);}
        
    }
}
