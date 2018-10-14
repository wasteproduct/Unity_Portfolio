using UnityEngine;
using Player;

public class Camera_Movement : MonoBehaviour
{
    public Vector3 offset;

    private GameObject focus;

    public void SetFocus(GameObject focusCharacter)
    {
        focus = focusCharacter;
    }

    // Use this for initialization
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = focus.transform.position + offset;
    }
}
