using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{

    public GameObject player;
    public SkinnedMeshRenderer playerColor;
    public Material[] characterColor;
    // Use this for initialization
    void Start()
    {
        if (characterColor.Length < 7)
        {
            Debug.Log(string.Format("Not enough color for the Character: [{0}] expected [7]", characterColor.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNextColor()
    {
        int index = 0;
        for (int i = 0; i < characterColor.Length; i++)
        {
            if (playerColor.material.color == characterColor[i].color)
            {
                index = (i + 1) % characterColor.Length;
                break;
            }
        }

        playerColor.material = characterColor[index];
    }
}
