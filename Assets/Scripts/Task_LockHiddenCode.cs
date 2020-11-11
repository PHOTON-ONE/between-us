using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_LockHiddenCode : MonoBehaviour
{
    public Text hiddenCode;
    [HideInInspector]
    public string code;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            code += Random.Range(1, 9);
        }
        hiddenCode.text = code;
    }
}
