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
    [SerializeField] public float ShowHPNumber;
    [Header("物件")] 
    [SerializeField] private BehaviourImgSet BehaviourImg;
    [SerializeField] private Animator AN;
    [SerializeField] public Image ShowHPimg;
    [SerializeField] public GameObject ShowCDImg;
    
    // Start is called before the first frame update
    public async virtual void Start()
    {
        AttackCD = AttackCycle;
        EnemyNowHP = EnemyMaxHP;
        
        AN = transform.GetChild(0).GetComponent<Animator>();
        FettleUISet();
        LocationCheck();
        await Task.Delay(300);
        CDUIDetected();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ShowEnemyFettle();
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

    public virtual void FettleUISet()
    {
        if (PositionalOrder == 0)
        {
            ShowHPimg = GameObject.Find("EnemyHpShowA").GetComponent<Image>();
            ShowCDImg = GameObject.Find("EnemyCDA");
            BehaviourImg = GameObject.Find("BehaviourA").GetComponent<BehaviourImgSet>();
        }
        else
        {
            if (PositionalOrder == 1)
            {
                ShowHPimg = GameObject.Find("EnemyHpShowB").GetComponent<Image>();
                ShowCDImg = GameObject.Find("EnemyCDB");
                BehaviourImg = GameObject.Find("BehaviourB").GetComponent<BehaviourImgSet>();
            }
            else
            {
                ShowHPimg = GameObject.Find("EnemyHpShowC").GetComponent<Image>();
                ShowCDImg = GameObject.Find("EnemyCDC");
                BehaviourImg = GameObject.Find("BehaviourC").GetComponent<BehaviourImgSet>();
            } 
        }
        BehaciourImgChange(0,1);
    }

    public void BehaciourImgChange(int ImgA,int ImgB)
    {
        BehaviourImg.TopImg.sprite = BehaviourImg.ImgObj.avatarImage[ImgA];
        BehaviourImg.BackImg.sprite = BehaviourImg.ImgObj.avatarImage[ImgB];
    }

    private void CDUIDetected()
    {
        if (AttackCD == 0)
        {
            BehaviourImg.ShowImg.SetActive(false);
        }
        else
        {
            BehaviourImg.ShowImg.SetActive(true);
        }
    }
    /*
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
    }*/

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
        GetHitEffect();
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
    public virtual void ShowEnemyFettle()
    {
        float CDRotation = -180 + (30 * AttackCD);
        EnemyNowHP = Mathf.Clamp(EnemyNowHP, 0, EnemyMaxHP);
        ShowHPNumber = EnemyNowHP/EnemyMaxHP;
        ShowHPimg.fillAmount = Mathf.Lerp(ShowHPimg.fillAmount, ShowHPNumber, 0.06f);
        ShowCDImg.transform.rotation = Quaternion.Lerp(ShowCDImg.transform.rotation, Quaternion.Euler(0,0,CDRotation), 0.06f);
        //Debug.Log(CDRotation);
    }

}
