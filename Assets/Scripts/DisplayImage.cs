using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayImage : MonoBehaviour
{
    public Image targetImage;

    public void DisplaySelectedImage(string path)
    {
        if (File.Exists(path))
        {
            byte[] fileData = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            targetImage.sprite = sprite;

            // 使图片适应Image组件的大小
            targetImage.preserveAspect = true;
        }
    }
}
