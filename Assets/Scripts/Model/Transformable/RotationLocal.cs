namespace Model
{
    public struct RotationLocal : IRotation
    {
        public RotationLocal(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static RotationLocal operator *(RotationLocal a,float value)
        {
            return new RotationLocal()
            {
                X = a.X * value,
                Y = a.Y * value,
                Z = a.Z * value
            };
        }
        public static RotationLocal operator +(RotationLocal a, RotationLocal b)
        {
            return new RotationLocal()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z
            };
        }

        public static RotationLocal operator *(RotationLocal a, RotationLocal b)
        {
            return new RotationLocal()
            {
                X = a.X * b.X,
                Y = a.Y * b.Y,
                Z = a.Z * b.Z
            };
        }
    }
}