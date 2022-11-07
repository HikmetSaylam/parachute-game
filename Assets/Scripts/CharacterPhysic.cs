using GeneralScripts;
using UnityEngine;

public class CharacterPhysic : MonoSingleton<CharacterPhysic>
{
    [SerializeField] private float gravityForce;
    [SerializeField] private float parachuteGravityForce;
    private float _tmpGravityForce;
    private bool _isParachuteOpen;

    private void Start()
    {
        _tmpGravityForce = 0;
        _isParachuteOpen = false;
    }

    public float Drop()
    {
        if (_isParachuteOpen)
            return -(parachuteGravityForce+=0.001f);
        _tmpGravityForce -= gravityForce;
        return _tmpGravityForce;
    }

    public bool GetIsParachuteOpen()
    {
        return _isParachuteOpen;
    }

    public void SetIsParachuteOpen(bool value)
    {
        _isParachuteOpen = value;
    }
}
