using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public TerrainType[] TerrainTypes;

    [SerializeField]
    private int size;
    [SerializeField]
    float heightRes;
    [SerializeField]
    float scale;


    private void Awake()
    {
        GenerateGrid();
    }
   
    
    
    float[,] NoiseGenerator(int _size, float _scale)
    {
        float[,] noise = new float[_size, _size];
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                float sampleX = x / _scale;
                float sampleY = y / _scale;


                noise[y, x] = Mathf.PerlinNoise(sampleX, sampleY);
               
            }
        }
        return noise;
    }

    private Texture2D SetTexture(float[,] _heightMap)
    {
        int depth = _heightMap.GetLength(0);
        int width = _heightMap.GetLength(1);

        
        Color[] colorArray = new Color[depth * width];
        for (int y = 0; y < depth; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int colorIndex = y * width + x;
                float height = _heightMap[y, x];
                Debug.Log(height);
                TerrainType terrType = ChooseType(height);
                colorArray[colorIndex] = terrType.color;
            }
        }
        Texture2D texture = new Texture2D(width, depth);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorArray);
        texture.Apply();
        return texture;
    }
    private void GenerateGrid()
    {
        int gridSize = size * size;

        Vector3[] vertexbuffer = new Vector3[(size + 1) * (size + 1)];
        int[] indexbuffer = new int[(size) * (size) * 6];

        float[,] heightMap = NoiseGenerator(size+1 , scale);
        Debug.Log(heightMap);
        Texture2D heighttex = SetTexture(heightMap);

        for (int i = 0, y = 0; y <= size; y++)
        {
            for (int x = 0; x <= size; x++, i++)
            {
                vertexbuffer[i] = new Vector3(x, heightMap[x, y] * heightRes,y);
            }


        }

        for (int ti = 0, vi = 0, y = 0; y < size; y++, vi++)
        {
            for (int x = 0; x < size; x++, ti += 6, vi++)
            {
                indexbuffer[ti] = vi;
                indexbuffer[ti + 3] = indexbuffer[ti + 2] = vi + 1;
                indexbuffer[ti + 4] = indexbuffer[ti + 1] = vi + size + 1;
                indexbuffer[ti + 5] = vi + size + 2;
            }

            Mesh mesh = new Mesh();
            mesh.vertices = vertexbuffer;
            mesh.triangles = indexbuffer;
            mesh.RecalculateNormals();
            GetComponent<MeshFilter>().mesh = mesh;
            GetComponent<MeshRenderer>().material.mainTexture = heighttex;
        }

    }


    private TerrainType ChooseType(float _height)
    {
        foreach (TerrainType terrType in TerrainTypes)
        {
            if (_height < terrType.height)
                return terrType;
        }
        return TerrainTypes[TerrainTypes.Length - 1];
    }



    [System.Serializable]
    public class TerrainType 
    {
        [Range(0.0f, 1.0f)]
        public float height;
        public Color color;

    }
    
}

