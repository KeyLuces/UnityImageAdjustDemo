using UnityEngine;
using UnityEngine.UI;

public class ImageEffectAdjuster : MonoBehaviour
{
    public Image targetImage; // 目标图像
    public Slider saturationSlider; // 饱和度调节
    public Slider exposureSlider; // 曝光度调节
    //public Slider shadowsSlider; // 阴影调节

    private Material imageMaterial; // 用于应用效果的材质

    void Start()
    {
        // 创建一个新的材质，应用于图像
        imageMaterial = new Material(Shader.Find("ImageEffectsShader"));
        
        // 检测能否找到
        if (imageMaterial != null)
        {
            Debug.Log("非空");
        }
        targetImage.material = imageMaterial;

        // 为每个滑块添加事件监听器
        saturationSlider.onValueChanged.AddListener(SetSaturation);
        exposureSlider.onValueChanged.AddListener(SetExposure);
        // shadowsSlider.onValueChanged.AddListener(SetShadows);
    }

    void SetSaturation(float value)
    {
        imageMaterial.SetFloat("_Saturation", value);
    }

    void SetExposure(float value)
    {
        imageMaterial.SetFloat("_Exposure", value);
    }

    void SetShadows(float value)
    {
        imageMaterial.SetFloat("_Shadows", value);
    }
}
