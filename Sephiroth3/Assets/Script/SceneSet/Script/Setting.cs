using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public static bool is_show_setting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(is_show_setting);
        esc();
    }

    void set_bool()
    {
        while (is_show_setting)
        {
            SceneManager.LoadScene(5);
            break;
        }
        while (!is_show_setting)
        {
            SceneManager.LoadScene(4);
            break;
        }
    }

    void esc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_show_setting = !is_show_setting;
            set_bool();
        }
    }
   public  void LoadScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }
}
