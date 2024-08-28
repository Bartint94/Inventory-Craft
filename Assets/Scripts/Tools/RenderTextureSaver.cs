using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class RenderTextureSaver : MonoBehaviour
{
    // Public reference to the RenderTexture to be saved
    public RenderTexture renderTexture;

    // Path where the image will be saved
    public string filePath = "Assets/SavedRenderTexture.png";

    [ContextMenu("Save RenderTexture To PNG")]
    public void SaveRenderTextureToPNG()
    {
        if (renderTexture == null)
        {
            Debug.LogError("RenderTexture is not assigned.");
            return;
        }

        // Upewnij si�, �e format RenderTexture obs�uguje przezroczysto��
        if (renderTexture.format != RenderTextureFormat.ARGB32 &&
            renderTexture.format != RenderTextureFormat.DefaultHDR &&
            renderTexture.format != RenderTextureFormat.ARGBHalf)
        {
            Debug.LogError("RenderTexture format does not support alpha. Please use ARGB32, DefaultHDR, or ARGBHalf.");
            return;
        }

        // Stw�rz now� Texture2D z formatem RGBA32
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

        // Skopiuj piksele z RenderTexture do Texture2D
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // Zapisz tekstur� do pliku PNG
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);

        // Wyczy��
        RenderTexture.active = null;
        DestroyImmediate(texture);

        Debug.Log("RenderTexture saved as PNG to: " + filePath);
    }
}
