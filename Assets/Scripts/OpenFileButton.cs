using UnityEngine;
using UnityEngine.UI;

public class OpenFileButton : MonoBehaviour
{
    public Button yourButton;
    public DisplayImage displayImageScript; // 添加对DisplayImage脚本的引用

    void Start()
    {

        yourButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        string path = UnityEditor.EditorUtility.OpenFilePanel("Select an image", "", "image files|*.png;*.jpg;*.jpeg");
        if (!string.IsNullOrEmpty(path) && displayImageScript != null)
        {
            displayImageScript.DisplaySelectedImage(path);
        }
    }
}
