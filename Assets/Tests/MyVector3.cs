using UnityEngine;

public struct MyVector3 {

    //Champs
    private float _x;
    private float _y;
    private float _z;

    //Propriétés basiques
    public float X { get => _x; set => _x = value; }
    public float Y { get => _y; set => _y = value; }
    public float Z { get => _z; set => _z = value; }

    //Constructeur
    public MyVector3(float x, float y, float z) {
        _x = x;
        _y = y;
        _z = z;
    }

    //Propriétés
    public float Magnitude => Mathf.Sqrt(SqrtMagnitude); 
    public float SqrtMagnitude => _x*_x + _y*_y + _z*_z;
    public void Normalize()
    {
        float normalizeMagnitude = Magnitude;
        _x = _x / normalizeMagnitude;
        _y = _y / normalizeMagnitude;
        _z = _z / normalizeMagnitude;
    }

    //Surcharge d'opérateur
    public static MyVector3 operator +(MyVector3 left, MyVector3 right)
    {
        return new MyVector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static MyVector3 operator *(MyVector3 left, float right)
    {
        return new MyVector3(left.X * right, left.Y * right, left.Z * right);
    }

    public static MyVector3 operator *(float left, MyVector3 right)
    {
        return new MyVector3(left * right.X, left * right.Y, left * right.Z);
    }

}
