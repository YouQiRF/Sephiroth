using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Event;
using Project.MonsterData;
using UnityEngine;
using UnityEngine.UI;

public class MonsterGeneric : MonoBehaviour
{
    [Header("數值")] 
    [SerializeField] public int MonsterNumber;
    [SerializeField] public float EnemyMaxHP;
    [SerializeField] public float EnemyNowHP;
    [SerializeField] public int AttackCD;
    [SerializeField] public int AttackCycle;
    [SerializeField] public int AttackDamage;
    [SerializeField] public int PositionalOrder;
    [SerializeField] public bool IsDead;
    [Header("UI數值")] 
    [SerializeField] public Image ShowHPimg;
    [SerializeField] public float ShowHPNumber;
    [Header("物件")] 
    [SerializeField] private MonsterAttackUI CDUI;
    [SerializeField] private Animator AN;
    
    // Start is called before the first frame update
    public async virtual void Start()
    {
        AttackCD = AttackCycle;
        EnemyNowHP = EnemyMaxHP;
        
        AN = transform.GetChild(0).GetComponent<Animator>();
        HPUISet();
        LocationCheck();
        await Task.Delay(300);
        CDUIDetected();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ShowEnemyHP();
        if (IsDead)
        {
            transform.position = Vector3.Lerp(this.transform.position, new Vector3(15,-2,0), 0.05f);
        }
    }

    public virtual void OnPassRound()
    {
        
        if (!IsDead)
        {
            if (AttackCD == 0)
            {
                AttackCD = AttackCycle;
                AttackBehaviour();
                AN.Play("OnAttack");
            }
            else
            {
                AttackCD--;
            } 
        }
        CDUIDetected();
    }

    public virtual void AttackBehaviour()
    {
        var StrikeTarget = FindObjectOfType<LocationManager>();
        StrikeTarget.PlayerOnAttackDetected(AttackDamage);
    }

    public virtual void HPUISet()
    {
        if (PositionalOrder == 0)
        {
            ShowHPimg = GameObject.Find("EnemyHpShowA").GetComponent<Image>();
        }
        else
        {
            if (PositionalOrder == 1)
            {
                ShowHPimg = GameObject.Find("EnemyHpShowB").GetComponent<Image>();
            }
            else
            {
                ShowHPimg = GameObject.Find("EnemyHpShowC").GetComponent<Image>();
            } 
        }
    }

    private void CDUIDetected()
    {
        if (AttackCD == 0)
        {
            CDUI.attackUI_Img.sprite = CDUI.attackUI_ChangeImg[0];
            CDUI.ReadyAttack.SetActive(true);
            CDUI.attackUI_CD.text = "";
        }
        else
        {
            CDUI.ReadyAttack.SetActive(false);
            CDUI.attackUI_CD.text = AttackCD + "";
            if (AttackCD >= 3)
            {
                CDUI.attackUI_Img.sprite = CDUI.attackUI_ChangeImg[3];
            }
            else
            {
                switch (AttackCD)
                {
                    case 2:
                        CDUI.attackUI_Img.sprite = CDUI.attackUI_ChangeImg[2];
                        break;
                    case 1:
                        CDUI.attackUI_Img.sprite = CDUI.attackUI_ChangeImg[1];
                        break;
                }
            }
        }
    }

    public virtual void LocationCheck()
    {
        var nowLocation = FindObjectOfType<LocationManager>();
        nowLocation.MonsterLocation[PositionalOrder] = this.gameObject.GetComponent<MonsterGeneric>();
    }

    public virtual void OnGitHit(float GetDamage)
    {
        var nowLocation = FindObjectOfType<LocationManager>();
        EnemyNowHP -= GetDamage;
        if (EnemyNowHP <= 0)
        {
            IsDead = true;
            nowLocation.MonsterLocation[PositionalOrder] = null;
            nowLocation.CheckSurvivalEnemy();
        }
    }

    public void GetHitEffect()
    {
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Attack_Basic,transform.GetChild(0).gameObject);
    }

    public void GetHealEffect()
    {
        Creat_Effect_Player.instance.Creat(Creat_Effect_Player.instance.Buff_Recover,transform.GetChild(0).gameObject);
        MusicManager.instance.PlayHeal();
    }
    public virtual void ShowEnemyHP()
    {
        EnemyNowHP = Mathf.Clamp(EnemyNowHP, 0, EnemyMaxHP);
        ShowHPNumber = EnemyNowHP/EnemyMaxHP;
        ShowHPimg.fillAmount = Mathf.Lerp(ShowHPimg.fillAmount, ShowHPNumber, 0.06f);
    }

}
