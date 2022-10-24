using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlectableUIController : MonoBehaviour
{
    public SlectableUIObject[] mContent;
    private int mSelectedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        mContent = GetComponentsInChildren<SlectableUIObject>();
        mContent[0].Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //mContent[Mathf.Abs(mSelectedIndex % (mContent.Length))].Deselect();
            //mContent[Mathf.Abs(--mSelectedIndex % (mContent.Length))].Select();
            if (mSelectedIndex - 1 >= 0)
            {
                mContent[mSelectedIndex].Deselect();
                mContent[--mSelectedIndex].Select();
            }
            else
            {
                mContent[mSelectedIndex].Deselect();
                mSelectedIndex = mContent.Length - 1;
                mContent[mSelectedIndex].Select();
            }

        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //mContent[Mathf.Abs(mSelectedIndex % (mContent.Length))].Deselect();
            //mContent[Mathf.Abs(++mSelectedIndex % (mContent.Length))].Select();
            if (mSelectedIndex + 1 < mContent.Length)
            {
                mContent[mSelectedIndex].Deselect();
                mContent[++mSelectedIndex].Select();
            }
            else
            {
                mContent[mSelectedIndex].Deselect();
                mSelectedIndex = 0;
                mContent[mSelectedIndex].Select();
            }

        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            mContent[mSelectedIndex].Confirm();
        }
    }
}
