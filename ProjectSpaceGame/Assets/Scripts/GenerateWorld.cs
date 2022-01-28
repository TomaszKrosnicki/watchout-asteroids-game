using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] float xWidth = 36f;
    [SerializeField] float yHight = 22f;
    [SerializeField] float distanceBS = 20f;
    [SerializeField] float maxAstScale = 3f;

    public static GenerateWorld gw;

    void Awake() 
    {
        gw = this;
    }

    void Start() 
    {
        for (int i = 0; i < 20; i++)
        {
            GenerateSectors();
        }
    }

    public void GenerateSectors()
    {
        GameObject c = Pool.singleton.GetRandom();
        if (c == null) return;
        float xPos = Random.Range(-xWidth, xWidth);
        float yPos = Random.Range(-yHight, yHight);

        if (c.tag == "Asteroid")
        {
            float aScale = Random.Range(1f, maxAstScale);
            float aRotationX = Random.Range(0f, 360f);
            float aRotationY = Random.Range(0f, 360f);
            float aRotationZ = Random.Range(0f, 360f);
            Quaternion rot = Quaternion.Euler(aRotationX, aRotationY, aRotationZ);
            c.transform.localScale = new Vector3(aScale, aScale, aScale);
            c.transform.rotation = rot;
        }
        c.SetActive(true);
        c.transform.position = transform.position + new Vector3(xPos, yPos);
        transform.position += new Vector3(0, 0, distanceBS);
    }
}
