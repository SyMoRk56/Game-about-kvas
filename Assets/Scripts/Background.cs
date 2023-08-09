using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public RawImage background;
    public float x, y;
    public Texture[] sprites;
    
    private void FixedUpdate()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x, y) * Time.deltaTime, background.uvRect.size);
    }
    public void ChangeTexture(int index)
    {
        background.texture = sprites[index];
    }
}
