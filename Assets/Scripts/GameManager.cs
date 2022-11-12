using GeneralScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private GameObject parachute;
    [SerializeField] private Transform characterHolder;
    [SerializeField] private Transform camera;
    [SerializeField] private float sppedOfParachuteOpeningAnimation;
    private int _score;
    private Vector3 _targetCharacterParachuteRota, _startCharacterParachuteRota;
    private Vector3 _targetParachuteScale, _startParachuteScale;
    private Vector3 _targetCameraPos, _startCameraPos;
    private float _lerpValue;

    private void Start()
    {
        _targetCharacterParachuteRota = new Vector3(-90, 0, 0);
        _targetParachuteScale = new Vector3(1, 1, 1);
        _targetCameraPos = new Vector3(0, 306, -140);
        _startCameraPos = camera.position;
        _startParachuteScale = parachute.transform.localScale;
        _startCharacterParachuteRota = characterHolder.localEulerAngles;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
    public void OpenParachute()
    { 
        CharacterPhysic.Instance.SetIsParachuteOpen(true);
        parachute.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (CharacterPhysic.Instance.GetIsParachuteOpen() && _lerpValue < 1)
        {
            characterHolder.localEulerAngles=Vector3.Lerp(_startCharacterParachuteRota,_targetCharacterParachuteRota
                ,_lerpValue+=sppedOfParachuteOpeningAnimation);
            parachute.transform.localScale=Vector3.Lerp(_startParachuteScale,_targetParachuteScale,_lerpValue);
            camera.position=Vector3.Lerp(_startCameraPos,_targetCameraPos,_lerpValue);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}
