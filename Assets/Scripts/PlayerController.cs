using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float ForcaDoPulo = 10f;
    public AudioClip somPulo;
    public AudioClip somMorte;

    private Animator anim;
    private Rigidbody rb;
    private bool pulando = false;
    private AudioSource audioSource;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
            anim.Play("pulando");
            audioSource.PlayOneShot(somPulo);
            rb.useGravity = true;
            pulando = true;
        }
	}

    // tudo relacionado a fisica fica aqui
    void FixedUpdate() {
        if (pulando) {
            pulando = false;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * ForcaDoPulo, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision outro) {
        if (outro.gameObject.tag == "obstaculo");
        rb.AddForce(new Vector3(-50f, 20f, 0f), ForceMode.Impulse);
        rb.detectCollisions = false;
        anim.Play("morrendo");
        audioSource.PlayOneShot(somMorte);
    }
}
