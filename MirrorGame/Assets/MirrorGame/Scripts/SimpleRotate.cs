using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour
{

    // Use this for initialization
    public float speed = 20;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
