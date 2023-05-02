using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using UnityEngine.SceneManagement;

public class map_time : MonoBehaviour
{
    public GameObject mapmanager;
    [SerializeField] public static bool is_map_time = false;
    //打完一場戰鬥後都要  is_map_time = ! is_map_time; 切回我們的選地圖
    public static bool is_load = false;
    public static bool is_new_game = true;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start" +PlayerPrefs.GetInt("NeedReset"));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(is_map_time);
        //ResetMap();
        if (PlayerPrefs.GetInt("NeedReset") == 1)
        {
            ManualoperationResetMap();
            PlayerPrefs.SetInt("NeedReset",0);
        }
        //Debug.Log(PlayerPrefs.GetInt("NeedReset"));
        changscene(3, 4);
    }
    /*void SetActiveWithTag(bool now_bool) //刪除地圖物件
    {
        foreach (GameObject oneObject in map)
            if (oneObject != null)
            {
                oneObject.SetActive(now_bool);
            }
        ;
    }*/

    void ManualoperationResetMap()
    {
        if (is_new_game)
        {
            mapmanager.GetComponent<MapManager>().GenerateNewMap();
            is_map_time = true;
            Map_System.Map_level = 0;
            is_new_game =false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("rest");
            mapmanager.GetComponent<MapManager>().GenerateNewMap();
            is_map_time = true;
            Map_System.Map_level = 0;
            // map = GameObject.FindGameObjectsWithTag("ChooseMap");
        }
        Debug.Log("Set"+PlayerPrefs.GetInt("NeedReset"));
    }
    
    public void ResetMap()
    {
        mapmanager.GetComponent<MapManager>().GenerateNewMap();
        is_map_time = true;
        Map_System.Map_level = 0;
        Debug.Log("rest");
    }

    static void changscene(int a, int b)
    {
        if (is_load)
        {
            SceneManager.LoadScene(a);
            is_map_time = false;
            is_load = false;
            Map_System.is_creat = true;
        }
    }
}
