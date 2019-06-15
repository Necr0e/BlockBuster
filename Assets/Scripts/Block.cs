using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //Config params
    [SerializeField] AudioClip blockBreakSound = null;
    [SerializeField] GameObject BlockImpactVFX = null;
    [SerializeField] Sprite[] hitSprites = null;

    //Cache refs
    Level level;
    GameStatus gameStatus;

    //State vars
    int timesHit = 0;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        //Add 1 to total number of blocks when creating a block
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddScore();
        SpawnImpactEffect();
        Destroy(gameObject);
    }

    private void SpawnImpactEffect()
    {
        GameObject blockExplosion = Instantiate(BlockImpactVFX, transform.position, transform.rotation);
        Destroy(blockExplosion, 1f);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is null");
        }

    }
}

