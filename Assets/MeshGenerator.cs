using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public Material mat;

    public float width = 1f;
    public float height = 1f;
    public float roundness = 0.25f;
    public int points = 0;

    public List<int> tris;



    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();


        Vector3[] vertices = new Vector3[4];


        vertices = SquircleGenerator(width, height, roundness, points);


        mesh.vertices = vertices;
        mesh.SetTriangles(tris, 0);

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshFilter>().mesh = mesh;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3[] SquircleGenerator(float width, float height, float roundness, int points)
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> triangles = new List<int>();

        float w = width / 2f;
        float h = height / 2f;
        float r = roundness;

        // big rect
        verts.Add(new Vector3(-w + r, -h));
        verts.Add(new Vector3(-w + r, h));
        verts.Add(new Vector3(w - r, h));
        verts.Add(new Vector3(w - r, -h));
        AddRectTris(triangles, 0);

        // little rects
        verts.Add(new Vector3(-w, -h + r));
        verts.Add(new Vector3(-w, h - r));
        verts.Add(new Vector3(-w + r, h - r));
        verts.Add(new Vector3(-w + r, -h + r));
        AddRectTris(triangles, 4);

        verts.Add(new Vector3(w, -h + r));
        verts.Add(new Vector3(w, h - r));
        verts.Add(new Vector3(w - r, h - r));
        verts.Add(new Vector3(w - r, -h + r));
        AddRectTris(triangles, 8);

        // corners

        // corner one BOTTOM LEFT

        Vector3[] corners = new Vector3[3+points];

        

        Vector3[] vertices = new Vector3[verts.Count];

        tris = triangles;

        return vertices;
    }

    public void AddRectTris(List<int> ts, int i)
    {
        Debug.Log("grr");
        ts.Add(i);
        ts.Add(i + 1);
        ts.Add(i + 2);
        ts.Add(i);
        ts.Add(i + 2);
        ts.Add(i + 3);
    }
}
