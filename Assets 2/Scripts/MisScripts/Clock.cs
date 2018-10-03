using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    public float timeToSurvie;

    public Text timerUi;

    public bool isWin;



    // Use this for initialization
    void Start()
    {
        isWin = false;
        StartCoroutine(Timer());
    }


    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator Timer()
    {
        for (float i = 0; i < timeToSurvie; i = +Time.fixedTime)
        {
            int fixedNum = Mathf.RoundToInt(i);
            timerUi.text = "" + fixedNum;
            yield return null;
        }

        GameManager.Instance.FinJuego();
    }

}
