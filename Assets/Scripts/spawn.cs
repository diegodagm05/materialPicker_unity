using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject power;
    public GameObject rock;
    public float xPos, yPos;

    public int spawnProb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {            
            spawnProb = Random.Range(1,10);
            xPos = Random.Range(-8, 8);
            yPos = 6;
            if(spawnProb <= 2)
                Instantiate(power, new Vector3(xPos, yPos, 0), Quaternion.identity);
            else{
                Instantiate(rock, new Vector3(xPos, yPos, 0), Quaternion.identity);
            }            
            yield return new WaitForSeconds(1);
        }
    }
}
