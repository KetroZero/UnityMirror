using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(LineRenderer))]
public class ColorGate : MonoBehaviour
{
    private GameObject player;

    public Material lineMaterial;
    public ColorManager manager;

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
            manager.SetNextColor();
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
        int nbPoints = 200;
        float width = 0.2f;
        float radius = this.GetComponent<CapsuleCollider>().radius;
        Material color = lineMaterial;

        LineRenderer lr = this.GetComponent<LineRenderer>();

        lr.SetVertexCount(nbPoints);
        lr.SetWidth(width, width);
        lr.material = color;
        lr.useWorldSpace = false;

        for (int i = 0; i < nbPoints; i++)
        {
            float x = radius * Mathf.Cos(4 * i * Mathf.PI / nbPoints);
            float y = 1.00f * i / nbPoints - 0.5f;
            float z = radius * Mathf.Sin(4 * i * Mathf.PI / nbPoints);
            lr.SetPosition(i, new Vector3(x, y, z));
        }
    }

    private void MoveToNewPosition()
    {
        Vector3 destination = new Vector3(Random.Range(10, 90), 1, Random.Range(10, 90));
        this.transform.localPosition = destination;
    }

}
