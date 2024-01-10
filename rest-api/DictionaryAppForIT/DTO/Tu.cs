namespace DictionaryAppForIT.DTO
{
    public class Tu
    {
        public string TenTu { get; set; }
        public string TenLoai { get; set; }
        public string PhienAm { get; set; }
        public string TenChuyenNganh { get; set; }
        public string Nghia { get; set; }
        public string MoTa { get; set; }
        public string ViDu { get; set; }
        public string DongNghia { get; set; }
        public string TraiNghia { get; set; }
        public Tu()
        {

        }

        public Tu(string tenTu, string tenLoai, string phienAm, string tenChuyenNganh, string nghia, string moTa, string viDu, string dongNghia, string traiNghia)
        {
            TenTu = tenTu;
            TenLoai = tenLoai;
            PhienAm = phienAm;
            TenChuyenNganh = tenChuyenNganh;
            Nghia = nghia;
            MoTa = moTa;
            ViDu = viDu;
            DongNghia = dongNghia;
            TraiNghia = traiNghia;
        }
    }
}
