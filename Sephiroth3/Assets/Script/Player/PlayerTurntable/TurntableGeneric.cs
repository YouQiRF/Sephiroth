using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TurntableGeneric : MonoBehaviour
{
    [SerializeField] public bool IsChess;
    [SerializeField] private bool SpecialIcon;
    [SerializeField] public string FindName;
    void Start()
    {
        FindName = this.gameObject.name + "Icon";
        ChangeIcon(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(FindName);
    }

    public void OnChoseEvent()
    {
        if(IsChess)
        {
            OnPointed();
        }
    }
    
    public virtual void OnPointed()
    {
        
    }

    public virtual void ChangeIcon(bool Display)
    {
        var SpecialIconCtrl = GameObject.Find(FindName).GetComponent<AssignedDisplay>();
        if (SpecialIcon)
        {
            //Debug.Log("AAA");
            if (Display)
            {
               SpecialIconCtrl.SpecialIcon[SpecialIconCtrl.ShowNumber].color = new Color(255, 255, 255, 1);
               //Debug.Log(SpecialIconCtrl.SpecialIcon[SpecialIconCtrl.ShowNumber].name);
            }
            else
            {
                SpecialIconCtrl.SpecialIcon[SpecialIconCtrl.ShowNumber].color = new Color(255, 255, 255, 0);
            }
        }
        else
        {
            //Debug.Log("BBB");
            var IconCtrl = GameObject.Find(FindName).GetComponent<Image>();
            if (Display)
            {
                IconCtrl.color = new Color(255, 255, 255, 1);
            }
            else
            {
                IconCtrl.color = new Color(255, 255, 255, 0);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pointer")
        {
            IsChess = true;
            ChangeIcon(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pointer")
        {
            IsChess = false;
            ChangeIcon(false);
        }
    }
    
    /*
    public void OnChoseDefense()
    {
        if(IsChess && Tagged)
        {
            Debug.Log("DDDDD");
        }
    }
    */
}
