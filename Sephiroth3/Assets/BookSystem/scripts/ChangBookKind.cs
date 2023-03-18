using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangBookKind : MonoBehaviour
{

    [SerializeField] public Image target_image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickChang(Sprite image)
    {
        target_image.sprite = image;
    }
}
