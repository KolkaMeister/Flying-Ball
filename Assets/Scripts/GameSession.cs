using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
    
{
    [Range(0.1f,5f)][SerializeField] float timeSpeed;
    [SerializeField] int totalScore;
    [SerializeField] int pointsPerHit;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] bool cheating;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Text.text = totalScore.ToString();
    }

    void Update()
    {
        Time.timeScale = timeSpeed;
        Text.text = totalScore.ToString();
    }
    public void Score()
    {
        totalScore += pointsPerHit;
    }
    public void Reset()
    {
        Destroy(gameObject);
    }
    public bool IsCheating()
    {
        return cheating;
    }
}
