using UnityEngine;
using UnityEditor;

namespace Tools
{
    public class CyllinderGenerator : EditorWindow
    {
        Mesh mesh;
        Vector3[] vertices;
        int[] triangles;

        
        float radius=0.5f;
        float height=1;
        float offset=-1;
        MeshCollider collider;

        [MenuItem("Tools/CyllinderGenerator")]
        public static void ShowWindow()
        {
            EditorWindow editorWindow = GetWindow<CyllinderGenerator>("CyllinderGenerator");
            editorWindow.autoRepaintOnSceneChange = true;           
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Выберите MeshCollider");
            collider = EditorGUILayout.ObjectField("MeshCollider",collider,typeof(MeshCollider),true) as MeshCollider;
            if(collider!=null)
            {
                if(collider.sharedMesh==null)
                {
                    if(GUILayout.Button("Создать Сylinder",GUILayout.Width(Screen.width)) )
                    {
                        if (collider != null)
                        {
                            CreateCylinder();
                        }
                    }
                }
                else
                {
                    radius = EditorGUILayout.FloatField("Radius: ",radius);
                    height = EditorGUILayout.FloatField("Height: ", height);
                    offset = EditorGUILayout.FloatField("Offset Y: ", offset);

                    if (GUI.changed)
                    {
                        if (collider != null && radius != 0)
                        {
                            CreateCylinder();
                        }
                    }
                }    
            }              
        }
        void CreateCylinder()
        {
            mesh = new Mesh();
            CreateMesh();
            UpdateMesh();
        }
        void CreateMesh()
        {

            vertices = new Vector3[26];
            triangles = new int[150];

            float angle = 0;
            vertices[0] = new Vector3(0,offset,0);

            //First Circle

            for(int i=1;i<13;i++)
            {
                vertices[i] = new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad *angle),offset,radius * Mathf.Cos(Mathf.Deg2Rad * angle));
                angle+=30;
            }

            for(int i=0;i<11;i++)
            {
                triangles[i*3] = i+1;
                triangles[i*3+1] = i+2;
                triangles[i*3+2] = 0;
            }
                triangles[33] = 12;
                triangles[34] = 1;
                triangles[35] = 0;

            //Second Circle

            vertices[13] = new Vector3(0,offset+height,0);
            angle = 0;
           
            for(int i=14;i<26;i++)
            {
                vertices[i] = new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad *angle),offset+height,radius * Mathf.Cos(Mathf.Deg2Rad * angle));
                angle+=30;
            }

            for(int i=12;i<24;i++)
            {
                triangles[i*3] = i+1;
                triangles[i*3+1] = i+2;
                triangles[i*3+2] = 13;

            }
                triangles[72] = 25;
                triangles[73] = 14;
                triangles[74] = 13;

            //Sides
            int y = 75;
            for(int i=1;i<12;i++)
            {
                triangles[y] = i+13;
                triangles[y+1] = i+1;
                triangles[y+2] = i;
                triangles[y+3] = i+13;
                triangles[y+4] = i+14;
                triangles[y+5] = i+1;
                y+=6;     
            }
        }
        void UpdateMesh()
        {
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.name="Cyllinder";

            collider.sharedMesh = mesh;           
        }
    }
}