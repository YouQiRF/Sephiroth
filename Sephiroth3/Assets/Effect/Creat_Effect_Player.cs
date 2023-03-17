using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Effect_Player : MonoBehaviour
{
    #region Instance
    static public Creat_Effect_Player instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("恢復特效位置")]
    [SerializeField] public List<GameObject> Buff_Recover_pos;
    [Header("防禦特效位置")]
    [SerializeField] public List<GameObject> Buff_Armor_pos;
    [Header("受擊特效位置")]
    [SerializeField] public List<GameObject> Buff_Hit_pos;


    [Header("特效物件")]
    [SerializeField] public GameObject Buff_Recover;
    [SerializeField] public GameObject Buff_Armor;
    [SerializeField] public GameObject Attack_Basic;
     [SerializeField] public GameObject Shake_Camera_S;
    
    [SerializeField] public GameObject Shake_Camera_M;
    [SerializeField] public GameObject Shake_Camera_L;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Creat(Buff_Recover, Buff_Recover_pos[0]);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Creat(Buff_Armor, Buff_Armor_pos[0]);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Creat(Attack_Basic, Buff_Hit_pos[0]);
            Instantiate(Shake_Camera_M, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        }

    }
    public void Creat(GameObject Effect, GameObject pos)
    {
        Instantiate(Effect, pos.transform.position, new Quaternion(0, 0, 0, 0));
    }
}
