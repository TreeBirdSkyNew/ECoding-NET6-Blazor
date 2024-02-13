namespace E_CODING_FrontBlazor.DTOs
{
    public class Child
    {
        public string text { get; set; }
        public string value { get; set; }
        public List<Child> children { get; set; }
        public bool? disabled { get; set; }
        public bool? collapsed { get; set; }
        public bool? @checked { get; set; }
    }
}
