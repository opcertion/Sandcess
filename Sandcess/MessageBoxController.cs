
namespace Sandcess
{
    internal class MessageBoxController
    {
        public const string DRIVER_ERROR = "Cannot connect to driver.";

        public static void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Error :(",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
