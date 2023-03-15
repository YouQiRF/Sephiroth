using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Map_System : MonoBehaviour
{
    [Header("地圖物件")]
    [SerializeField] public GameObject[] Map;
    //00 是起始地圖
    //05 是小黑房間
    [Header("黑幕物件")]
    [SerializeField] public GameObject shady;
    [Header("篝火物件")]
    [SerializeField] public GameObject recover;
    [SerializeField] public static bool is_next_map = false;
    [SerializeField] public static int Map_level = 0;

    [Header("地圖狀態")]
    [SerializeField] public static bool Start_map = true;
    [SerializeField] public static bool Basic_map = false;
    [SerializeField] public static bool Black_map = false;
    [SerializeField] public static bool Recover_map = false;
    [SerializeField] public static bool Boss_map = false;
    [SerializeField] public static bool Elite_Enemy = false;

    [Header("MAP")]
    [SerializeField] public static int roomcode; //  0=戰鬥 1=休息 2=BOSS 3=小黑


    int new_map;
    public static int old_a = 0;
    public static bool is_creat = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Roomcode", roomcode);
        PlayerPrefs.SetInt("Level", Map_level);
        //load_Map(old_a);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(roomcode);
        load_test();
        next_basic_map();
        endgame();
        if (Input.GetKeyDown(KeyCode.S))
        {
            map_time.is_map_time = !map_time.is_map_time;
        }
    }

    void load_Map(int new_a)
    {
        DestroyWithTag("Map");
        Instantiate(Map[old_a]);
        Instantiate(shady);
        old_a = new_a;
        // Debug.Log(new_a);
        //is_next_map = false;
    }

    void load_test() //測試用
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            load_Map(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            load_Map(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            load_Map(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            load_Map(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            load_Map(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            load_Map(5);
        }
    }
    void DestroyWithTag(string destroyTag) //刪除地圖物件
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
    void next_basic_map() // set_level
    {
        var MonsterInstantiate = FindObjectOfType<OnInstantiate>();
        if (map_time.is_map_time == false)
        {
            if (is_creat)
            {
                if (roomcode == 0) //一般戰鬥
                {
                    //Debug.Log("Basic_level");
                    map_reader(false, true, false, false, false,false);
                    EventBus.Post(new RoundStartDetected());
                    MonsterInstantiate.OnInstantiateMonster();
                    new_map = Random.Range(1, 5);
                    load_Map(new_map);
                    load_Map(new_map);
                    Map_level++;
                }
                if (roomcode == 1)//恢復點
                {
                    map_reader(false, false, false, true, false,false);
                    new_map = Random.Range(1, 5);
                    load_Map(new_map);
                    load_Map(new_map);
                    Instantiate(recover);
                    //Debug.Log("Recover_level");
                    EventBus.Post(new RoundOverDetected());
                }

                if (roomcode == 2) //Boss房間
                {
                    //Debug.Log("Boss_level");
                    map_reader(false, false, false, false, true,false);
                    EventBus.Post(new RoundStartDetected());
                    new_map = Random.Range(1, 5);
                    load_Map(new_map);
                    load_Map(new_map);
                    MonsterInstantiate.OnInstantiateMonster();
                }
                if (roomcode == 0 && Map_level == 3)//小黑取得
                {
                    map_reader(false, false, true, false, false,false);
                    load_Map(5);
                    load_Map(5);
                    Map_level++;
                }
                if (roomcode == 4) //菁英戰鬥
                {
                    //Debug.Log("Elite_Enemy");
                    map_reader(false, false, false, false, false,true);
                    EventBus.Post(new RoundStartDetected());
                    MonsterInstantiate.OnInstantiateMonster();
                    new_map = Random.Range(1, 5);
                    load_Map(new_map);
                    load_Map(new_map);
                    Map_level++;
                }
                is_creat = false;
            }
        }
    }

    void map_reader(bool start, bool basic, bool black, bool recover, bool boss, bool Elite)
    {
        Start_map = start;
        Basic_map = basic;
        Black_map = black;
        Recover_map = recover;
        Boss_map = boss;
        Elite_Enemy = Elite;
    }
    void endgame()
    {
        if (map_time.is_map_time)
        {
            SceneManager.LoadScene(4);
        }
    }
}
