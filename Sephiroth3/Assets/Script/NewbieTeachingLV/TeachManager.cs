using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using UnityEngine;
using UnityEngine.UI;

public class TeachManager : MonoBehaviour
{
    [SerializeField] public bool isOpen;
    [SerializeField] public int nowNumber;
    [SerializeField] private GameObject[] teacjObj;
    [SerializeField] private GameObject[] Buttons;

    [SerializeField] private Image[] TargetImage;
    [SerializeField] private Sprite onsprite;
    [SerializeField] private Sprite offsprite;

    // Start is called before the first frame update
    async void Start()
    {
        var HPSet = FindObjectOfType<GameStart_HPSet>();
        HPSet.OnStartSet();
        await Task.Delay(500); OpenTeach();
    }
    void update()
    {
        
    }
    public void OpenTeach()
    {
        chang_target_image();
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
                chang_target_image();
            }
        }
        else
        {

            for (int i = 0; i < teacjObj.Length; i++)
            {
                teacjObj[i].SetActive(false);
                chang_target_image();
            }
            teacjObj[nowNumber].SetActive(true);
        }
    }

    private void LoopCheck()
    {
        if (nowNumber >= teacjObj.Length)
        {
            nowNumber = teacjObj.Length - 1;
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
            if (nowNumber >= teacjObj.Length - 1)
            {
                Buttons[2].SetActive(false);
            }
            else
            {
                Buttons[2].SetActive(true);
            }
        }
    }
    public void chang_target_image()
    {
        if (nowNumber == 0)
        {
            TargetImage[0].sprite = onsprite;
            TargetImage[1].sprite = offsprite;
            TargetImage[2].sprite = offsprite;
        }

        if (nowNumber == 1)
        {
            TargetImage[0].sprite = offsprite;
            TargetImage[1].sprite = onsprite;
            TargetImage[2].sprite = offsprite;
        }

        if (nowNumber == 2)
        {
            TargetImage[0].sprite = offsprite;
            TargetImage[1].sprite = offsprite;
            TargetImage[2].sprite = onsprite;
        }
    }
}

