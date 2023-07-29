
using System;
public struct GridPositon :IEquatable<GridPositon>
{
    public int x;
    public int z;

    public GridPositon(int x,int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPositon positon && x == positon.x && z == positon.z;
    }

    public bool Equals(GridPositon other)
    {
        return this == other;
    }

    public override string ToString()
    {
        return $"x:{x}; z:{z}";
    }

    public static bool operator ==(GridPositon a,GridPositon b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPositon a, GridPositon b)
    {
        return !(a == b);
    }
}
