namespace GimbalInterface
{
    public interface IGimbalInterface
    {
        void SetAngles(float pitch, float yaw);
        void SetMode(GimbalMode mode);
    }
}
