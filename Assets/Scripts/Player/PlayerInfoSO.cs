using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "ScriptableObjects/PlayerInfoSO", order = 1)]
public class PlayerInfoSO : ScriptableObject
{

    public GameObject _TruckPrefab;

    public Vector3 truckPosition;

    public Quaternion truckRotation;
}