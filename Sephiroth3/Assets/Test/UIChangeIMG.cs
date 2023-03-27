using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeIMG : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    public Sprite[] m_Sprite;
    [SerializeField] private int i;

    public Transform testOBJ;
    [SerializeField]private Vector3 Offset;
    

    void Start()
    {
        i = 0;
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
        }
        if (i == m_Sprite.Length)
        {
            i = 0;
        }
        m_Image.sprite = m_Sprite[i];
        Follow();
    }

    private void Follow()
    {
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(testOBJ.position);
        this.transform.position = ScreenPos + Offset;
    }
}
