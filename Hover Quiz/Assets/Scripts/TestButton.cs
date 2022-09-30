using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField]
    LevelBox levelBox;

    public void TestClick()
    {
        levelBox.UpdateProgress(0.1f);
    }
}
