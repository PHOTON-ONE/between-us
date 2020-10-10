using UnityEngine;
using UnityEngine.UI;

public class TaskInteraction : MonoBehaviour
{
    public Button btn;
    public Canvas taskUI;
    private Collider2D collid;
    public string taskName;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Task")
        {
            collid = coll;
            taskName = this.collid.name;
            btn.onClick.AddListener(OpenTaskUI);  
            btn.interactable = true;
            Debug.Log("Enter");
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Task")
        {
            btn.interactable = false;
            Debug.Log("Exit");
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
