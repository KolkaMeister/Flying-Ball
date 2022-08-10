using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block: MonoBehaviour
{
     Level level;
    GameSession gameStatus;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakEffect;
    [SerializeField] Sprite[] damageStage;
    int timesHit;
    public void Start()
    {
        BlockCounter();
    }
    private void BlockCounter()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        level.AmountOfBlocks();
    }
    private void OnCollisionEnter2D(Collision2D colission)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHit = damageStage.Length+1;
            if (timesHit >= maxHit)
            {
                OnBreak();
            }
            else
            {
                SpriteChange();
            }
        }
    }
    private void SpriteChange()
    {
        if (damageStage[timesHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageStage[timesHit - 1];
        }
        else
        {
            Debug.LogError("Ebobo,were are the spries?" + gameObject.name);
        }
    }
    private void OnBreak()
    {
        CallEffect();
        FindObjectOfType<GameSession>().Score();
        level.MinusOne();
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        Destroy(gameObject);
    }
    private void CallEffect()
    {
        GameObject effect = Instantiate(breakEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
    }
}
