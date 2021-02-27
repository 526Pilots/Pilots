using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveVertical * speed * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.right * moveHorizontal * speed * Time.fixedDeltaTime, Space.World);

        Vector3 mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(mousePo.x, 0, mousePo.z));
        transform.Rotate(90,0,0);
		
		 Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		        rb.velocity = movement * speed;
		
		        rb.position = new Vector3
		        (
		        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
		        0.0f,
		        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		        );

    }
	
	void OnTriggerEnter(Collider other)
	{
	if (other.tag == "Buff") {
		fireRate = 0.2f;
		Destroy(other.gameObject);
		
	}
	}
}