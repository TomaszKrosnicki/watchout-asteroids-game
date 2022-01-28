using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWorld : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "BGasteroid"))
        {
        other.gameObject.SetActive(false);
        GenerateWorld.gw.GenerateSectors();
        }
        if (other.gameObject.tag == "BGasteroid")
        {
            other.gameObject.transform.position += new Vector3(0f, 0f, 900f);
            other.gameObject.SetActive(true);
        }
    }
}