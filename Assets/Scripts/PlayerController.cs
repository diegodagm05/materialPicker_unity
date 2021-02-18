
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    float horizontal;
    public float speed = 6f;
    public int scoreVal = 0;
    public int shootVal = 0;
    public Text score;
    public Text shoot;

    public float distanceRay;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        score.text = ("Picked: ") + scoreVal.ToString();
        shoot.text = ("Shooted: ") + shootVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector3 position = rigidbody.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        
        //Raycast start
        if(Input.GetKey(KeyCode.Space))
        {
            RaycastHit hit;
            Vector3 up = transform.TransformDirection(Vector3.up);
            
            //Ray to check it is correctly raycasting
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * distanceRay, Color.red);
    
            if (Physics.Raycast(transform.position, up, out hit, distanceRay))
            {
                Destroy(hit.transform.gameObject);
                shootVal++;
                shoot.text = ("Shooted: ") + shootVal.ToString();
            }
        }
        //Raycast end

        if(position.x<-9)
        {
            position.x = -9;
        }
        if(position.x>9)
        {
            position.x = 9;
        }
        rigidbody.MovePosition(position);


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Rock")
        {   
            Destroy(collision.gameObject);
            scoreVal++;
            score.text = ("Picked: ") + scoreVal.ToString();
        }
        else if (collision.tag == "Power")
        {
            Destroy(collision.gameObject);
            StartCoroutine(PowerPicked());
        }
    }

    IEnumerator PowerPicked()
    {
        Vector3 pow = new Vector3(transform.localScale.x*2, transform.localScale.y, transform.localScale.z);
        transform.localScale = pow;
        yield return new WaitForSeconds(6f);
        pow = new Vector3(transform.localScale.x/2, transform.localScale.y, transform.localScale.z);
        transform.localScale = pow;
    } 

}