using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(LineRenderer))]
public class ColorGate : MonoBehaviour
{
    private GameObject player;

    public Material lineMaterial;
    public ColorManager manager;
    public int index = 1;

    // Use this for initialization
    void Start()
    {
        player = manager.player;
        DrawCircle();
    }

    void OnTriggerEnter(Collider enter)
    {
        if (enter.gameObject == player)
        {
            if (index == 1)
            {
                manager.SetNextColor(1, 2);
                Position1();
            }
            if (index == 2)
            {
                manager.SetNextColor(3, 6);
                Position2();
            }

            NoticeChange(Camera.main);
            MoveToNewPosition();
        }
    }


    private void NoticeChange(Camera cameraToTilt)
    {
        if (cameraToTilt.GetComponent<Animator>())
        {
            cameraToTilt.GetComponent<Animator>().SetTrigger("playerEnter");
        }
        else
        {
            Debug.Log("No [Animator] component found.");
        }
    }

    private void DrawCircle()
    {
        int nbPoints = 400;
        float width = 0.1f;
        float radius = this.GetComponent<CapsuleCollider>().radius;
        Material color = lineMaterial;

        LineRenderer lr = this.GetComponent<LineRenderer>();

        lr.SetVertexCount(nbPoints);
        lr.SetWidth(width, width);
        lr.material = color;
        lr.useWorldSpace = false;

        for (int i = 0; i < nbPoints; i++)
        {
            float x = radius * Mathf.Cos(8 * i * Mathf.PI / nbPoints);
            float y = 1.00f * i / nbPoints - 0.5f;
            float z = radius * Mathf.Sin(8 * i * Mathf.PI / nbPoints);
            lr.SetPosition(i, new Vector3(x, y, z));
        }
    }

    private void MoveToNewPosition()
    {
        if (index > 0 && index < 4)
        {
            Invoke("Position" + index, Time.deltaTime);
        }
        else
        {
            Debug.Log("Wrong index in MoveToNewPosition()");
        }
    }

    private void Position1()
    {
        Vector3 destination = new Vector3(Random.Range(38.5f, 65), 1, Random.Range(61.6f, 44.5f));
        this.transform.localPosition = destination;
    }
    private void Position2()
    {
        Vector3 destination = new Vector3(Random.Range(57.5f, 98), 1, Random.Range(13.5f, 1.2f));
        this.transform.localPosition = destination;
    }

}
