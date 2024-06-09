using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // FMOD Studio değişkenleri
    public FMODUnity.EventReference eventReference;

    public float wood;
    public float water;
    public float dirt;
    public float sand;
    public float grass; // Çim parametresi eklendi

    public float stepDistance = 2.0f;
    private float stepRand;
    private Vector3 prevPos;
    private float distanceTravelled;

    public bool debug;
    private Vector3 linePos;
    private Vector3 trianglePoint0;
    private Vector3 trianglePoint1;
    private Vector3 trianglePoint2;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Second);
        stepRand = Random.Range(0.0f, 0.5f);
        prevPos = transform.position;
        linePos = transform.position;
    }

    void Update()
    {
        distanceTravelled += (transform.position - prevPos).magnitude;
        if (distanceTravelled >= stepDistance + stepRand)
        {
            PlayFootstepSound();
            stepRand = Random.Range(0.0f, 0.5f);
            distanceTravelled = 0.0f;
        }

        prevPos = transform.position;

        if (debug)
        {
            Debug.DrawLine(linePos, linePos + Vector3.down * 1000.0f);
            Debug.DrawLine(trianglePoint0, trianglePoint1);
            Debug.DrawLine(trianglePoint1, trianglePoint2);
            Debug.DrawLine(trianglePoint2, trianglePoint0);
        }
    }

    void PlayFootstepSound()
    {
        // Varsayılanlar
        water = 0.0f;
        dirt = 1.0f;
        sand = 0.0f;
        wood = 0.0f;
        grass = 0.0f;

        Debug.Log("PlayFootstepSound çağrıldı");

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1000.0f))
        {
            Debug.Log("Raycast zemini vurdu");

            if (debug)
                linePos = transform.position;

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                int materialIndex = GetMaterialIndex(hit);
                if (materialIndex != -1)
                {
                    Material material = hit.collider.gameObject.GetComponent<Renderer>().materials[materialIndex];
                    if (material.name == "Sprite-Lit-Default")
                    {
                        if (debug)
                        {
                            MeshFilter mesh = hit.collider.gameObject.GetComponent<MeshFilter>();
                            if (mesh)
                            {
                                Mesh m = mesh.mesh;
                                trianglePoint0 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 0]]);
                                trianglePoint1 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 1]]);
                                trianglePoint2 = hit.collider.transform.TransformPoint(m.vertices[m.triangles[hit.triangleIndex * 3 + 2]]);
                            }
                        }

                        Texture2D maskTexture = material.GetTexture("Dirt") as Texture2D;
                        if (maskTexture != null)
                        {
                            Color maskPixel = maskTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);

                            Texture2D specTexture2 = material.GetTexture("Sprite-Lit-Default") as Texture2D;
                            if (specTexture2 != null)
                            {
                                float tiling = 40.0f;
                                float u = hit.textureCoord.x % (1.0f / tiling);
                                float v = hit.textureCoord.y % (1.0f / tiling);
                                Color spec2Pixel = specTexture2.GetPixelBilinear(u, v);

                                float specMultiplier = 6.0f;
                                water = maskPixel.a * Mathf.Min(spec2Pixel.a * specMultiplier, 0.9f);
                                dirt = (1.0f - maskPixel.a);
                                sand = maskPixel.a - water * 0.1f;
                                wood = 0.0f;
                                grass = maskPixel.r; // Çim parametresi kırmızı kanal ile temsil ediliyor
                            }
                        }
                    }
                }
            }
            else
            {
                water = 0.0f;
                dirt = 0.0f;
                sand = 0.0f;
                wood = 1.0f;
                grass = 0.0f;
            }
        }

        if (debug)
            Debug.Log($"Wood: {wood} Dirt: {dirt} Sand: {sand} Water: {water} Grass: {grass}");

        if (eventReference.IsNull)
        {
            Debug.LogWarning("FMOD Event Reference is null.");
            return;
        }

        FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

        e.setParameterByName("Wood", wood);
        e.setParameterByName("Dirt", dirt);
        e.setParameterByName("Sand", sand);
        e.setParameterByName("Water", water);
        e.setParameterByName("Grass", grass);

        e.start();
        e.release();
    }

    int GetMaterialIndex(RaycastHit hit)
    {
        Mesh m = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;
        int[] triangle = new int[]
        {
            m.triangles[hit.triangleIndex * 3 + 0],
            m.triangles[hit.triangleIndex * 3 + 1],
            m.triangles[hit.triangleIndex * 3 + 2]
        };
        for (int i = 0; i < m.subMeshCount; ++i)
        {
            int[] triangles = m.GetTriangles(i);
            for (int j = 0; j < triangles.Length; j += 3)
            {
                if (triangles[j + 0] == triangle[0] &&
                    triangles[j + 1] == triangle[1] &&
                    triangles[j + 2] == triangle[2])
                    return i;
            }
        }
        return -1;
    }
}
