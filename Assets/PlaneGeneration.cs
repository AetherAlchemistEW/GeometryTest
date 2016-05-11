using UnityEngine;
using System.Collections;

public class PlaneGeneration : MonoBehaviour 
{
	//length and width of the plane
	public float m_Width;
	public float m_Length;

	//arrays for the plane
	//vertices
	Vector3[] vertices = new Vector3[6];
	//the face normals
	Vector3[] normals = new Vector3[6];
	//the UVs
	Vector2[] uv = new Vector2[6];

	//material
	public Material mat;

	//indicies, these relate to the corners of the triangles, it's the index of the vertex of the triangles.
	//Order is important, clockwise = facing, counterclockwise = backface.
	int[] indices = new int[12]; //2 triangles, 3 indices each

	void Awake()
	{
		//verticies for the single polygon
		vertices[0] = new Vector3(0.0f, 1.5f, 0.0f);
		uv[0] = new Vector2(0.0f, 0.0f);
		normals[0] = Vector3.up;

		vertices[1] = new Vector3(0.0f, 0.0f, m_Length);
		uv[1] = new Vector2(0.0f, 1.0f);
		normals[1] = Vector3.up;
		
		vertices[2] = new Vector3(m_Width, 1.5f, m_Length);
		uv[2] = new Vector2(1.0f, 1.0f);
		normals[2] = Vector3.up;
		
		vertices[3] = new Vector3(m_Width, 0.0f, 0.0f);
		uv[3] = new Vector2(1.0f, 0.0f);
		normals[3] = Vector3.up;

		//second plane...
		vertices [4] = new Vector3 (0.0f, 1.5f, m_Length * 2);
		uv [4] = new Vector2 (0.0f, 2.0f);
		normals [4] = Vector3.up;

		vertices [5] = new Vector3 (m_Width, 0.0f, m_Length * 2);
		uv [5] = new Vector2 (1.0f, 2.0f);
		normals [5] = Vector3.up;

		//indicies for both triangles
		indices[0] = 0;
		indices[1] = 1;
		indices[2] = 2;
		
		indices[3] = 0;
		indices[4] = 2;
		indices[5] = 3;

		indices [6] = 1;
		indices [7] = 4;
		indices [8] = 5;

		indices [9] = 1;
		indices [10] = 5;
		indices [11] = 2;

		Mesh mesh = new Mesh ();

		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.uv = uv;
		mesh.triangles = indices;

		MeshFilter filter = GetComponent<MeshFilter>();
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		MeshCollider collider = GetComponent<MeshCollider> ();
		
		if (filter != null)
		{
			filter.sharedMesh = mesh;
		}

		if (renderer != null)
		{
			renderer.material = mat;
		}

		if(collider != null)
		{
			collider.sharedMesh = mesh;
		}
	}
}
