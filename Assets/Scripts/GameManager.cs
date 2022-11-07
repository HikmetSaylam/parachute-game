using GeneralScripts;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject parachuteCamera;
    [SerializeField] private GameObject parachute;
    [SerializeField] private Transform characterHolder;
    private int _score;

    public int Score
    {
        get => _score;
        set => _score = value;
    }
    public void OpenParachute()
    { 
        CharacterPhysic.Instance.SetIsParachuteOpen(true);
        characterHolder.localEulerAngles = new Vector3(270, 0, 0);
        parachuteCamera.SetActive(true);
        mainCamera.SetActive(false);
        parachute.SetActive(true);
    }
}
