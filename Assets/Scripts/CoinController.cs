using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody rb;
	private float timer = 0f;
    private float time = 8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    	timer += Time.deltaTime;
    	if (timer >= time) GameObject.Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Destroy(gameObject);     
        }
    }
}
