using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangBookKind : BookSystem
{
    [SerializeField] public GameObject Text_object;
   public static int load = 1;
    public static void set_bool(bool player, bool enemy, bool turntable)
    {
        is_Player = player;
        is_Enemy = enemy;
        is_Turntable = turntable;
    }
    [SerializeField] public Image target_image;

    // Start is called before the first frame update
    void Start()
    {
        set_bool(true, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        Active();
    }
    public void ClickChang_Player(Sprite image) //load = 1
    {
        // Debug.Log("ClickChang_Player");
        target_image.sprite = image;
        set_bool(true, false, false);
        is_text = false;
        load = 1;
    }
    public void ClickChang_Enemy(Sprite image)//load = 2
    {
        //Debug.Log("ClickChang_Enemy");
        target_image.sprite = image;
        set_bool(false, true, false);
        is_text = false;
        load =2;
    }
    public void ClickChang_Turntable(Sprite image)//load = 3
    {
        //Debug.Log("ClickChang_Turntable");
        target_image.sprite = image;
        set_bool(false, false, true);
        is_text = false;
        load =2;
    }



    public void Active()
    {
        if (!is_text)
        {
            Text_object.SetActive(false);
            if (is_Player)
            {
                set_gameobject(true, false, false);
            }
            if (is_Enemy)
            {
                set_gameobject(false, true, false);
            }
            if (is_Turntable)
            {
                set_gameobject(false, false, true);
            }
        }
        if (is_text)
        {
            set_gameobject(false, false, false);
            Text_object.SetActive(true);
        }
    }

}
