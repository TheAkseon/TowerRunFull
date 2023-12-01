using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    [SerializeField] private float _jumpBoostMultiplayer;

    public float JumpBoostMultiplayer => _jumpBoostMultiplayer;
}
