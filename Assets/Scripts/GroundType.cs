using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class GroundType : MonoBehaviour
{
    public PlayerMovement player;
    public float delay;
    float timeCount;
    int index = 1;
    [HideInInspector]
    public string ground = "Default";
    private void Start()
    {
        timeCount = delay;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ground = collision.name;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ground = "Default";
    }
    private void Update()
    {
        PlaySounds();
    }
    public void PlaySounds()
    {
        
        if ((ground == "Default") && (player.isMoving))
        {
            if(!SetDelay())
            {
                if (index > 5)
                {
                    index = 1;
                }
                FindObjectOfType<AudioManager>().Play("Grass" + index);
                index++;
            }
        }
    }
    public bool SetDelay()
    {
        if (timeCount < delay)
        {
            timeCount += Time.deltaTime;
            return true;
        }
        else
        {
            timeCount = 0f;
            return false;
        }
    }
}
