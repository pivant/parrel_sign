using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinking : MonoBehaviour
{

    public CanvasGroup myCG;
    private bool flash = false;


    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            MineHit();
        }
            if (flash)
        {
            myCG.alpha = myCG.alpha - Time.deltaTime * 1.5F;
            if (myCG.alpha <= 0)
            {
                myCG.alpha = 0;
                flash = false;
            }
        }
    }

    public void MineHit()
    {
        flash = true;
        myCG.alpha = 1;
    }
}
