using UnityEngine;
using UnityEngine.UI;

public class UI_MinimapIcon : MonoBehaviour
{
    [SerializeField]
    private Sprite iconBattle;
    [SerializeField]
    private Sprite iconBoss;
    [SerializeField]
    private Image iconImage;

    public void SetIcon(Vector3 position, bool bossArea)
    {
        FixPosition(position);

        iconImage.sprite = (bossArea == true) ? iconBoss : iconBattle;
    }

    public void FixPosition(Vector3 position) { GetComponent<RectTransform>().position = position; }
}
