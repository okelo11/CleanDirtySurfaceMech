using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{ public Texture2D _dirtMaskBase, _brush;
  public  Texture2D _templateDirtMask;
    public Material _material;
    

    // Start is called before the first frame update
    void Start()
    {
        CreateTexture();
    }

   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector2 textureCoord = hit.textureCoord;
                Debug.Log(textureCoord * new Vector2(_templateDirtMask.width, _templateDirtMask.height));
                

                int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
                int pixelY = (int)(textureCoord.y * _templateDirtMask.height);
                //  int pixelX = (int)(textureCoord.x * 512);
                // int pixelY = (int)(textureCoord.y * 512);
                //for (int x = 0; x < _brush.width; x++)
                //{
                //    for (int y = 0; y < _brush.height; y++)
                //    {
                //        Color pixelDirt = _brush.GetPixel(x, y);
                //        Color pixelDirtMask = _templateDirtMask.GetPixel(pixelX + x, pixelY + y);

                //        _templateDirtMask.SetPixel(pixelX + x, pixelY + y, new Color(pixelDirtMask.r * pixelDirt.r, pixelDirtMask.g * pixelDirt.g, pixelDirtMask.b * pixelDirt.b));
                //    }
                //}
                for (int u = 0; u < _brush.width/2; u++)
                {
                    for (int v = 0; v < _brush.height/2; v++)
                    {
                        Color brushPixel = _brush.GetPixel(_brush.width / 2, _brush.height / 2);//brush center
                        Color pixelMask = _templateDirtMask.GetPixel(pixelX + u, pixelY + v);
                        _templateDirtMask.SetPixel(pixelX + u, pixelY + v, new Color(_templateDirtMask.GetPixel(pixelX + u, pixelY + v).r * _brush.GetPixel(_brush.width/2+u,_brush.height/2+v).r, _templateDirtMask.GetPixel(pixelX + u, pixelY + v).g * _brush.GetPixel(_brush.width / 2 + u, _brush.height / 2 + v).g, _templateDirtMask.GetPixel(pixelX + u, pixelY + v).b * _brush.GetPixel(_brush.width / 2 + u, _brush.height / 2 + v).b));
                        _templateDirtMask.SetPixel(pixelX + u, pixelY - v, new Color(_templateDirtMask.GetPixel(pixelX + u, pixelY - v).r * _brush.GetPixel(_brush.width / 2 + u, _brush.height / 2 - v).r, _templateDirtMask.GetPixel(pixelX + u, pixelY - v).g * _brush.GetPixel(_brush.width / 2 + u, _brush.height / 2 - v).g, _templateDirtMask.GetPixel(pixelX + u, pixelY - v).b * _brush.GetPixel(_brush.width / 2 + u, _brush.height / 2 - v).b));
                        _templateDirtMask.SetPixel(pixelX - u, pixelY + v, new Color(_templateDirtMask.GetPixel(pixelX - u, pixelY + v).r * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 + v).r, _templateDirtMask.GetPixel(pixelX - u, pixelY + v).g * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 + v).g, _templateDirtMask.GetPixel(pixelX - u, pixelY + v).b * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 + v).b));
                        _templateDirtMask.SetPixel(pixelX - u, pixelY - v, new Color(_templateDirtMask.GetPixel(pixelX - u, pixelY - v).r * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 - v).r, _templateDirtMask.GetPixel(pixelX - u, pixelY - v).g * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 - v).g, _templateDirtMask.GetPixel(pixelX - u, pixelY - v).b * _brush.GetPixel(_brush.width / 2 - u, _brush.height / 2 - v).b));



                    }

                }
              

                _templateDirtMask.Apply();
                _material.SetTexture("_Mask", _templateDirtMask);

            }
        }


    }

    void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels32(_dirtMaskBase.GetPixels32());
        _templateDirtMask.Apply();
        _material.SetTexture("_Mask", _templateDirtMask);
        
        
    }
}

