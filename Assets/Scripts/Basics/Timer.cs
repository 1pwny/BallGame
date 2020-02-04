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

    public GM manager;

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
        started = true;
        while (started)
        {
            yield return new WaitForSeconds(1);
            seconds--;

            if(started)
                trigger(seconds);

            if (seconds == 0)
                break;
        }

        if(seconds == 0)
            manager.timeout();
    }

    protected abstract void trigger(int sec);

    // Update is called once per frame
    void Update()
    {
        text.text = ("" + seconds);
    }

    public void stop()
    {
        started = false;
    }
    public int getTime()
    {
        return seconds;
    }
}
