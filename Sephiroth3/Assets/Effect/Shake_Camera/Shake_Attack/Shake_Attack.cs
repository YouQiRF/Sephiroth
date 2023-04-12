using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Attack : MonoBehaviour
{

    /*#region Instance
    static public Shake instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion */

    [SerializeField] public bool start_attack = false;
    [Header("晃動幅度")]
    [SerializeField] public AnimationCurve curve;
    [Header("晃動時長")]
    [SerializeField] public float duration;

    void Update()
    {
        if (start_attack)
        {
            start_attack = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition =new Vector3(0,0,-12);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Camera.main.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        Camera.main.transform.position = startPosition;
    }
}

