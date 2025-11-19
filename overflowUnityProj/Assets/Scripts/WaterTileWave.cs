using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;  // <-- THIS is required

public class WaterTileWave : MonoBehaviour
{
    public float waveAmplitude = 0.1f;   // how high tiles move
    public float waveFrequency = 1f;     // how wavy it is
    public float waveSpeed = 1f;         // speed of the wave

    private Tilemap tilemap;
    private Vector3Int[] tilePositions;
    private float[] randomOffsets;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        // Get all tile positions that have tiles
        var positionsList = new System.Collections.Generic.List<Vector3Int>();
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
                positionsList.Add(pos);
        }

        tilePositions = positionsList.ToArray();

        // Give each tile a random offset so they don’t move exactly together
        randomOffsets = new float[tilePositions.Length];
        for (int i = 0; i < randomOffsets.Length; i++)
        {
            randomOffsets[i] = Random.Range(0f, 2 * Mathf.PI);
        }
    }

    void Update()
    {
        for (int i = 0; i < tilePositions.Length; i++)
        {
            Vector3Int pos = tilePositions[i];
            Vector3 worldPos = tilemap.CellToWorld(pos);

            // Calculate vertical offset using sine wave
            float yOffset = Mathf.Sin((worldPos.x * waveFrequency) + (Time.time * waveSpeed) + randomOffsets[i]) * waveAmplitude;

            // Apply offset only vertically
            tilemap.SetTransformMatrix(pos, Matrix4x4.TRS(new Vector3(0, yOffset, 0), Quaternion.identity, Vector3.one));
        }
    }
}
