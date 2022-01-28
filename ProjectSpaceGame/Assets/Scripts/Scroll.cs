using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    float count;
    [SerializeField] float scrollingSpeed = 0.1f;
    void FixedUpdate() 
    {
        if(PlayerState.isDead || GameMenu.gm.exitToMenu)
            {
                count = 0f;
                scrollingSpeed = 0.1f;
                return;
            }
        else if (!PlayerState.isPlaying) return;

        if (this.gameObject.tag == "WorldGenerator")
            transform.Translate(Vector3.back * scrollingSpeed * 5f, Space.World);
        else
            transform.Translate(Vector3.back * scrollingSpeed, Space.World);
    }

    void Update() 
    {
        if (!PlayerState.isPlaying) return;
        count += Time.deltaTime;
        if (count >= 10f)
        {
            scrollingSpeed = scrollingSpeed + (scrollingSpeed * 0.1f);
            count = 0f;
        }
    }
}
