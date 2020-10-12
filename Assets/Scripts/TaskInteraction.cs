using UnityEngine;
using UnityEngine.UI;

public class TaskInteraction : MonoBehaviour
{
    public Button btn;
    public Canvas taskUI;
    private Collider2D collid;
    public string taskName;

    private void Start()
    {
        btn.onClick.AddListener(OpenTaskUI);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Task")
        {
            collid = coll;
            taskName = this.collid.name;       
            btn.interactable = true;
            Debug.Log("Enter task");
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {    
        if (coll.tag == "Task")
        {
            btn.interactable = false;
            Debug.Log("Exit task");
        }
    }

    void OpenTaskUI()
    {
        if (!taskUI.enabled)
        {
            taskUI.enabled = true;
        }
        else if (taskUI.enabled)
        {
            taskUI.enabled = false;
        }
    }
}
