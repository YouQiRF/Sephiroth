using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using UnityEngine;

public class TeachManager : MonoBehaviour
{
    [SerializeField] public bool isOpen;
    [SerializeField] public int nowNumber;
    [SerializeField] private GameObject[] teacjObj;
    [SerializeField] private GameObject[] Buttons;
    // Start is called before the first frame update
    async void Start()
    {
        var HPSet = FindObjectOfType<GameStart_HPSet>();
        HPSet.OnStartSet();
        await Task.Delay(500);OpenTeach();
    }
    
    public void OpenTeach()
    {
        if (!isOpen)
        {
            var GameManager = FindObjectOfType<GamePlayingManager>();
            nowNumber = 0;
            isOpen = true;
            TeachDisplay();
            ButtonDisplay();
            GameManager.StopGame();
        }
    }

    public void PushButton(int addNumber)
    {
        nowNumber += addNumber;
        LoopCheck();
        TeachDisplay();
        ButtonDisplay();
    }

    public void CloseTeach()
    {
        var GameManager = FindObjectOfType<GamePlayingManager>();
        isOpen = false;
        TeachDisplay();
        ButtonDisplay();
        GameManager.StopGame();
    }

    public void TeachDisplay()
    {
        if (!isOpen)
        {
            for (int i = 0; i < teacjObj.Length; i++)
            { 
                teacjObj[i].SetActive(false);
                Buttons[i].SetActive(false);
            }
        }
        else
        {
            
            for (int i = 0; i < teacjObj.Length; i++)
            { 
                teacjObj[i].SetActive(false);
            }
            teacjObj[nowNumber].SetActive(true);
        }
    }

    private void LoopCheck()
    {
        if (nowNumber >= teacjObj.Length)
        {
            nowNumber = teacjObj.Length-1;
        }
        
        if (nowNumber < 0)
        {
            nowNumber = 0;
        }
    }

    public void ButtonDisplay()
    {
        if (isOpen)
        {
            Buttons[0].SetActive(true);
            if (nowNumber <= 0)
            {
                Buttons[1].SetActive(false);
            }
            else
            {
                Buttons[1].SetActive(true);
            }
            if (nowNumber >= teacjObj.Length-1)
            {
                Buttons[2].SetActive(false);
            }
            else
            {
                Buttons[2].SetActive(true);
            }
        }
    }

}
