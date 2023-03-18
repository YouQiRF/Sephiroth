using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Book_Data;
using UnityEngine.UI;

public class BookIcon : MonoBehaviour
{
    public Text text;
    public Book_Data _book_Data;
    public Button play_button;
    public Button enemy_button;
    public Button turntable_button;
    [SerializeField] public GameObject Text_object;
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
        text.text = ""+_book_Data.text[num];
    }
    public void Click_Hide_interduction()
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

    }
}
