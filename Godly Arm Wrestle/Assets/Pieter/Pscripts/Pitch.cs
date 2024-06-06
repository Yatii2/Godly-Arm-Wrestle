using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.pitch = Random.Range(0.1f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // You don't need anything here
    }
}