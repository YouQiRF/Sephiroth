using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Book_Data;
using UnityEngine.UI;

public class BookIcon : MonoBehaviour
{
    public Image image;
    public Book_Data _book_Data;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click_Show_interduction(int num)
    {
        BookSystem.is_text = true;
        image.sprite = _book_Data.image[num];
    }
   /* public void Click_Hide_interduction()
    {
        if (ChangBookKind.load == 1)
        {
            play_button.onClick.Invoke();
        }
        if (ChangBookKind.load == 2)
        {
            enemy_button.onClick.Invoke();
        }
        if (ChangBookKind.load == 3)
        {
            turntable_button.onClick.Invoke();
        }
        Text_object.SetActive(false);

    }*/
}
