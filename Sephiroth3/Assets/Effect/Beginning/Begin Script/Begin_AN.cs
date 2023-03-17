using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Project.Begin_Data;


public class Begin_AN : MonoBehaviour
{
    [Header("畫面物件")]
    [SerializeField] public GameObject[] BeginAN;
    [Header("畫面持續時間")]
    [SerializeField] public int[] BeginANTime;
    [Header("切換Scenes")]
    [SerializeField] public int scenenum;
    // Start is called before the first frame update

    public Begin_AN _begin_AN;
    void Start()
    {
        StartCoroutine(CreatBeginAN(scenenum));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(scenenum);
        }
    }
    /*  void CreatBeginAN(int number)
      {
          DestroyWithTag("Begin");
          Instantiate(BeginAN[number]);s
      }*/

    IEnumerator CreatBeginAN(int scenenum)
    {
        for (int i = 0; i < BeginAN.Length; i++)
        {
            //Debug.Log(i);
            DestroyWithTag("Begin");
            Instantiate(BeginAN[i]);
            yield return new WaitForSeconds(BeginANTime[i]);
            if (i + 1 == BeginAN.Length)
            {
                SceneManager.LoadScene(scenenum);
            }
        }
    }

    void DestroyWithTag(string destroyTag) //刪除地圖物件
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
}
