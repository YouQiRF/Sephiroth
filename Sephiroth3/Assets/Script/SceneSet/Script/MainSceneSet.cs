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

    }
    private void Update()
    {
    }
    public async void LoadScene_Scene(int SceneID)
    {
        await Task.Delay(200);
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
