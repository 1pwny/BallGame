using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Cam : MonoBehaviour
{
    public GameObject character;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - character.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = character.transform.position + offset;
    }
}
