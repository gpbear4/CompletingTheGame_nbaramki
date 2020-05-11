using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private EventManager eventManager;
    [SerializeField] private ParticleSystem expParticle;
    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        targetRB = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(-5, 5), -5);
        targetRB.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-5, 5), Random.Range(-5, 5),
            Random.Range(-5, 5), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Instantiate(expParticle, transform.position, expParticle.transform.rotation);

        Destroy(gameObject);

        if(CompareTag("Bad Target"))
        {
            //gameManager.UpdateScore(-7);
                eventManager.targetDestroyed.Invoke(-7);
        }
        else if(CompareTag("Good Target"))
        {
            //gameManager.UpdateScore(7);
            eventManager.targetDestroyed.Invoke(7);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
