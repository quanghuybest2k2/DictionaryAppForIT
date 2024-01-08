using DictionaryAppForIT.Class;
using DictionaryAppForIT.DAL;
using System;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace DictionaryAppForIT.DTO
{
    public class SpecializationService
    {
        public static async Task LoadSpecializationAsync(Guna2ComboBox cbb)
        {
            try
            {
                object result = await DataProvider.Instance.GetMethod<Specialization>("get-all-specialization");

                if (result != null)
                {
                    cbb.DataSource = result;
                    cbb.DisplayMember = "specialization_name";
                    cbb.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
        }
    }
}
