using UnityEngine;

public class ExplodeTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem explosion;    //GameObject containing all particle elements
    public GameObject player;
    public float forceMagnitude = 50f;
    private Vector3 explosionCenter;
    void Start()
    {
        explosionCenter = transform.position + new Vector3(0f,0.5f,0f);
    }

    void FixedUpdate() {
        //explosion.Play(true);
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            //Explode
            Vector3 explosionDirection = player.transform.position - explosionCenter;
            explosion.Play(true);

            player.GetComponent<Rigidbody>().AddForce(explosionDirection * forceMagnitude, ForceMode.Impulse);
            //this.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(3).gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("DisableExplosion", 1f);
            Debug.Log("Explosion!");
        }
    }

    void DisableExplosion() {
        this.gameObject.SetActive(false);
    }
}