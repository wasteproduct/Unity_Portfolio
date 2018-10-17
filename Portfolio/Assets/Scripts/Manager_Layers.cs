using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Layers", order = 2)]
public class Manager_Layers : ScriptableObject
{
    [SerializeField]
    private LayerMask tileMap;

    [SerializeField]
    private LayerMask enemyZone;

    [SerializeField]
    private LayerMask enemy;

    public LayerMask TileMap { get { return tileMap; } }
    public LayerMask EnemyZone { get { return enemyZone; } }
    public LayerMask Enemy { get { return enemy; } }
}
