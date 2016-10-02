using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{

    public GameObject player;
    public SkinnedMeshRenderer playerColor;
    public Material[] characterColor;
    public Material brokenMaterial;


    private int playerColorIndex = 0;
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
        AdminDebug();
    }

    public void SetNextColor()
    {
        int index = (playerColorIndex + 1) % characterColor.Length; // all colour, incremental

        playerColor.material = characterColor[index];
        playerColorIndex = index;
    }

    public void SetNextColor(int start, int end)
    {

        if (CheckColorError(start, end))
        {
            return;
        }
        else
        {
            //int mod = 1 + end - start;
            //int index = (playerColorIndex + 1) % characterColor.Length; // all colour, incremental
            //int index = (start - 1) + (playerColorIndex + 1) % mod;
            //Debug.Log("index" + index + " -- color " + playerColorIndex + " -- mod " + mod);

            int index = 0;

            if (playerColorIndex >= start && playerColorIndex + 1 <= end)
            {
                index = playerColorIndex + 1;
            }
            else
            {
                index = start;
            }

            playerColor.material = characterColor[index];
            playerColorIndex = index;
        }
    }

    private bool CheckColorError(int start, int end)
    {
        bool error = false;

        if (start >= characterColor.Length)
        {
            Debug.Log("Error in SetNextColor(int start, int end), [start] is [" + start + "] but max value is [" + (characterColor.Length - 1) + "]");
            error = true;
        }
        if (end >= characterColor.Length)
        {
            Debug.Log("Error in SetNextColor(int start, int end), [end] is [" + end + "] but max value is [" + (characterColor.Length - 1) + "]");
            error = true;
        }
        if (start > end)
        {
            Debug.Log("Error in SetNextColor(int start, int end), [start] is greater than [end] [" + start + "] > [" + end + "]");
            error = true;
        }

        return error;
    }


    private void AdminDebug()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SetNextColor();
                Debug.Log("Player colour [" + playerColorIndex + " - " + characterColor[playerColorIndex] + "]");
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                bool active = !player.GetComponent<CapsuleCollider>().enabled;

                player.GetComponent<CapsuleCollider>().enabled = active;
                player.GetComponent<Rigidbody>().useGravity = active;
                Camera.main.GetComponent<SphereCollider>().enabled = active;

                Debug.Log("Player collider [" + (active ? "on" : "off") + "]");
            }
        }
    }
}
