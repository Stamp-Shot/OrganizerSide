using System.Collections.Generic;
using System;

[Serializable]
//送信データ本体
public class requestBody
{
    public List<AnnotateImageRequest> requests;
}

[Serializable]
public class AnnotateImageRequest
{
    public Image image;
    public List<Feature> features;  //要素について
    //public string imageContext;
}

[Serializable]
public class Image
{
    public string content;  //画像データ
    //public ImageSource source;
}

[Serializable]
public class ImageSource
{
    public string gcsImageUri;
}

[Serializable]
public class Feature
{
    public string type;     //判定法
    public int maxResults;  //最大要素数
}

public enum FeatureType
{
    TYPE_UNSPECIFIED,
    FACE_DETECTION,
    LANDMARK_DETECTION,
    LOGO_DETECTION,
    LABEL_DETECTION,        //要素検知
    TEXT_DETECTION,
    SAFE_SEARCH_DETECTION,
    IMAGE_PROPERTIES
}

[Serializable]
public class ImageContext
{
    public LatLongRect latLongRect;
    public string languageHints;
}

[Serializable]
public class LatLongRect
{
    public LatLng minLatLng;
    public LatLng maxLatLng;
}

[Serializable]
public class LatLng
{
    public float latitude;
    public float longitude;
}

[Serializable]
public class responseBody
{
    public List<AnnotateImageResponse> responses;
}

[Serializable]
public class AnnotateImageResponse
{
    public List<EntityAnnotation> labelAnnotations;
}

[Serializable]
public class EntityAnnotation
{
    public string mid;
    public string locale;
    public string description;
    public float score;
    public float confidence;
    public float topicality;
    public BoundingPoly boundingPoly;
    public List<LocationInfo> locations;
    public List<Property> properties;
}

[Serializable]
public class BoundingPoly
{
    public List<Vertex> vertices;
}

[Serializable]
public class Vertex
{
    public float x;
    public float y;
}

[Serializable]
public class LocationInfo
{
    LatLng latLng;
}

[Serializable]
public class Property
{
    string name;
    string value;
}
