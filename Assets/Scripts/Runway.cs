using UnityEngine;
using UnityEngine.UI;

public class Runway : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private GameObject scoreText;

    private void OnTriggerEnter(Component other)
    {
        if(!other.tag.Equals("Player")) return;
        GameManager.Instance.Score = score;
        scoreText.GetComponent<Text>().text += score.ToString();
        Time.timeScale = 0;
    }
    
}
