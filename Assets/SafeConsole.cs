using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeConsole : MonoBehaviour
{
    public Task_LockHiddenCode task;
    public Text codeScreen;
    public Button num1;
    public Button num2;
    public Button num3;
    public Button num4;
    public Button num5;
    public Button num6;
    public Button num7;
    public Button num8;
    public Button num9;
    public Button ok;
    public Button reset;

    void Start()
    {
        num1.onClick.AddListener(() => { UpdateCode(1); });
        num2.onClick.AddListener(() => { UpdateCode(2); });
        num3.onClick.AddListener(() => { UpdateCode(3); });
        num4.onClick.AddListener(() => { UpdateCode(4); });
        num5.onClick.AddListener(() => { UpdateCode(5); });
        num6.onClick.AddListener(() => { UpdateCode(6); });
        num7.onClick.AddListener(() => { UpdateCode(7); });
        num8.onClick.AddListener(() => { UpdateCode(8); });
        num9.onClick.AddListener(() => { UpdateCode(9); });
        ok.onClick.AddListener(ConfirmCode);
        reset.onClick.AddListener(ResetCode);
        codeScreen.text = "";
    }
    void UpdateCode(int number)
    {
        if (codeScreen.text.Length < 4)
        {
            codeScreen.text += number;
            codeScreen.color = Color.white;
        }
    }
    void ResetCode()
    {
        codeScreen.text = "";
        codeScreen.color = Color.white;
    }
    void ConfirmCode()
    {
        if (codeScreen.text == task.code)
        {
            Debug.Log("TASK DONE");
            codeScreen.color = Color.green;
        }
        else
        {
            codeScreen.color = Color.red;
        }
    }
}
