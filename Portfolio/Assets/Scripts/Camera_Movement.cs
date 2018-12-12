using UnityEngine;
using System.Collections;

public class Camera_Movement : MonoBehaviour
{
    public Vector3 offset;

    private GameObject focus;
    private bool stopUpdate;

    public void ChangeFocus(GameObject newFocusCharacter)
    {
        StartCoroutine(LerpPosition(newFocusCharacter));
    }

    public void SetFocus(GameObject focusCharacter)
    {
        focus = focusCharacter;
    }

    private IEnumerator LerpPosition(GameObject newFocusCharacter)
    {
        stopUpdate = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = newFocusCharacter.transform.position + offset;
        float elapsedTime = 0.0f;
        float lerpTime = 0.0f;

        while (true)
        {
            elapsedTime += Time.deltaTime;

            lerpTime = elapsedTime / .64f;

            transform.position = Vector3.Slerp(startPosition, targetPosition, lerpTime);

            if (lerpTime >= 1.0f)
            {
                stopUpdate = false;
                focus = newFocusCharacter;
                break;
            }

            yield return null;
        }
    }

    // Use this for initialization
    void Start()
    {
        transform.rotation = Quaternion.Euler(30.0f, 45.0f, 0.0f);
        stopUpdate = false;

        FogOfWar_Manager.Instance.RevealArea();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopUpdate == true) return;

        transform.position = focus.transform.position + offset;
    }
}
