using System.Collections;
using System.Collections.Generic;
using Project.PlayerHpData;
using UnityEngine;
using UnityEngine.UI;

public class FettleGeneric : MonoBehaviour
{
    [SerializeField] public HpData _hpData;

    [SerializeField] public int StatyLocation;
    [SerializeField] public int ThisNumber;
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        //_hpData.NowHP =  _hpData.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
        _hpData.NowHP = Mathf.Clamp(_hpData.NowHP, 0, _hpData.MaxHP);
        _hpData.ArmorValue = Mathf.Clamp(_hpData.ArmorValue, 0, _hpData.MaxHP / 2);
        _hpData.ShowHPFloat =  _hpData.NowHP /  _hpData.MaxHP;
        _hpData.ShowArmorFloat = _hpData.ArmorValue / (_hpData.MaxHP / 2);
        _hpData.ShowPlayerHP.fillAmount = Mathf.Lerp( _hpData.ShowPlayerHP.fillAmount,  _hpData.ShowHPFloat, 0.02f);
        _hpData.ShowPlayerArmor.fillAmount = Mathf.Lerp(_hpData.ShowPlayerArmor.fillAmount, _hpData.ShowArmorFloat, 0.07f);
    }

    public virtual void OnStart()
    {
        _hpData.ArmorValue = 0f;
        
        if (StatyLocation == 1)
        {
            _hpData.ShowPlayerHP = GameObject.Find("PlayerHpShow").GetComponent<Image>();
            _hpData.ShowPlayerArmor = GameObject.Find("PlayerArmorShow").GetComponent<Image>();
        }
        
        if (StatyLocation == 3)
        {
            _hpData.ShowPlayerHP = GameObject.Find("SummonAHpShow").GetComponent<Image>();
            _hpData.ShowPlayerArmor = GameObject.Find("SummonAArmorShow").GetComponent<Image>();
        }
        
        if (StatyLocation == 4)
        {
            _hpData.ShowPlayerHP = GameObject.Find("SummonBHpShow").GetComponent<Image>();
            _hpData.ShowPlayerArmor = GameObject.Find("SummonBArmorShow").GetComponent<Image>();
        }
        //_hpData.ShowPlayerHP = GameObject.Find("PlayerHpShow").GetComponent<Image>();
    }

    public virtual void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //OnHitDetected(0,10);  
        }
    }

    public virtual void OnSetLocation()
    {
        if (_hpData.NowHP > 0)
        {
            var PlayerLC = FindObjectOfType<PlayerFettle>();
            var LocationM = FindObjectOfType<LocationManager>();
            int ramNumber;
            LocationM.PlayerNowLocation[0] = PlayerLC.StatyLocation;
            LocationM.PlayerNowLocation[1] = this.StatyLocation;
            ramNumber = LocationM.PlayerNowLocation[0];
            PlayerLC.StatyLocation = this.StatyLocation;
            this.StatyLocation = ramNumber;
            LocationM.OnChangeLocation(); 
        }
    }
/*
    public virtual void OnHitDetected(int NowLocationnumber,float DamageNumber)
    {
        if (StatyLocation == NowLocationnumber)
        {
            OnHit(DamageNumber);
        }
    }
*/
    public virtual void OnDead()
    {
        var LocationM = FindObjectOfType<LocationManager>();
        var Turntable = FindObjectOfType<TurntableManager>();
        var UI = FindObjectOfType<GameUIManager>();
        if (LocationM.PlayerLocation[5] == null)
        {
            LocationM.PlayerLocation[5] = LocationM.PlayerLocation[StatyLocation];
            LocationM.PlayerLocation[StatyLocation] = null;
        }
        else
        {
            if (LocationM.PlayerLocation[6] == null)
            {
                LocationM.PlayerLocation[6] = LocationM.PlayerLocation[StatyLocation];
                LocationM.PlayerLocation[StatyLocation] = null;
            }
        }
        
        if (PlayerPrefs.GetInt("SummonerA") == ThisNumber)
        {
            Turntable.SummonerTurntable[0].SetActive(false);
            UI.TurntableUI[0].SetActive(false);
        }
        else
        {
            Turntable.SummonerTurntable[1].SetActive(false);
            UI.TurntableUI[1].SetActive(false);
        }
    }

    public void GetHealEffect()
    {
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Recover,Creat_Effect_Player.instance.Buff_Recover_pos[StatyLocation]);
        MusicManager.instance.PlayHeal();
    }

    public virtual void OnHit(float GetDamage)
    {
        if (_hpData.ArmorValue == 0)
        {
            _hpData.NowHP -= GetDamage;
        }
        else
        {
            if (GetDamage >= _hpData.ArmorValue)
            {
                _hpData.NowHP -= GetDamage - _hpData.ArmorValue;
                _hpData.ArmorValue = 0f;
            }
            else
            {
                _hpData.ArmorValue -= GetDamage;
            }
        }

        if (_hpData.NowHP <= 0)
        {
            OnDead();
        }
        
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Attack_Basic,Creat_Effect_Player.instance.Buff_Hit_pos[StatyLocation]);
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Shake_Camera_S,Creat_Effect_Player.instance.Buff_Hit_pos[StatyLocation]);
    }
}
