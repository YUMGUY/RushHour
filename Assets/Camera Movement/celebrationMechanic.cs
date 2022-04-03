using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celebrationMechanic : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem confetti;
    void Start()
    {
        confetti = GetComponent<ParticleSystem>();
        var em = confetti.emission;
        confetti.Pause();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
        {
            confetti.Play();
        } 
    }
}
