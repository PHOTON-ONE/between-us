using UnityEngine;

public class GroundType : MonoBehaviour
{
    public PlayerMovement player;
  //  [HideInInspector]
    public string ground = "Default";
    private void OnTriggerStay2D(Collider2D collision)
    {
        ground = collision.name;
        if(player.isMoving == true)
        {
            Debug.Log("I'am moving!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ground = "Default";
    }
}
