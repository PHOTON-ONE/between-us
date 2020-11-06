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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            ground = "Default";
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Floor")&&(ground!=collision.name))
        {
            ground = collision.name;
        }
    }
    
    private void Update()
    {
        PlaySounds();
    }
    public void PlaySounds()
    {
        
        if ((ground == "Default") && (player.isMoving) && (player.enabled))
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
        if ((ground == "Metal") && (player.isMoving) && (player.enabled))
        {
            if (!SetDelay())
            {
                if (index > 4)
                {
                    index = 1;
                }
                FindObjectOfType<AudioManager>().Play("Metal" + index);
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
