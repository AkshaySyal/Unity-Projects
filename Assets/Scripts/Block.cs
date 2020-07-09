using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip[] Audio;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    Level level;

    [SerializeField] int timesHit=0; //serialised for debug purposes

    private void Start()
    {
        CountBreakableBlocks();

    }
    

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag=="Unbreakable")
        {
            FindObjectOfType<Ball>().PlayNeutralSnd();
            
        }


        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
                DestroyBlock();
            else
            {
                FindObjectOfType<Ball>().PlayCrackingSnd();
                ShowNextHitSprite();
            }
                
        }
        
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        else
            Debug.LogError("Block sprite is missing from array");
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(Audio[0], Camera.main.transform.position);
        FindObjectOfType<Level>().BlockDestroyed();
        
        FindObjectOfType<GameSession>().AddToScore();
        
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
