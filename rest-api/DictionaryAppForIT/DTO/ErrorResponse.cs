using DictionaryAppForIT.Class;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DictionaryAppForIT.DTO
{
    public static class ErrorResponse
    {
        public static void HandleErrors<T>(this ApiResponse<T> apiResponse)
        {
            if (apiResponse.Errors != null)
            {
                var errors = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(apiResponse.Errors.ToString());
                string errorMessage = "";
                foreach (KeyValuePair<string, List<string>> errorPair in errors)
                {
                    errorMessage += errorPair.Value[0] + "\n";
                }

                RJMessageBox.Show(errorMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RJMessageBox.Show(apiResponse.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
