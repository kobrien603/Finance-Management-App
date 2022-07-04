namespace FinanceManagementApp.Models
{
    public class DatasetModel
    {
        public string Label { get; set; } = "";
        public List<double> Data { get; set; } = new();
        public string YAxisID { get; set; } = "y";
    }
}
