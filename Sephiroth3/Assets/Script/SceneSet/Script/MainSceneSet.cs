using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainSceneSet : MonoBehaviour
{
    public int GamePlay_scenes_ID;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("NeedReset"));
    }
    private void Update()
    {
    }
    public async void LoadScene_Scene(int SceneID)
    {
        
        if (GameObject.Find("GameStartSet") != null)
        {
            if (PlayerPrefs.GetInt("NeedReset") == 1)
            {
                FindObjectOfType<GameStart_HPSet>().OnStartSet();
                //PlayerPrefs.SetInt("NeedReset",0);
            }
        }
        await Task.Delay(700);
        SceneManager.LoadScene(SceneID);
        if (SceneID == GamePlay_scenes_ID)
        {
            SetAudio.audioNum = 0;
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
