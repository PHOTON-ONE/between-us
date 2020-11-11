using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TaskInteraction : MonoBehaviour
{
    public PlayerMovement movement;
    public Button btn;
    public UISelector UISelector;
    public string taskName;
    public KeyCode InteractionButton;
    bool isInTask=false;
    bool isOutTaskArea = false;
    Canvas taskUI;

    private void Start()
    {
        btn.onClick.AddListener(OpenTaskUI);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Task")
        {
            taskUI = coll.GetComponent<UISelector>().ConnectedUI;
            taskName = coll.name;
            isInTask = true;
            btn.interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {    
        if (coll.tag == "Task")
        {
            isInTask = false;
            btn.interactable = false;
        }
        if (taskUI.enabled)
        {
                btn.interactable = true;
                isInTask = true;
                isOutTaskArea = true;
        }
    }
    private void Update()
    {
        if (isInTask)
        {
            if (Input.GetKeyDown(InteractionButton))
            {
                OpenTaskUI();
            }
        }
    }

    void OpenTaskUI()
    {
        if (!taskUI.enabled)
        {
            movement.enabled = false;
            taskUI.enabled = true;
        }
        else if (taskUI.enabled)
        {
            movement.enabled = true;
            taskUI.enabled = false;
            if (isOutTaskArea)
            {
                btn.interactable = false;
                isInTask = false;
                isOutTaskArea = false;
            }
        }
    }
}
