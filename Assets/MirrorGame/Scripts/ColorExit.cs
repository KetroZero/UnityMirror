﻿using UnityEngine;
using System.Collections;

public class ColorExit : MonoBehaviour
{

    private GameObject player;
    private BoxCollider col;
    private Material broken;

    public ColorManager manager;
    // Use this for initialization
    void Start()
    {
        player = manager.player;
        broken = manager.brokenMaterial;
        col = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision enter)
    {
        if (enter.gameObject == player)
        {
            Color currentWall = this.GetComponent<MeshRenderer>().material.color;
            if (CompareWithoutAlpha(currentWall, manager.playerColor.material.color))
            {
                col.enabled = false;
                MeshRenderer wallRenderer = this.GetComponent<MeshRenderer>();
                wallRenderer.material = broken;
                wallRenderer.material.color = currentWall;
            }

        }
    }

    private bool CompareWithoutAlpha(Color c1, Color c2)
    {
        bool r = Mathf.Abs(c1.r - c2.r) < 0.1;
        bool g = Mathf.Abs(c1.g - c2.g) < 0.1;
        bool b = Mathf.Abs(c1.b - c2.b) < 0.1;
        return r && g && b;
    }

}
