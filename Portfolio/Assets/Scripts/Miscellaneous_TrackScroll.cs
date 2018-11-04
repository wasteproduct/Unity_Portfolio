using UnityEngine;

public class Miscellaneous_TrackScroll : MonoBehaviour
{
    private float offset;

    // Use this for initialization
    void Start()
    {
        offset = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (offset >= 1.0f) offset = 0.0f;

        offset += -.64f * Time.deltaTime;

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.0f, offset));
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(0.0f, offset));
    }
}
