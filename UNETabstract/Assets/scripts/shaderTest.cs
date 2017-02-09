using UnityEngine;
using System.Collections;


public class CameraRenderTexture : MonoBehaviour
{
	public Material Mat;

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, Mat);
	}
}