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
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3[] SquircleGenerator(float width, float height, float roundness, int points)
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> triangles = new List<int>();
        int i = 0;

        float w = width / 2f;
        float h = height / 2f;
        float r = roundness;

        // big rect
        verts.Add(new Vector3(-w + r, -h));
        verts.Add(new Vector3(-w + r, h));
        verts.Add(new Vector3(w - r, h));
        verts.Add(new Vector3(w - r, -h));
        AddRectTris(triangles, i);
        i += 4;

        // little rects
        verts.Add(new Vector3(-w, -h + r));
        verts.Add(new Vector3(-w, h - r));
        verts.Add(new Vector3(-w + r, h - r));
        verts.Add(new Vector3(-w + r, -h + r));
        AddRectTris(triangles, i);
        i += 4;

        verts.Add(new Vector3(w - r, -h + r));
        verts.Add(new Vector3(w - r, h - r));
        verts.Add(new Vector3(w, h - r));
        verts.Add(new Vector3(w, -h + r));
        AddRectTris(triangles, i);
        i += 4;

        // corners
        Vector3[] corners = new Vector3[3 + points];

        // corner one BOTTOM LEFT

        corners[0] = new Vector3(-w, -h + r);
        corners[1] = new Vector3(-w + r, -h + r);
        corners[2] = new Vector3(-w + r, -h);

        // add corners to verts

        // BOTTOM LEFT
        verts.Add(corners[0]);
        verts.Add(corners[1]);
        verts.Add(corners[2]);
        triangles.Add(i);
        triangles.Add(i+1);
        triangles.Add(i+2);
        i += 3;

        // TOP LEFT
        verts.Add(new Vector3(corners[0].x, -corners[0].y));
        verts.Add(new Vector3(corners[1].x, -corners[1].y));
        verts.Add(new Vector3(corners[2].x, -corners[2].y));
        triangles.Add(i);
        triangles.Add(i + 2);
        triangles.Add(i + 1);
        i += 3;

        // TOP RIGHT
        verts.Add(new Vector3(-corners[0].x, -corners[0].y));
        verts.Add(new Vector3(-corners[1].x, -corners[1].y));
        verts.Add(new Vector3(-corners[2].x, -corners[2].y));
        triangles.Add(i);
        triangles.Add(i + 1);
        triangles.Add(i + 2);
        i += 3;

        // BOTTOM RIGHT
        verts.Add(new Vector3(-corners[0].x, corners[0].y));
        verts.Add(new Vector3(-corners[1].x, corners[1].y));
        verts.Add(new Vector3(-corners[2].x, corners[2].y));
        triangles.Add(i);
        triangles.Add(i + 2);
        triangles.Add(i + 1);
        i += 3;



        Vector3[] vertices = verts.ToArray();

        tris = triangles;

        return vertices;
    }

    public void AddRectTris(List<int> ts, int i)
    {
        ts.Add(i);
        ts.Add(i + 1);
        ts.Add(i + 2);
        ts.Add(i);
        ts.Add(i + 2);
        ts.Add(i + 3);
    }
}
