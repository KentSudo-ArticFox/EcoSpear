using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class OceanWaves : MonoBehaviour
{
    public float waveHeight = 0.3f;
    public float waveSpeed = 1f;
    public float waveScale = 2f;

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] baseVertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        baseVertices = mesh.vertices.Clone() as Vector3[];
    }

    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 v = baseVertices[i];

            v.y = Mathf.Sin(Time.time * waveSpeed + v.x * waveScale + v.z * waveScale) * waveHeight;

            vertices[i] = v;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}