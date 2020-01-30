using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Basics;

public abstract class Timer : MonoBehaviour
{
    public int seconds;
    public Text text;

    public Manager manager;

    protected bool started;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    public abstract void init();
    public void begin()
    {
        
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(--seconds == 0)
                break;
        }

        manager.timeout();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("" + seconds);
    }

    public int getTime()
    {
        return seconds;
    }
}
