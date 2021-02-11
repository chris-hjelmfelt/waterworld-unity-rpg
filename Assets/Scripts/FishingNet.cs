using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : Interactable
{   
    public int delayTime = 10;
    public int maxFish = 3;

    public int collected = 0;
    private int timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer < delayTime) 
        {
            timer += 1;
        } else {
            if (collected < maxFish)
                collected += 1;
            timer = 0;
        }
    }
}
