using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAttackUI : MonoBehaviour
{
    [SerializeField] public Image attackUI_Img;
    [SerializeField] public Text attackUI_CD;
    [SerializeField] public Sprite[] attackUI_ChangeImg;
    [SerializeField] public GameObject ReadyAttack;
    [SerializeField] public Transform MonsterPos;
    [SerializeField] private Vector3 imgOffset;
    
    //[SerializeField] private int i;
    // Start is called before the first frame update
    void Start()
    {
        //i = 0;
        ReadyAttack.SetActive(false);
        attackUI_Img = this.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Follow();
    }
    
    private void Follow()
    {
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(MonsterPos.position);
        this.transform.position = ScreenPos + imgOffset;
    }

    /*if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
        }
        if (i ==attackUI_ChangeImg.Length)
        {
            i = 0;
        }
        attackUI_Img.sprite = attackUI_ChangeImg[i];*/
}
