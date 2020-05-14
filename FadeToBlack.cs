using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public bool doneFading;
    public bool screenIsBlacked;
    bool fade;
    float alpha;
    float targetAlpha;

    GameObject screen;
    SpriteRenderer screenSprite;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        doneFading = (alpha == targetAlpha);
        screenIsBlacked = (alpha == 1);
        if (fade)
        {
            alpha = screenSprite.color.a;
            if (alpha != targetAlpha)
            {
                float newAlpha = Mathf.MoveTowards(alpha, targetAlpha, 1 * Time.deltaTime);
                screenSprite.color = new Color(screenSprite.color.r, screenSprite.color.g, screenSprite.color.b, newAlpha);
            }
            else
            {
                if (targetAlpha == 0)
                {
                    DestroyScreen();
                }
                fade = false;
            }
        }
    }

    public void FadeInScreen()
    {
        targetAlpha = 1;
        CreateScreen();
        fade = true;
    }

    public void FadeOutScreen()
    {
        targetAlpha = 0;
        fade = true;
    }

    void CreateScreen()
    {
        screen = new GameObject();
        screenSprite = screen.AddComponent<SpriteRenderer>();

        Texture2D spriteTexture = new Texture2D(512, 512, TextureFormat.RGB24, false);
        Rect spriteRect = new Rect(screen.transform.position, new Vector2(32, 32));
        Color spriteColor = new Color(.2f, .2f, .2f, 1);
        Sprite s = Sprite.Create(spriteTexture, spriteRect, screen.transform.position + new Vector3(.5f, .5f, 0), 32);

        screenSprite.color = spriteColor;
        screenSprite.sortingOrder = 999;
        screen.transform.parent = Camera.main.transform;
        screen.transform.localPosition = new Vector3(0, 0, 1);
        screen.transform.localScale = new Vector3(20, 20, 1);
        screenSprite.sprite = s;

        screen.name = "screen";
        spriteColor.a = 0;
        screenSprite.color = spriteColor;
    }

    void DestroyScreen()
    {
        Destroy(screen);
        screen = null;
        screenSprite = null;
        fade = false;

    }
}
