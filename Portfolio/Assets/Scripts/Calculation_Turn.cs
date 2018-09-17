using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Calculation/Turn", order = 2)]
public class Calculation_Turn : ScriptableObject
{
    public Quaternion LerpRotation(int startX, int startZ, int endX, int endZ, Quaternion startingRotation, float lerpTime)
    {
        int horizontal = endX - startX;
        int vertical = endZ - startZ;

        bool diagonal = (Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 2) ? true : false;

        float angle = startingRotation.y;

        // (vert != 0) && (horiz != 0)
        if (diagonal == true)
        {
            // northward
            if (vertical > 0)
            {
                angle = 0.0f;
                angle += 45.0f * (float)horizontal;
            }
            // southward (vert < 0)
            else
            {
                angle = 180.0f;
                angle += -45.0f * (float)horizontal;
            }
        }
        // (vert == 0) || (horiz == 0)
        else
        {
            // horiz == 0
            if (vertical != 0) angle = (vertical > 0) ? 0.0f : 180.0f;
            // vert == 0
            else angle = (horizontal > 0) ? 90.0f : -90.0f;
        }

        return Quaternion.Lerp(startingRotation, Quaternion.Euler(0.0f, angle, 0.0f), lerpTime);
    }
}
