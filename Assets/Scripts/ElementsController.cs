using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
    Rigidbody rigidbody;
    float vertical;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 position = rigidbody.position;
        position.y = position.y - speed * Time.deltaTime;

        rigidbody.MovePosition(position);
        if(position.y<-5)
        {
            Destroy(gameObject);
        }
    }
}