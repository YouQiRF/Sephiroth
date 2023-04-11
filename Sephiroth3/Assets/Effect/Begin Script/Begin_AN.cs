using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Project.Begin_Data;


public class Begin_AN : MonoBehaviour
{
    [SerializeField] public Begin_Data _begin_Data;
    void Start()
    {
        StartCoroutine(CreatBeginAN(_begin_Data.Load_scenes_nul));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_begin_Data.Load_scenes_nul);
        }
    }

    IEnumerator CreatBeginAN(int scenenum)
    {
        for (int i = 0; i < _begin_Data.Picturt.Length; i++)
        {
            //Debug.Log(i);
            DestroyWithTag("Begin");
            Instantiate(_begin_Data.Picturt[i]);
            yield return new WaitForSeconds(_begin_Data.Showtime[i]);
            if (i + 1 == _begin_Data.Picturt.Length)
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
