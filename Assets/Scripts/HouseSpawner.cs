using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject house;
    public Camera camera;
    public List<Vector2> coords = new List<Vector2>();

    private float earthCircumference = 40075000;
    // Start is called before the first frame update
    void Start()
    {
        float houseHeight = house.GetComponent<MeshRenderer>().bounds.extents.y;

        coords.Add(new Vector2 (47.4050971f, 9.7426105f));
        coords.Add(new Vector2 (47.4050583f, 9.7436344f));
        coords.Add(new Vector2 (47.4054232f, 9.7430115f));
        coords.Add(new Vector2 (47.4054460f, 9.7426622f));
        coords.Add(new Vector2 (47.4047326f, 9.7424377f));
        coords.Add(new Vector2 (47.4052588f, 9.7428630f));
        coords.Add(new Vector2 (47.4053796f, 9.7431154f));

        coords = bringCoordsToCenter(coords);

        foreach (Vector2 coord in coords)
        {
            GameObject go = Instantiate(house);
            Vector2 pos = latLonToCoordsInMeters(coord.x, coord.y);
            Debug.Log(pos);
            go.transform.position = new Vector3(
                pos.x,
                houseHeight,
                pos.y
            );
        }
        
        camera.transform.position.Set(coords[0].x, 50, coords[0].y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 latLonToCoordsInMeters(float lat, float lon) {
        return new Vector2(
            lon * earthCircumference / 360 * Mathf.Cos(lat * Mathf.Deg2Rad),
            lat * earthCircumference / 360
        );
    }

    List<Vector2> bringCoordsToCenter(List<Vector2> coords) {
        Vector2 referencePoint = coords[0];
        for (int i = 0; i < coords.Count; i++)
        {
            coords[i] -= referencePoint;
        }
        return coords;
    }
}
