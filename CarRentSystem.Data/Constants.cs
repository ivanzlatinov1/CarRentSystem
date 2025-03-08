namespace CarRentSystem.Data
{
    public static class Constants
    {
        // Context's constants
        public const string DefaultConnection
            = "Server=localhost\\SQLEXPRESS;Database=CarRentSystem;Trusted_Connection=True;Encrypt=False";

        // User's constants
        public const int MaxUserNameLength = 80;
        public const int MaxPasswordLength = 50;

        // Car's constants
        public const int MaxCarNameLength = 30;
        public const int MaxDescriptionLength = 256;
    }
}
