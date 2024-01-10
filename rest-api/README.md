[Server] (https://github.com/quanghuybest2k2/dictionary-web/tree/main/dictionary-server)

 ```csharp
 try
 {
     HttpResponseMessage response = await client.GetAsync(apiUrl + $"show-love-vocabulary/{Class_TaiKhoan.IdTaiKhoan}");

     string responseContent = await response.Content.ReadAsStringAsync();

     var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoveResponse[]>>(responseContent);

     if (apiResponse.Status && apiResponse.Data != null)
     {
         // action
     }
     else
     {
         RJMessageBox.Show(apiResponse.Message);
     }
 }
 catch (Exception ex)
 {
     RJMessageBox.Show(ex.Message);
 }
```
