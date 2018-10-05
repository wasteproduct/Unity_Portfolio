using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Layers", order = 2)]
public class Manager_Layers : ScriptableObject
{
    [SerializeField]
    private LayerMask tileMap;

    [SerializeField]
    private LayerMask enemyZone;

    public LayerMask TileMap { get { return tileMap; } }
    public LayerMask EnemyZone { get { return enemyZone; } }
}
